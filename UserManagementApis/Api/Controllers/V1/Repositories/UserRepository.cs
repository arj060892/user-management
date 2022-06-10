using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagementApi.Api.Controllers.V1.Models;

namespace UserManagementApi.Api.Controllers.V1.Repositories
{
    public class UserRepository : IGenericRepository<UserDetails>
    {
        private readonly IMongoCollection<UserDetails> _userCollection;
        public UserRepository(IOptions<UserDatabaseSettings> userDatabaseSettings)
        {
            MongoClient? mongoClient = new(userDatabaseSettings.Value.ConnectionString);
            IMongoDatabase? mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<UserDetails>(userDatabaseSettings.Value.UserCollectionName);
        }

        public Task Create(UserDetails userDetails)
        {
            return _userCollection.InsertOneAsync(userDetails);
        }

        public Task Delete(int userId)
        {
            return _userCollection.DeleteOneAsync(x => x.Id == userId);
        }

        public Task<List<UserDetails>> GetAll()
        {
            return _userCollection.Find(_ => true).ToListAsync();
        }

        public Task<UserDetails> GetById(int userId)
        {
            return _userCollection.Find(user => user.Id == userId).FirstOrDefaultAsync();
        }

        public Task Update(UserDetails userDetails, int userId)
        {
            return _userCollection.ReplaceOneAsync(x => x.Id == userId, userDetails);
        }
    }
}
