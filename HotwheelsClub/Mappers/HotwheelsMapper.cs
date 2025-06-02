using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Mappers
{
    public class HotwheelsMapper
    {
        public static HotwheelsModel HotwheelsMapDtoToModel(HotwheelsDto dto)
        {
            return new HotwheelsModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Model = dto.Model,
                Price = dto.Price,
                Color = dto.Color,
                Year = dto.Year,
                ProprietorId = dto.ProprietorId
            };
        }

        public static HotwheelsCompleteDto HotwheelsMapModelToDto(HotwheelsModel created)
        {
            return new HotwheelsCompleteDto
            {
                Name = created.Name,
                Model = created.Model,
                Price = created.Price,
                Color = created.Color,
                Year = created.Year,
                ProprietorId = created.ProprietorId
            };
        }

        public static HotwheelsModel HotwheelsMapCompleteDtoToModel(HotwheelsCompleteDto dto)
        {
            return new HotwheelsModel
            {
                Name = dto.Name,
                Model = dto.Model,
                Price = dto.Price,
                Color = dto.Color,
                Year = dto.Year,
                ProprietorId = dto.ProprietorId
            };
        }

        public static List<HotwheelsCompleteDto> HotwheelsMapModelToListDto(List<HotwheelsModel> hotwheels)
        {
            return hotwheels.Select(item => new HotwheelsCompleteDto
            {
                Name = item.Name,
                Model = item.Model,
                Price = item.Price,
                Color = item.Color,
                Year = item.Year,
                ProprietorId = item.ProprietorId
            }).ToList();
        }

    }
}
