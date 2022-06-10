using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UserManagementApi.Api.Controllers.V1;
using UserManagementApi.Api.Controllers.V1.Models;
using UserManagementApi.Api.Controllers.V1.Services;
using Xunit;

namespace UserManagementApi.Test
{
    public class UserControllerShould
    {
        protected static IFixture CreateFixture()
        {
            return new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        public class GetAllUsersAsync
        {

            [Fact]
            public async Task WithOkCode()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                List<UserDetails>? expectedResponse = fixture.Create<List<UserDetails>>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.GetAllUsersAsync())
                .ReturnsAsync(expectedResponse);

                UserController? sut = new(serviceMoq.Object);

                // Act
                List<UserDetails>? result = await sut.GetAllUsersAsync()
                    .ConfigureAwait(false);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(result, expectedResponse);
            }
        }

        public class GetUserByIdAsync
        {
            [Fact]
            public async Task WithRequestedUserDetails()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                UserDetails expectedResponse = fixture.Create<UserDetails>();
                int request = fixture.Create<int>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.GetUserByIdAsync(request))
                .ReturnsAsync(expectedResponse);

                UserController? sut = new(serviceMoq.Object);

                // Act
                ActionResult<UserDetails>? result = await sut.GetUserByIdAsync(request)
                    .ConfigureAwait(false);

                // Assert
                Assert.NotNull(result.Value);
                Assert.Equal(result.Value, expectedResponse);
            }

            [Fact]
            public async Task WithEmptyResultIfUserNotFound()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                int request = fixture.Create<int>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.GetUserByIdAsync(request))
                .ReturnsAsync(null as UserDetails);

                UserController? sut = new(serviceMoq.Object);

                // Act
                ActionResult<UserDetails>? result = await sut.GetUserByIdAsync(request)
                    .ConfigureAwait(false);

                // Assert
                Assert.Null(result.Value);
            }
        }

        public class CreateUserAsync
        {
            [Fact]
            public async Task WithCreatedStatusCode()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                UserDetails request = fixture.Create<UserDetails>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.CreateUserAsync(request));

                UserController? sut = new(serviceMoq.Object);

                // Act
                CreatedAtActionResult result = (CreatedAtActionResult)await sut.CreateUserAsync(request);

                // Assert
                Assert.Equal(201, result.StatusCode);
            }
        }

        public class UpdateUserAsync
        {
            [Fact]
            public async Task WithOkStatusOnUpdate_WhenUserIsFound()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                UserDetails userDetailsRequest = fixture.Create<UserDetails>();
                int userIdRequest = fixture.Create<int>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.UpdateUserAsync(userDetailsRequest, userIdRequest));
                serviceMoq.Setup(service => service.GetUserByIdAsync(userIdRequest))
                    .ReturnsAsync(fixture.Create<UserDetails>());

                UserController? sut = new(serviceMoq.Object);

                // Act
                OkResult? result = (OkResult)await sut.UpdateUserAsync(userDetailsRequest, userIdRequest);

                // Assert
                Assert.Equal(200, result.StatusCode);
            }

            [Fact]
            public async Task WithNotFoundStatusOnUpdate_WhenUserIsNotFound()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                UserDetails userDetailsRequest = fixture.Create<UserDetails>();
                int userIdRequest = fixture.Create<int>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.UpdateUserAsync(userDetailsRequest, userIdRequest));
                serviceMoq.Setup(service => service.GetUserByIdAsync(userIdRequest))
                    .ReturnsAsync(null as UserDetails);

                UserController? sut = new(serviceMoq.Object);

                // Act
                NotFoundResult result = (NotFoundResult)await sut.UpdateUserAsync(userDetailsRequest, userIdRequest);

                // Assert
                Assert.Equal(404, result.StatusCode);
            }
        }

        public class DeleteUserAsync
        {
            [Fact]
            public async Task WithOkStatusOnUpdate_WhenUserIsFound()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                int userIdRequest = fixture.Create<int>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.DeleteUserAsync(userIdRequest));
                serviceMoq.Setup(service => service.GetUserByIdAsync(userIdRequest))
                    .ReturnsAsync(fixture.Create<UserDetails>());

                UserController? sut = new(serviceMoq.Object);

                // Act
                OkResult? result = (OkResult)await sut.DeleteUserAsync(userIdRequest);

                // Assert
                Assert.Equal(200, result.StatusCode);
            }

            [Fact]
            public async Task WithNotFoundStatusOnDelete_WhenUserIsNotFound()
            {
                // Arrange
                IFixture? fixture = CreateFixture();
                int userIdRequest = fixture.Create<int>();
                Mock<IUserService>? serviceMoq = fixture.Freeze<Mock<IUserService>>();
                serviceMoq.Setup(service => service.DeleteUserAsync(userIdRequest));
                serviceMoq.Setup(service => service.GetUserByIdAsync(userIdRequest))
                    .ReturnsAsync(null as UserDetails);

                UserController? sut = new(serviceMoq.Object);

                // Act
                NotFoundResult result = (NotFoundResult)await sut.DeleteUserAsync(userIdRequest);

                // Assert
                Assert.Equal(404, result.StatusCode);
            }
        }
    }
}
