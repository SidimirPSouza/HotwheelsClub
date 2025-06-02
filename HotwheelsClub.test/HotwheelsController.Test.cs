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
    public class HotwheelsControllerTest
    {
        private readonly Mock<IHotwheelsService> _mockService;
        private readonly HotwheelsController _controller;

        public HotwheelsControllerTest()
        {
            _mockService = new Mock<IHotwheelsService>();
            _controller = new HotwheelsController(_mockService.Object);
        }

        [Fact]
        public async Task SearchAllHotwheelsAsync_ShouldReturnList()
        {
            // Arrange
            var list = new List<HotwheelsModel>
            {
                new HotwheelsModel { Id = 1, Name = "Camaro", Color = "Red", ProprietorId = 1 }
            };
            _mockService.Setup(s => s.GetAllHotwheelsAsync()).ReturnsAsync(list);

            // Act
            var result = await _controller.SearchAllHotwheelsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<HotwheelsCompleteDto>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task SearchHotwheelsForIdAsync_ShouldReturnOne()
        {
            // Arrange
            var model = new HotwheelsModel { Id = 1, Name = "Corvette", Color = "Blue", ProprietorId = 2 };
            _mockService.Setup(s => s.GetHotwheelsByIdAsync(1)).ReturnsAsync(model);

            // Act
            var result = await _controller.SearchHotwheelsForIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HotwheelsCompleteDto>(okResult.Value);
            Assert.Equal("Corvette", returnValue.Name);
        }

        [Fact]
        public async Task AddHotwheelsAsync_ShouldReturnCreated()
        {
            // Arrange
            var inputDto = new HotwheelsCompleteDto { Name = "Mustang", Color = "Black", ProprietorId = 3 };
            var model = new HotwheelsModel { Id = 5, Name = "Mustang", Color = "Black", ProprietorId = 3 };

            _mockService.Setup(s => s.AddHotwheelsAsync(It.IsAny<HotwheelsModel>())).ReturnsAsync(model);

            // Act
            var result = await _controller.AddHotwheelsAsync(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HotwheelsCompleteDto>(okResult.Value);
            Assert.Equal("Mustang", returnValue.Name);
        }

        [Fact]
        public async Task UpdateHotwheelsAsync_ShouldReturnUpdated()
        {
            // Arrange
            var inputDto = new HotwheelsDto { Id = 1, Name = "Civic", Color = "Silver", ProprietorId = 4 };
            var model = new HotwheelsModel { Id = 1, Name = "Civic", Color = "Silver", ProprietorId = 4 };

            _mockService.Setup(s => s.UpdateHotwheelsAsync(It.IsAny<HotwheelsModel>())).ReturnsAsync(model);

            // Act
            var result = await _controller.UpdateHotwheelsAsync(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HotwheelsCompleteDto>(okResult.Value);
            Assert.Equal("Civic", returnValue.Name);
        }

        [Fact]
        public async Task DeleteHotwheelsAsync_ShouldReturnTrue()
        {
            // Arrange
            _mockService.Setup(s => s.DeleteHotwheelsById(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteHotwheelsAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}
