using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotwheelsClub.Mappers
{
    public class ClubMappers
    {
        public static ClubDto MapModelToDto(ClubModel model)
        {
            return new ClubDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ProprietorId = model.ProprietorId,
                Proprietor = model.Proprietor,
                Members = model.Members
            };
        }

        public static ClubModel MapDtoToModel(ClubDto dto)
        {
            return new ClubModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ProprietorId = dto.ProprietorId,
                Proprietor = dto.Proprietor,
                Members = dto.Members,
            };
        }

        public static ActionResult<List<ClubDto>> MapListModelToDto(List<ClubModel> club)
        {
            return club.Select(item => new ClubDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ProprietorId = item.ProprietorId,
                Proprietor = item.Proprietor,
                Members = item.Members,
            }).ToList();
        }
    }

}
