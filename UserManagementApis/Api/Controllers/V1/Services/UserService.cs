using UserManagementApi.Api.Controllers.V1.Models;
using UserManagementApi.Api.Controllers.V1.Repositories;

namespace UserManagementApi.Api.Controllers.V1.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserDetails> userRepository;

        public UserService(IGenericRepository<UserDetails> userRepository)
        {
            this.userRepository = userRepository;
        }


        //To fetch all users.
        public async Task<List<UserDetails>> GetAllUsersAsync()
        {
            return await userRepository.GetAll();
        }

        //To fetch a user as per the user id.
        public async Task<UserDetails?> GetUserByIdAsync(int userId)
        {
            return await userRepository.GetById(userId);
        }

        //To create a new user entry.
        public async Task CreateUserAsync(UserDetails userDetails)
        {
            await userRepository.Create(userDetails);
        }

        //To update a user as per the user id.
        public async Task UpdateUserAsync(UserDetails userDetails, int userId)
        {
            await userRepository.Update(userDetails, userId);
        }

        //To remove a user as per the user id.
        public async Task DeleteUserAsync(int userId)
        {
            await userRepository.Delete(userId);
        }
    }
}
