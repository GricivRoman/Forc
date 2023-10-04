using Forc.FileStorage.Helpers;
using Forc.FileStorage.Interfaces;
using Forc.FileStorage.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Forc.FileStorage.Services
{
    public class UserService : IUserService
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;
        private IMongoCollection<FileModel> _userCollection;

        public UserService(IOptions<FileStorageSettings> dbSettings)
        {
            _mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _userCollection = _mongoDatabase.GetCollection<FileModel>(dbSettings.Value.Collections.UserCollection);
        }

        public async Task<FileModel> GetUser(Guid id)
        {
            var user = await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if(user == null)
            {
                throw new ApplicationException("Invalid ID");
            }

            user.File = ImapeHelper.GetImage(Convert.ToBase64String(user.File));
            return user;
        }

        public async Task SaveUser(FileToUpload fileToUpload)
        {
            if (fileToUpload == null || fileToUpload.File == null || fileToUpload.File.Length == 0)
            {
                throw new ApplicationException("Invalid file");
            }

            FileModel userModel;

            try
            {
                userModel = JsonConvert.DeserializeObject<FileModel>(fileToUpload.Model);
            }
            catch (NullReferenceException ex)
            {
                throw new ApplicationException("Invalid ID");
            }

            using (var ms = new MemoryStream())
            {
                fileToUpload.File.CopyTo(ms);
                var fileBytes = ms.ToArray();

                userModel.File = fileBytes;
                var user = await _userCollection.Find(x => x.Id == userModel.Id).FirstOrDefaultAsync();

                if (user == null)
                {
                    await _userCollection.InsertOneAsync(userModel);
                }
                else
                {
                    await _userCollection.ReplaceOneAsync(x => x.Id == userModel.Id, userModel);
                }
            }
        }
    }
}
