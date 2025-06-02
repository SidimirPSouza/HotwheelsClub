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
    public class ClubControllerTest
    {
        private readonly Mock<IClubService> _mockService;
        private readonly ClubController _controller;

        public ClubControllerTest()
        {
            _mockService = new Mock<IClubService>();
            _controller = new ClubController(_mockService.Object);
        }

        [Fact]
        public async Task SearchAllClubsAsync_ShouldReturnListOfClubs()
        {
            // Arrange
            var mockClubs = new List<ClubModel>
        {
            new ClubModel { Id = 1, Name = "A", Description = "Desc A", ProprietorId = 10 },
            new ClubModel { Id = 2, Name = "B", Description = "Desc B", ProprietorId = 20 }
        };
            _mockService.Setup(s => s.GetAllClubsAsync()).ReturnsAsync(mockClubs);

            // Act
            var result = await _controller.SearchAllClubsAsync();

            // Assert
            var okResult = Assert.IsType<ActionResult<List<ClubDto>>>(result);
            Assert.NotNull(okResult.Value);
            Assert.Equal(2, okResult.Value.Count);
        }

        [Fact]
        public async Task SearchClubForId_ShouldReturnClub_WhenExists()
        {
            var club = new ClubModel { Id = 1, Name = "Test", Description = "Desc", ProprietorId = 99 };
            _mockService.Setup(s => s.GetClubByIdAsync(1)).ReturnsAsync(club);

            var result = await _controller.SearchClubForId(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var dto = Assert.IsType<ClubDto>(okResult.Value);
            Assert.Equal(1, dto.Id);
        }

        [Fact]
        public async Task AddClubAsync_ShouldReturnCreatedClub()
        {
            var input = new ClubDto { Id = 1, Name = "New", Description = "Desc", ProprietorId = 1 };
            var model = new ClubModel { Id = 1, Name = "New", Description = "Desc", ProprietorId = 1 };

            _mockService.Setup(s => s.AddClubAsync(It.IsAny<ClubModel>())).ReturnsAsync(model);

            var result = await _controller.AddClubAsync(input);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedDto = Assert.IsType<ClubDto>(okResult.Value);
            Assert.Equal("New", returnedDto.Name);
        }

        [Fact]
        public async Task UpdateClubAsync_ShouldReturnUpdatedClub()
        {
            var input = new ClubDto { Id = 1, Name = "Updated", Description = "New Desc", ProprietorId = 10 };
            var updatedModel = new ClubModel { Id = 1, Name = "Updated", Description = "New Desc", ProprietorId = 10 };

            _mockService.Setup(s => s.UpdateClubAsync(It.IsAny<ClubModel>())).ReturnsAsync(updatedModel);

            var result = await _controller.UpdateClubAsync(input);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedDto = Assert.IsType<ClubDto>(okResult.Value);
            Assert.Equal("Updated", returnedDto.Name);
        }

        [Fact]
        public async Task DeleteClubAsync_ShouldReturnOkResult()
        {
            int id = 1;
            _mockService.Setup(s => s.DeleteClubById(id)).ReturnsAsync(true);

            var result = await _controller.DeleteClubAsync(id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }
    }
}
