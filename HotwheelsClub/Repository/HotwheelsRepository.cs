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
                .Include(x => x.Dono)
                .ToListAsync();
        }

        public async Task<HotwheelsModel> GetById(int id)
        {
            return await _DbContext.Hotwheels
                .Include(x => x.Dono)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<HotwheelsModel> Add(HotwheelsModel hotwheels)
        {
            await _DbContext.Hotwheels.AddAsync(hotwheels);
            _DbContext.SaveChanges();

            return hotwheels;
        }

        public async Task<HotwheelsModel> Update(HotwheelsModel hotwheels, int id)
        {
            HotwheelsModel HotwheelsId = await GetById(id);
            if (HotwheelsId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            HotwheelsId.Ano = hotwheels.Ano;
            HotwheelsId.Name = hotwheels.Name;
            HotwheelsId.preco = hotwheels.preco;
            HotwheelsId.Modelo = hotwheels.Modelo;
            HotwheelsId.Cor = hotwheels.Cor;

            _DbContext.Hotwheels.Update(HotwheelsId);
            await _DbContext.SaveChangesAsync();
            return hotwheels;
        }

        public async Task<bool> DeleteById(int id)
        {
            HotwheelsModel HotwheelsId = await GetById(id);
            if(HotwheelsId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            _DbContext.Remove(HotwheelsId);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}
