using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotwheelsClub.Controllers;
using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotwheelsClub.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _mockService;
        private readonly UserController _controller;

        public UserControllerTest()
        {
            _mockService = new Mock<IUserService>();
            _controller = new UserController(_mockService.Object);
        }

        [Fact]
        public async Task SearchAllUserAsync_ShouldReturnList()
        {
            // Arrange
            var list = new List<UserModel>
            {
                new UserModel { Id = 1, Name = "Anderson", ClubId = 1, MonthlyFees = true }
            };
            _mockService.Setup(s => s.GetAllUserAsync()).ReturnsAsync(list);

            // Act
            var result = await _controller.SearchAllUserAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<UserCompleteDto>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task SearchUserForIdAsync_ShouldReturnOne()
        {
            // Arrange
            var model = new UserModel { Id = 1, Name = "Anderson", ClubId = 1, MonthlyFees = true };
            _mockService.Setup(s => s.GetUserByIdAsync(1)).ReturnsAsync(model);

            // Act
            var result = await _controller.SearchUserForIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<UserCompleteDto>(okResult.Value);
            Assert.Equal("Anderson", returnValue.Name);
        }

        [Fact]
        public async Task AddUserAsync_ShouldReturnCreated()
        {
            // Arrange
            var inputDto = new UserRequestDto {Name = "Anderson", MonthlyFees = true };
            var model = new UserModel {Id = 1, Name = "Anderson", ClubId = 1, MonthlyFees = true };

            _mockService.Setup(s => s.AddUserAsync(It.IsAny<UserModel>())).ReturnsAsync(model);

            // Act
            var result = await _controller.AddUserAsync(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal("Anderson", returnValue.Name);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturnUpdated()
        {
            // Arrange
            var inputDto = new UserUpdateDto { Id = 1, Name = "Anderson", ClubId = 1, MonthlyFees = true };
            var model = new UserModel {Name = "Anderson", ClubId = 1, MonthlyFees = true };

            _mockService.Setup(s => s.UpdateUserAsync(It.IsAny<UserModel>())).ReturnsAsync(model);

            // Act
            var result = await _controller.UpdateUserAsync(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal("Anderson", returnValue.Name);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldReturnTrue()
        {
            // Arrange
            _mockService.Setup(s => s.DeleteUserById(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteUserAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}
