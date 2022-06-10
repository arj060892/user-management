using AutoFixture;
using AutoFixture.AutoMoq;
using UserManagementApi.Api.Controllers.V1.Models;
using UserManagementApi.Api.Controllers.V1.Services;
using Xunit;

namespace UserManagementApi.Test
{
    public class UserServiceShould
    {
        private readonly MockRepository mockRepository;
        public UserServiceShould()
        {
            mockRepository = new();
        }
        protected static IFixture CreateFixture()
        {
            return new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        [Fact]
        public async Task GetAllUsersAsync()
        {
            // Arrange
            UserService? sut = new(mockRepository);

            // Act
            List<UserDetails>? result = await sut.GetAllUsersAsync()
                .ConfigureAwait(false);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserByIdAsync()
        {
            // Arrange
            UserService? sut = new(mockRepository);

            // Act
            List<UserDetails>? userDetails = await sut.GetAllUsersAsync()
                .ConfigureAwait(false);
            UserDetails response = userDetails.First();

            UserDetails? result = await sut.GetUserByIdAsync(response.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task CreateUserAsync()
        {
            // Arrange
            UserService? sut = new(mockRepository);
            List<UserDetails>? userDetails = await sut.GetAllUsersAsync()
                .ConfigureAwait(false);
            int totalCount = userDetails.Count;

            // Act
            IFixture? fixture = CreateFixture();
            UserDetails? newUser = fixture.Create<UserDetails>();

            await sut.CreateUserAsync(newUser);

            userDetails = await sut.GetAllUsersAsync()
                .ConfigureAwait(false);
            int newCount = userDetails.Count;

            // Assert
            Assert.True(newCount > totalCount);
        }

        [Fact]
        public async Task DeleteUserAsync()
        {
            // Arrange
            UserService? sut = new(mockRepository);
            List<UserDetails>? userDetails = await sut.GetAllUsersAsync()
                .ConfigureAwait(false);
            UserDetails response = userDetails.First();

            // Act
            await sut.DeleteUserAsync(response.Id);

            // Assert
            Assert.Null(await sut.GetUserByIdAsync(response.Id));
        }

    }
}
