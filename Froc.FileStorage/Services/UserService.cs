using Forc.FileStorage.Interfaces;
using Forc.FileStorage.Models;
using MongoDB.Driver;

namespace Forc.FileStorage.Services
{
    public class UserService : IUserService
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;
        private IMongoCollection<UserModel> _userCollection;

        public UserService(IConfiguration config)
        {
            _mongoClient = new MongoClient(config["FileStorageDB:ConnectionString"]);
            _mongoDatabase = _mongoClient.GetDatabase(config["FileStorageDB:DatabaseName"]);
            _userCollection = _mongoDatabase.GetCollection<UserModel>(config["FileStorageDB:UserCollectionName"]);
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
