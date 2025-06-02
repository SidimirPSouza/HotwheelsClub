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
    public class HotwheelsServiceTests
    {

        [Fact]
        public async Task GetHotwheelsAsync_ShouldReturnHotwheels_WhenHotwheelsExists()
        {
            // Arrange
            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(new Repository.Entity.HotwheelsEntity
                    {
                        Id = 1,
                        Name = "skyline",
                        Model = "r34",
                        Price = 100,
                        Color = "prata",
                        Year = 1998,
                        ProprietorId = 3 
                    });

            var service = new HotwheelsService(mockRepo.Object);

            // Act
            var result = await service.GetHotwheelsByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("skyline", result.Name);
            Assert.Equal("r34", result.Model);
            Assert.Equal(100, result.Price);
            Assert.Equal("prata", result.Color);
            Assert.Equal(3, result.ProprietorId);
        }

        [Fact]
        public async Task GetHotwheelsAsync_ShouldThrowException_WhenHotwheelsDoesNotExist()
        {
            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((HotwheelsEntity)null);

            var service = new HotwheelsService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(() => service.GetHotwheelsByIdAsync(999));
        }

        [Fact]
        public async Task GetAllHotwheelsAsync_ShouldReturnHotwheels_WhenHotwheelsExists()
        {
            // Arrange
            var hotwheelsEntities = new List<HotwheelsEntity>
        {
            new HotwheelsEntity { Id = 1, Name = "skyline", Model = "r34", Price = 100, Color = "prata", Year = 1998, ProprietorId = 3  },
            new HotwheelsEntity { Id = 2, Name = "Mustang", Model = "Shelby", Price = 200, Color = "Preto", Year = 2023, ProprietorId = 2 }
        };

            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(hotwheelsEntities);

            var service = new HotwheelsService(mockRepo.Object);

            // Act
            var result = await service.GetAllHotwheelsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            Assert.NotNull(result);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("skyline", result[0].Name);
            Assert.Equal("r34", result[0].Model);
            Assert.Equal(100, result[0].Price);
            Assert.Equal("prata", result[0].Color);
            Assert.Equal(3, result[0].ProprietorId);

            Assert.NotNull(result);
            Assert.Equal(2, result[1].Id);
            Assert.Equal("Mustang", result[1].Name);
            Assert.Equal("Shelby", result[1].Model);
            Assert.Equal(200, result[1].Price);
            Assert.Equal("Preto", result[1].Color);
            Assert.Equal(2, result[1].ProprietorId);
        }

        [Fact]
        public async Task GetAllHotwheelsAsync_ShouldReturnEmptyList_WhenNoHotwheelsExist()
        {
            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<HotwheelsEntity>());

            var service = new HotwheelsService(mockRepo.Object);

            var result = await service.GetAllHotwheelsAsync();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task AddHotwheelsAsync_ShouldReturnHotwheels_WhenHotwheelsExists()
        {
            // Arrange
            var newEntity = new HotwheelsEntity
            {
                Id = 1,
                Name = "skyline",
                Model = "r34",
                Price = 100,
                Color = "prata",
                Year = 1998,
                ProprietorId = 3
            };

            var newModel = new HotwheelsModel
            {
                Id = 1,
                Name = "skyline",
                Model = "r34",
                Price = 100,
                Color = "prata",
                Year = 1998,
                ProprietorId = 3
            };

            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(repo => repo.AddAsync(newEntity)).ReturnsAsync(newEntity);

            var service = new HotwheelsService(mockRepo.Object);

            // Act
            var result = await service.AddHotwheelsAsync(newModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("skyline", result.Name);
            Assert.Equal("r34", result.Model);
            Assert.Equal(100, result.Price);
            Assert.Equal("prata", result.Color);
            Assert.Equal(3, result.ProprietorId);
        }

        [Fact]
        public async Task AddHotwheelsAsync_ShouldThrowException_WhenRepositoryFails()
        {
            var newModel = new HotwheelsModel
            {
                Id = 1,
                Name = "Invalid",
                Model = "Invalid",
                Price = 0,
                Color = "Invalid",
                Year = 0000,
                ProprietorId = 0
            };

            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<HotwheelsEntity>())).ThrowsAsync(new Exception("Erro no banco"));

            var service = new HotwheelsService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(() => service.AddHotwheelsAsync(newModel));
        }

        [Fact]
        public async Task UpdateHotwheelsAsync_ShouldUpdateAndReturnUpdatedModel_WhenHotwheelsExists()
        {
            // Arrange
            var existingEntity = new HotwheelsEntity
            {
                Id = 1,
                Name = "skyline",
                Model = "r34",
                Price = 100,
                Color = "prata",
                Year = 1998,
                ProprietorId = 3
            };

            var updatedModel = new HotwheelsModel
            {
                Id = 1,
                Name = "Mustang",
                Model = "Shelby",
                Price = 200,
                Color = "Preto",
                Year = 2023,
                ProprietorId = 2
            };

            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingEntity);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<HotwheelsEntity>())).ReturnsAsync(existingEntity);

            var service = new HotwheelsService(mockRepo.Object);

            // Act
            var result = await service.UpdateHotwheelsAsync(updatedModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Mustang", result.Name);
            Assert.Equal("Shelby", result.Model);
            Assert.Equal(200, result.Price);
            Assert.Equal("Preto", result.Color);
            Assert.Equal(2, result.ProprietorId);
        }

        [Fact]
        public async Task UpdateHotwheelsAsync_ShouldThrowException_WhenHotwheelsDoesNotExist()
        {
            var mockRepo = new Mock<IHotwheelsRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((HotwheelsEntity)null);

            var service = new HotwheelsService(mockRepo.Object);

            var model = new HotwheelsModel { Id = 1, Name = "X", Model = "Y", Price = 1, Color = "Z", Year = 1, ProprietorId = 1 };

            await Assert.ThrowsAsync<Exception>(() => service.UpdateHotwheelsAsync(model));
        }

        [Fact]

        public async Task DeleteHotwheelsById_ShouldReturnTrue_WhenDeleteSucceeds()
        {
            // Arrange
            var mockRepo = new Mock<IHotwheelsRepository>();
            int hotwheelsId = 1;

            // Configura o mock para retornar true ao deletar
            mockRepo.Setup(r => r.DeleteByIdAsync(hotwheelsId)).ReturnsAsync(true);

            var service = new HotwheelsService(mockRepo.Object);

            // Act
            var result = await service.DeleteHotwheelsById(hotwheelsId);

            // Assert
            Assert.True(result);

            // Verifica se o método DeleteByIdAsync foi chamado exatamente uma vez com o id correto
            mockRepo.Verify(r => r.DeleteByIdAsync(hotwheelsId), Times.Once);
        }

        [Fact]
        public async Task DeleteHotwheelsById_ShouldReturnFalse_WhenDeleteFails()
        {
            // Arrange
            var mockRepo = new Mock<IHotwheelsRepository>();
            int hotwheelsId = 999; // id que não existe

            mockRepo.Setup(r => r.DeleteByIdAsync(hotwheelsId)).ReturnsAsync(false);

            var service = new HotwheelsService(mockRepo.Object);

            // Act
            var result = await service.DeleteHotwheelsById(hotwheelsId);

            // Assert
            Assert.False(result);
            mockRepo.Verify(r => r.DeleteByIdAsync(hotwheelsId), Times.Once);
        }

    }
}
