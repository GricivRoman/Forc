using Forc.WebApi.Dto.FileStorage;
using Forc.WebApi.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Forc.WebApi.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly HttpClient _http;

        public FileStorageService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _http.BaseAddress = new Uri(config["FileStorageURL"]);
        }

        public async Task<FileViewModel> GetFileAsync(string path, Guid id)
        {
            var resp = await _http.GetAsync($"{path}/{id}");
            CheckResponseStatusCode(resp);
            return await resp.Content.ReadFromJsonAsync<FileViewModel>();
        }

        public async Task UploadFileAsync(string path, FileToUploadViewModel fileModel)
        {
            using (var ms = new MemoryStream())
            using (var form = new MultipartFormDataContent())
            {
                var file = fileModel.File;
                file.CopyTo(ms);
                var fileContent = new ByteArrayContent(ms.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, file.Name, file.FileName);
                var model = new FileViewModel { Id = fileModel.Id };
                form.Add(new StringContent(JsonConvert.SerializeObject(model)), "Model");
                var resp = await _http.PostAsync(path, form);
                CheckResponseStatusCode(resp);
            }
        }

        private void CheckResponseStatusCode(HttpResponseMessage resp)
        {
            try
            {
                resp.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
