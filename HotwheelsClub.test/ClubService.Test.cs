using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service;
using HotwheelsClub.Service.Models;
using Moq;

namespace HotwheelsClub.Test
{
    public class ClubServiceTests
    {
        [Fact]
        public async Task GetClubAsync_ShouldReturnClub_WhenClubExists()
        {
            // Arrange
            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(new Repository.Entity.ClubEntity 
                    { 
                        Id = 1,
                        Name = "Hot Wheels Club",
                        Description = "Clube de colecionadores",
                        ProprietorId = 42
                    });

            var service = new ClubService(mockRepo.Object);

            // Act
            var result = await service.GetClubByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Hot Wheels Club", result.Name);
            Assert.Equal("Clube de colecionadores", result.Description);
            Assert.Equal(42, result.ProprietorId);
        }

        [Fact]
        public async Task GetClubAsync_ShouldThrowException_WhenClubDoesNotExist()
        {
            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((ClubEntity)null);

            var service = new ClubService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(() => service.GetClubByIdAsync(999));
        }

        [Fact]
        public async Task GetAllClubAsync_ShouldReturnClub_WhenClubExists()
        {
            // Arrange
            var clubEntities = new List<ClubEntity>
        {
            new ClubEntity { Id = 1, Name = "Hot Wheels Club", Description = "Clube 1", ProprietorId = 101 },
            new ClubEntity { Id = 2, Name = "Speed Masters", Description = "Clube 2", ProprietorId = 102 }
        };

            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(clubEntities);

            var service = new ClubService(mockRepo.Object);

            // Act
            var result = await service.GetAllClubsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            Assert.Equal(1, result[0].Id);
            Assert.Equal("Hot Wheels Club", result[0].Name);
            Assert.Equal("Clube 1", result[0].Description);
            Assert.Equal(101, result[0].ProprietorId);

            Assert.Equal(2, result[1].Id);
            Assert.Equal("Speed Masters", result[1].Name);
            Assert.Equal("Clube 2", result[1].Description);
            Assert.Equal(102, result[1].ProprietorId);
        }

        [Fact]
        public async Task GetAllClubAsync_ShouldReturnEmptyList_WhenNoClubsExist()
        {
            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<ClubEntity>());

            var service = new ClubService(mockRepo.Object);

            var result = await service.GetAllClubsAsync();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task AddClubAsync_ShouldReturnClub_WhenClubExists()
        {
            // Arrange
            var newEntity = new ClubEntity
            {
                Id = 1,
                Name = "Old Name",
                Description = "Old Desc",
                ProprietorId = 100
            };

            var newModel = new ClubModel
            {
                Id = 1,
                Name = "Old Name",
                Description = "Old Desc",
                ProprietorId = 100
            };

            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(repo => repo.AddAsync(newEntity)).ReturnsAsync(newEntity);

            var service = new ClubService(mockRepo.Object);

            // Act
            var result = await service.AddClubAsync(newModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Old Name", result.Name);
            Assert.Equal("Old Desc", result.Description);
            Assert.Equal(100, result.ProprietorId);
        }

        [Fact]
        public async Task AddClubAsync_ShouldThrowException_WhenRepositoryFails()
        {
            var newModel = new ClubModel
            {
                Id = 1,
                Name = "Invalid",
                Description = "Invalid",
                ProprietorId = 0
            };

            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<ClubEntity>())).ThrowsAsync(new Exception("Erro no banco"));

            var service = new ClubService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(() => service.AddClubAsync(newModel));
        }

        [Fact]
        public async Task UpdateClubAsync_ShouldUpdateAndReturnUpdatedModel_WhenClubExists()
        {
            // Arrange
            var existingEntity = new ClubEntity
            {
                Id = 1,
                Name = "Old Name",
                Description = "Old Desc",
                ProprietorId = 100
            };

            var updatedModel = new ClubModel
            {
                Id = 1,
                Name = "New Name",
                Description = "New Desc",
                ProprietorId = 200
            };

            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingEntity);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<ClubEntity>())).ReturnsAsync(existingEntity);

            var service = new ClubService(mockRepo.Object);

            // Act
            var result = await service.UpdateClubAsync(updatedModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("New Name", result.Name);
            Assert.Equal("New Desc", result.Description);
            Assert.Equal(200, result.ProprietorId);
        }

        [Fact]
        public async Task UpdateClubAsync_ShouldThrowException_WhenClubDoesNotExist()
        {
            var mockRepo = new Mock<IClubRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((ClubEntity)null);

            var service = new ClubService(mockRepo.Object);

            var model = new ClubModel { Id = 1, Name = "X", Description = "Y", ProprietorId = 1 };

            await Assert.ThrowsAsync<Exception>(() => service.UpdateClubAsync(model));
        }

        [Fact]

        public async Task DeleteClubById_ShouldReturnTrue_WhenDeleteSucceeds()
        {
            // Arrange
            var mockRepo = new Mock<IClubRepository>();
            int clubId = 1;

            // Configura o mock para retornar true ao deletar
            mockRepo.Setup(r => r.DeleteByIdAsync(clubId)).ReturnsAsync(true);

            var service = new ClubService(mockRepo.Object);

            // Act
            var result = await service.DeleteClubById(clubId);

            // Assert
            Assert.True(result);

            // Verifica se o método DeleteByIdAsync foi chamado exatamente uma vez com o id correto
            mockRepo.Verify(r => r.DeleteByIdAsync(clubId), Times.Once);
        }

        [Fact]
        public async Task DeleteClubById_ShouldReturnFalse_WhenDeleteFails()
        {
            // Arrange
            var mockRepo = new Mock<IClubRepository>();
            int clubId = 999; // id que não existe

            mockRepo.Setup(r => r.DeleteByIdAsync(clubId)).ReturnsAsync(false);

            var service = new ClubService(mockRepo.Object);

            // Act
            var result = await service.DeleteClubById(clubId);

            // Assert
            Assert.False(result);
            mockRepo.Verify(r => r.DeleteByIdAsync(clubId), Times.Once);
        }
    }
}
