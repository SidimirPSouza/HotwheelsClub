using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;

public class HotwheelsService : IHotwheelsService
{
    private readonly IHotwheelsRepository _hotwheelsRepository;
    public HotwheelsService(IHotwheelsRepository hotwheelsRepository)
    {
       _hotwheelsRepository = hotwheelsRepository;
    }
    public Task<List<HotwheelsModel>> GetAllHotwheels()
    {
        return _hotwheelsRepository.GetAllHotwheels();
    }

    public Task<HotwheelsModel> GetById(int id)
    {
        return _hotwheelsRepository.GetById(id);
    }
    
    public Task<HotwheelsModel> Add(HotwheelsModel hotwheels)
    {
        return _hotwheelsRepository.Add(hotwheels);
    }

    public Task<HotwheelsModel> Update(HotwheelsModel hotwheels, int id)
    {
        return _hotwheelsRepository.Update(hotwheels, id);
    }

    public Task<bool> DeleteById(int id)
    {
        return _hotwheelsRepository.DeleteById(id);
    }
}
