using UserManagementApi.Api.Controllers.V1.Models;

namespace UserManagementApi.Api.Controllers.V1.Services
{
    public interface IUserService
    {
        public Task<List<UserDetails>> GetAllUsersAsync();
        public Task<UserDetails?> GetUserByIdAsync(int userId);
        public Task CreateUserAsync(UserDetails userDetails);
        public Task UpdateUserAsync(UserDetails userDetails, int userId);
        public Task DeleteUserAsync(int userId);
    }
}
