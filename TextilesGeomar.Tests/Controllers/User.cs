using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextilesGeomar.API.Controllers;
using TextilesGeomar.API.DTOs;
using TextilesGeomar.API.Services.Interfaces;
using Xunit;

namespace TextilesGeomar.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetUsers_ShouldReturnOkResult_WithListOfUsers()
        {
            // Arrange
            var userList = new List<UserDTO>
            {
                new UserDTO { UserId = 1, Name = "Alice", LastName = "Smith", Email = "alice@example.com" },
                new UserDTO { UserId = 2, Name = "Bob", LastName = "Johnson", Email = "bob@example.com" }
            };

            _userServiceMock.Setup(service => service.GetUsersAsync())
                .ReturnsAsync(userList);

            // Act
            var result = await _userController.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<UserDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Equal("Alice", returnValue[0].Name);
            Assert.Equal("Bob", returnValue[1].Name);
        }
    }
}
