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
    public class TransferControllerTest
    {
        private readonly Mock<ITransferService> _mockService;
        private readonly TransferController _controller;

        public TransferControllerTest()
        {
            _mockService = new Mock<ITransferService>();
            _controller = new TransferController(_mockService.Object);
        }

        [Fact]
        public async Task TransferHotwheelsAsync_ShouldReturnUpdated()
        {
            // Arrange
            var inputDto = new HotwheelsTransferDto { hotwheelsId = 1, ProprietorId = 2 };
            var model = new HotwheelsModel { Id = 1, Name = "Civic", Color = "Silver", ProprietorId = 4 };

            _mockService.Setup(s => s.TransferHotwheelsAsync(It.IsAny<HotwheelsTransferModel>())).ReturnsAsync(model);

            // Act
            var result = await _controller.TransferHotwheelsAsync(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HotwheelsDto>(okResult.Value);
            Assert.Equal(4, returnValue.ProprietorId);
        }

        [Fact]
        public async Task TransferUserAsync_ShouldReturnUpdated()
        {
            //Arrange
            var inputDto = new UserTransferDto { UserId = 1, ClubId = 1 };
            var model = new UserModel { Id = 1 , Name = "Anderson", ClubId = 3, MonthlyFees = true };

            _mockService.Setup(s => s.TransferUserAsync(It.IsAny<UserTransferModel>())).ReturnsAsync(model);

            // Act
            var result = await _controller.TransferUserAsync(inputDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(3, returnValue.ClubId);
        }


}
}
