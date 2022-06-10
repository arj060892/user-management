using AutoFixture;
using UserManagementApi.Api.Controllers.V1.Models;
using UserManagementApi.Api.Controllers.V1.Repositories;

namespace UserManagementApi.Test
{
    public class MockRepository : IGenericRepository<UserDetails>
    {
        private readonly List<UserDetails> userCollection;
        protected static IFixture CreateFixture()
        {
            return new Fixture();
        }
        public MockRepository()
        {
            IFixture? fixture = CreateFixture();
            userCollection = fixture.Create<List<UserDetails>>();
        }

        public Task Create(UserDetails data)
        {
            userCollection.Add(data);
            return Task.Delay(1);

        }

        public async Task Delete(int id)
        {
            int index = await Task.FromResult(userCollection.FindIndex(u => u.Id == id));

            if (index >= 0)
            {
                userCollection.RemoveAt(index);
            }
        }

        public Task<List<UserDetails>> GetAll()
        {
            return Task.FromResult(userCollection);
        }

        public async Task<UserDetails?> GetById(int id)
        {
            return await Task.FromResult(userCollection.Find(u => u.Id == id));
        }

        public async Task Update(UserDetails data, int id)
        {
            int indexOf = await Task.FromResult(userCollection.IndexOf(userCollection.Find(u => u.Id == id)));
            userCollection[indexOf] = data;
        }
    }
}
