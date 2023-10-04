using AutoMapper;
using Forc.WebApi.Data;
using Forc.WebApi.Dto;
using Forc.WebApi.Dto.FileStorage;
using Forc.WebApi.Infrastructure.Entities;
using Forc.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Forc.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _http;

        public UserService(DataContext context, IMapper mapper, HttpClient http, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;

            _http = http;
            _http.BaseAddress = new Uri(config["FileStorageURL"]);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Set<User>().Where(x => x.Id == id).SingleOrDefaultAsync();
            _context.Set<User>().Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUserAsync(Guid id)
        {
            var user = await _context.Set<User>()
                .Where(x => x.Id == id)
                .Include(x => x.PhysicalActivity)
                .SingleOrDefaultAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task UpdateUserAsync(UserViewModel model)
        {
            var user = await _context.Set<User>().Where(x => x.Id == model.Id).SingleOrDefaultAsync();

            user.Name = model.Name;
            user.Gender = model.Gender;
            user.BirthDate = model.BirthDate;
            user.Sex = model.Sex?.Id;
            user.PhysicalActivityId = model.PhysicalActivity?.Id;
            user.Height = model.Height;
            await _context.SaveChangesAsync();
        }


        // TODO вынести работу с FileStorage в отдельный сервис
        public async Task UploadPhotoAsync(FileToUploadViewModel fileModel)
        {
            using (var ms= new MemoryStream())
            using (var form = new MultipartFormDataContent())
            {
                var file = fileModel.File;
                file.CopyTo(ms);
                var fileContent = new ByteArrayContent(ms.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, file.Name, file.FileName);
                var model = new FileViewModel { Id = fileModel.Id };
                form.Add(new StringContent(JsonConvert.SerializeObject(model)), "Model");
                await _http.PostAsync("/user", form);

                // TODO проверка статус кода ответа
            }
        }

        public async Task<FileViewModel> GetPhotoAsync(Guid id)
        {
            var resp = await _http.GetAsync($"/user/{id}");
            // TODO проверка статус кода ответа
            return await resp.Content.ReadFromJsonAsync<FileViewModel>();
        }
    }
}
