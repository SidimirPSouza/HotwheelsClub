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
    public class UserServiceTests
    {

        [Fact]
        public async Task GetUserAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(new Repository.Entity.UserEntity
                    {
                        Id = 1,
                        Name = "Brian",
                        ClubId = 1,
                        MonthlyFees = true,
                    });

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.GetUserByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Brian", result.Name);
            Assert.Equal(1, result.ClubId);
            Assert.True(result.MonthlyFees);
        }

        [Fact]
        public async Task GetUserAsync_ShouldThrowException_WhenUserDoesNotExist()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((UserEntity)null);

            var service = new UserService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(() => service.GetUserByIdAsync(999));
        }

        [Fact]
        public async Task GetAllUserAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userEntities = new List<UserEntity>
        {
            new UserEntity { Id = 1, Name = "Brian", ClubId = 1, MonthlyFees = true,  },
            new UserEntity { Id = 2, Name = "Toretto", ClubId = 2, MonthlyFees = false, }
        };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(userEntities);

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.GetAllUserAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            Assert.NotNull(result);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Brian", result[0].Name);
            Assert.Equal(1, result[0].ClubId);
            Assert.True(result[0].MonthlyFees);

            Assert.NotNull(result);
            Assert.Equal(2, result[1].Id);
            Assert.Equal("Toretto", result[1].Name);
            Assert.Equal(2, result[1].ClubId);
            Assert.False(result[1].MonthlyFees);
        }

        [Fact]
        public async Task GetAllUserAsync_ShouldReturnEmptyList_WhenNoUserExist()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<UserEntity>());

            var service = new UserService(mockRepo.Object);

            var result = await service.GetAllUserAsync();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task AddUserAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var newEntity = new UserEntity
            {
                Id = 1,
                Name = "Brian",
                ClubId = 1,
                MonthlyFees = true,
            };

            var newModel = new UserModel
            {
                Id = 1,
                Name = "Brian",
                ClubId = 1,
                MonthlyFees = true,
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.AddAsync(newEntity)).ReturnsAsync(newEntity);

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.AddUserAsync(newModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Brian", result.Name);
            Assert.Equal(1, result.ClubId);
            Assert.True(result.MonthlyFees);
        }

        [Fact]
        public async Task AddUserAsync_ShouldThrowException_WhenRepositoryFails()
        {
            var newModel = new UserModel
            {
                Id = 1,
                Name = "Brian",
                ClubId = 1,
                MonthlyFees = true,
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<UserEntity>())).ThrowsAsync(new Exception("Erro no banco"));

            var service = new UserService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(() => service.AddUserAsync(newModel));
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldUpdateAndReturnUpdatedModel_WhenUserExists()
        {
            // Arrange
            var existingEntity = new UserEntity
            {
                Id = 1,
                Name = "Brian",
                ClubId = 1,
                MonthlyFees = true,
            };

            var updatedModel = new UserModel
            {
                Id = 1,
                Name = "Toretto",
                ClubId = 2,
                MonthlyFees = false,
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingEntity);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<UserEntity>())).ReturnsAsync(existingEntity);

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.UpdateUserAsync(updatedModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Toretto", result.Name);
            Assert.Equal(2, result.ClubId);
            Assert.False(result.MonthlyFees);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldThrowException_WhenUserDoesNotExist()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((UserEntity)null);

            var service = new UserService(mockRepo.Object);

            var model = new UserModel { Id = 1, Name = "X", ClubId = 1, MonthlyFees = true, };

            await Assert.ThrowsAsync<Exception>(() => service.UpdateUserAsync(model));
        }

        [Fact]

        public async Task DeleteUserById_ShouldReturnTrue_WhenDeleteSucceeds()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            int userId = 1;

            // Configura o mock para retornar true ao deletar
            mockRepo.Setup(r => r.DeleteByIdAsync(userId)).ReturnsAsync(true);

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.DeleteUserById(userId);

            // Assert
            Assert.True(result);

            // Verifica se o método DeleteByIdAsync foi chamado exatamente uma vez com o id correto
            mockRepo.Verify(r => r.DeleteByIdAsync(userId), Times.Once);
        }

        [Fact]
        public async Task DeleteUserById_ShouldReturnFalse_WhenDeleteFails()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            int userId = 999; // id que não existe

            mockRepo.Setup(r => r.DeleteByIdAsync(userId)).ReturnsAsync(false);

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.DeleteUserById(userId);

            // Assert
            Assert.False(result);
            mockRepo.Verify(r => r.DeleteByIdAsync(userId), Times.Once);
        }

    }
}
