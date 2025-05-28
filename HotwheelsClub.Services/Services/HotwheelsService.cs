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
        public async Task<List<HotwheelsModel>> GetAllHotwheels()
        {
            var hotwheelsEntity = await _hotwheelsRepository.GetAll();
            var hotwheelsModel = new List<HotwheelsModel>();
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

        public async Task<HotwheelsModel> GetById(int id)
        {
            var hotwheelsEntity = await _hotwheelsRepository.GetById(id);
            var hotwheelsModel = new HotwheelsModel();
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
    
        public async Task<HotwheelsModel> Add(HotwheelsModel hotwheels)
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

            var created = await _hotwheelsRepository.Add(hotwheelsEntity);
            return hotwheels;
        }

        public async Task<HotwheelsModel> Update(HotwheelsModel hotwheels)
        {
            var hotwheelsEntity = await _hotwheelsRepository.GetById(hotwheels.Id);
            if (hotwheelsEntity == null)
                throw new Exception($"Hotwheels com o ID: {hotwheels.Id} não foi encontrada no banco de dados");
            hotwheelsEntity.Id = hotwheels.Id;
            hotwheelsEntity.Name = hotwheels.Name;
            hotwheelsEntity.Color = hotwheels.Color;
            hotwheelsEntity.Price = hotwheels.Price;
            hotwheelsEntity.Model = hotwheels.Model;
            hotwheelsEntity.Year = hotwheels.Year;
            await _hotwheelsRepository.Update(hotwheelsEntity);
            return hotwheels;
        }

        public Task<bool> DeleteById(int id)
        {
            return _hotwheelsRepository.DeleteById(id);
        }
    }
}