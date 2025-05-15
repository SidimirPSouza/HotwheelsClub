using HotwheelsClub.Data;
using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Repository
{
    public class HotwheelsRepository : IHotwheelsRepository
    {
        public readonly HotwheelsClubDBContext _DbContext;
        public HotwheelsRepository(HotwheelsClubDBContext hotwheelsClubDBContext) 
        {
            _DbContext = hotwheelsClubDBContext;
        }
        public async Task<List<HotwheelsModel>> GetAllHotwheels()
        {
            return await _DbContext.Hotwheels
            .Include(x => x.Proprietor)
            .ToListAsync();
        }

        public async Task<HotwheelsModel> GetById(int id)
        {
            return await _DbContext.Hotwheels.Include(x => x.Proprietor).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<HotwheelsModel> Add(HotwheelsModel hotwheels)
        {
            await _DbContext.Hotwheels.AddAsync(hotwheels);
            await _DbContext.SaveChangesAsync();

            return hotwheels;
        }

        public async Task<HotwheelsModel> Update(HotwheelsModel hotwheels, int id)
        {
            HotwheelsModel hotwheelsId = await GetById(id);
            if (hotwheelsId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            hotwheelsId.Name = hotwheels.Name;
            hotwheelsId.Year = hotwheels.Year;
            hotwheelsId.Color = hotwheels.Color;
            hotwheelsId.Model = hotwheels.Model;
            hotwheelsId.Price = hotwheels.Price;
            hotwheelsId.ProprietorId = hotwheels.ProprietorId;

            

            _DbContext.Hotwheels.Update(hotwheelsId);
            await _DbContext.SaveChangesAsync();
            return hotwheels;
        }

        public async Task<bool> DeleteById(int id)
        {
            HotwheelsModel hotwheelsId = await GetById(id);
            if(hotwheelsId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            _DbContext.Remove(hotwheelsId);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}
