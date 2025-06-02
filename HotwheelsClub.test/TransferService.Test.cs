using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Models;
using HotwheelsClub.Service;


namespace HotwheelsClub.Test
{
    public class TransferServiceTests
    {

        [Fact]
        public async Task TransferHotwheelsAsync_ShouldTransferHotwheels_WhenValidTransfer()
        {
            // Arrange
            var transferModel = new HotwheelsTransferModel
            {
                Id = 1,
                ProprietorId = 99 // novo dono
            };

            var hotwheelsEntity = new HotwheelsEntity
            {
                Id = 1,
                Name = "Camaro SS",
                ProprietorId = 42, // dono atual
                Color = "Amarelo",
                Model = "Muscle Car",
                Year = 2020,
                Price = 50
            };

            var mockHotwheelsRepo = new Mock<IHotwheelsRepository>();
            mockHotwheelsRepo.Setup(repo => repo.GetByIdAsync(transferModel.Id))
                             .ReturnsAsync(hotwheelsEntity);
            mockHotwheelsRepo.Setup(repo => repo.UpdateAsync(It.IsAny<HotwheelsEntity>()))
                             .ReturnsAsync(hotwheelsEntity);

            var mockUserRepo = new Mock<IUserRepository>();

            var service = new TransferService(mockHotwheelsRepo.Object, mockUserRepo.Object);

            // Act
            var result = await service.TransferHotwheelsAsync(transferModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Camaro SS", result.Name);
            Assert.Equal("Amarelo", result.Color);
            Assert.Equal("Muscle Car", result.Model);
            Assert.Equal(2020, result.Year);
            Assert.Equal(50, result.Price);
            Assert.Equal(99, result.ProprietorId); 

            mockHotwheelsRepo.Verify(r => r.UpdateAsync(It.Is<HotwheelsEntity>(h => h.ProprietorId == 99)), Times.Once);
        }

        [Fact]
        public async Task TransferUserAsync_ShouldTransferUser_WhenValidTransfer()
        {
            // Arrange
            var transferModel = new UserTransferModel
            {
                Id = 1,
                ClubId = 2,
                MonthlyFees = true
            };

            var UserEntity = new UserEntity
            {
                Id = 1,
                Name = "Dom",
                ClubId = 2,
                MonthlyFees = true
            };

            var mockHotwheelsRepo = new Mock<IUserRepository>();
            mockHotwheelsRepo.Setup(repo => repo.GetByIdAsync(transferModel.Id))
                             .ReturnsAsync(UserEntity);
            mockHotwheelsRepo.Setup(repo => repo.UpdateAsync(It.IsAny<UserEntity>()))
                             .ReturnsAsync(UserEntity);

            var mockUserRepo = new Mock<IHotwheelsRepository>();

            var service = new TransferService(mockUserRepo.Object, mockHotwheelsRepo.Object);

            // Act
            var result = await service.TransferUserAsync(transferModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Dom", result.Name);
            Assert.Equal(2, result.ClubId);
            Assert.True(result.MonthlyFees);


            mockHotwheelsRepo.Verify(r => r.UpdateAsync(It.Is<UserEntity>(h => h.ClubId == 2)), Times.Once);
        }

        //[Fact]
        //public async Task UpdateUserAsync_ShouldThrowException_WhenUserDoesNotExist()
        //{
        //    var mockRepo = new Mock<IUserRepository>();
        //    mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((UserEntity)null);

        //    var service = new UserService(mockRepo.Object);

        //    var model = new UserModel { Id = 1, Name = "X", ClubId = 1, MonthlyFees = true, };

        //    await Assert.ThrowsAsync<Exception>(() => service.UpdateUserAsync(model));

        //}

    }
}
