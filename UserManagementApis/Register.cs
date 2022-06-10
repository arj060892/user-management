using UserManagementApi.Api.Controllers.V1.Models;
using UserManagementApi.Api.Controllers.V1.Repositories;
using UserManagementApi.Api.Controllers.V1.Services;

namespace UserManagementApi
{
    public static class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<UserDetails>, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }


    }
}
