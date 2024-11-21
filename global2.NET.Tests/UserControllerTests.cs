using global2.NET.Controllers;
using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Moq;
using Xunit;

namespace global2.NET.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IRepository<PrincipalUser>> _userRepositoryMock;
        private readonly UserController _userController;
        private readonly PrincipalUser _validUser;

        public UserControllerTests()
        {
            _userRepositoryMock = new Mock<IRepository<PrincipalUser>>();
            _userController = new UserController(_userRepositoryMock.Object);

            _validUser = new PrincipalUser
            {
                IdUsua = 1,
                NomeUsua = "John Doe",
                EmailUsua = "johndoe@example.com",
                SenhaUsua = "password123",
                IncentiveScoreId = 1
            };
        }

        [Fact]
        public void PostUser_ShouldAddUserAndReturnCreatedResult()
        {
            var result = _userController.PostUser(_validUser);

            _userRepositoryMock.Verify(repo => repo.Add(It.IsAny<PrincipalUser>()), Times.Once);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_userController.GetAllUsers), createdResult.ActionName);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnOkWithListOfUsers()
        {
            var users = new List<PrincipalUser> { _validUser };
            _userRepositoryMock.Setup(repo => repo.GetAll()).Returns(users);

            var result = _userController.GetAllUsers();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsType<List<PrincipalUser>>(okResult.Value);
            Assert.Single(returnedUsers);
        }

        [Fact]
        public void PutUser_ShouldUpdateUserAndReturnOk()
        {
            var result = _userController.PutUser(_validUser);

            _userRepositoryMock.Verify(repo => repo.Update(It.IsAny<PrincipalUser>()), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(_validUser, okResult.Value);
        }

        [Fact]
        public void PutUser_ShouldReturnBadRequest_WhenUserIdIsNull()
        {
            var invalidUser = new PrincipalUser
            {
                IdUsua = 0, // Simulating invalid ID
                NomeUsua = "Invalid User"
            };

            var result = _userController.PutUser(invalidUser);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteUser_ShouldDeleteUserAndReturnOk()
        {
            _userRepositoryMock.Setup(repo => repo.Delete(It.IsAny<PrincipalUser>()));

            var result = _userController.DeleteUser(_validUser);

            _userRepositoryMock.Verify(repo => repo.Delete(It.IsAny<PrincipalUser>()), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}
