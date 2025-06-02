using HotwheelsClub.Repository;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service
{ 
    public class HotwheelsService : IHotwheelsService
    {
        private readonly IHotwheelsRepository _hotwheelsRepository;
        public HotwheelsService(IHotwheelsRepository hotwheelsRepository)
        {
           _hotwheelsRepository = hotwheelsRepository;
        }
        public async Task<List<HotwheelsModel>> GetAllHotwheelsAsync()
        {
            var hotwheelsEntity = await _hotwheelsRepository.GetAllAsync();
            if (hotwheelsEntity == null)
                throw new Exception($"Nenhum hotwheels foi encontrado no banco de dados");
            return hotwheelsEntity.Select(item =>
                           new HotwheelsModel
                           {
                               Id = item.Id,
                               Name = item.Name,
                               ProprietorId = item.ProprietorId,
                               Color = item.Color,
                               Price = item.Price,
                               Model = item.Model,
                               Year = item.Year,
                           }).ToList();
        }

        public async Task<HotwheelsModel> GetHotwheelsByIdAsync(int id)
        {
            var hotwheelsEntity = await _hotwheelsRepository.GetByIdAsync(id);
            if (hotwheelsEntity == null)
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            return new HotwheelsModel
            {
                Id = hotwheelsEntity.Id,
                Name = hotwheelsEntity.Name,
                ProprietorId = hotwheelsEntity.ProprietorId,
                Color = hotwheelsEntity.Color,
                Price = hotwheelsEntity.Price,
                Model = hotwheelsEntity.Model,
                Year = hotwheelsEntity.Year,
            };
        }
    
        public async Task<HotwheelsModel> AddHotwheelsAsync(HotwheelsModel hotwheels)
        {
            var hotwheelsEntity = new HotwheelsEntity
            {
                Id = hotwheels.Id,
                Name = hotwheels.Name,
                ProprietorId = hotwheels.ProprietorId,
                Color = hotwheels.Color,
                Price = hotwheels.Price,
                Model = hotwheels.Model,
                Year = hotwheels.Year,
            };

            var created = await _hotwheelsRepository.AddAsync(hotwheelsEntity);
            return hotwheels;
        }

        public async Task<HotwheelsModel> UpdateHotwheelsAsync(HotwheelsModel hotwheels)
        {
            var hotwheelsEntity = await _hotwheelsRepository.GetByIdAsync(hotwheels.Id);
            if (hotwheelsEntity == null)
                throw new Exception($"Hotwheels com o ID: {hotwheels.Id} não foi encontrada no banco de dados");
            hotwheelsEntity.Id = hotwheels.Id;
            hotwheelsEntity.Name = hotwheels.Name;
            hotwheelsEntity.Color = hotwheels.Color;
            hotwheelsEntity.Price = hotwheels.Price;
            hotwheelsEntity.Model = hotwheels.Model;
            hotwheelsEntity.Year = hotwheels.Year;
            hotwheelsEntity.ProprietorId = hotwheels.ProprietorId;
            await _hotwheelsRepository.UpdateAsync(hotwheelsEntity);
            return hotwheels;
        }

        public Task<bool> DeleteHotwheelsById(int id)
        {
            return _hotwheelsRepository.DeleteByIdAsync(id);
        }
    }
}