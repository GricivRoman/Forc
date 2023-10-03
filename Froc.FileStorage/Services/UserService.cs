using Forc.FileStorage.Interfaces;
using Forc.FileStorage.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Forc.FileStorage.Services
{
    public class UserService : IUserService
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;
        private IMongoCollection<UserModel> _userCollection;

        public UserService(IOptions<FileStorageSettings> dbSettings)
        {
            _mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _userCollection = _mongoDatabase.GetCollection<UserModel>(dbSettings.Value.Collections.UserCollection);
        }

        public async Task<UserModel> GetUser(Guid id)
        {
            var user = await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if(user == null)
            {
                throw new ApplicationException("User with that Id doesn't exist");
            }

            return user;
        }

        public async Task<UserModel> SaveUser(UserModel userModel)
        {
            var user = await _userCollection.Find(x => x.Id == userModel.Id).FirstOrDefaultAsync();

            if(user == null)
            {
                await _userCollection.InsertOneAsync(userModel);
            }
            else
            {
                await _userCollection.ReplaceOneAsync(x => x.Id == userModel.Id, userModel);
            }

            return user;
        }
    }
}
