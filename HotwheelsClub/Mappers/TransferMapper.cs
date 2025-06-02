using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Mappers
{
    public class TransferMapper
    {
        public static UserTransferModel TransferUserMapDtoToModel(UserTransferDto dto)
        {
            return new UserTransferModel
            {
                Id = dto.UserId,
                ClubId = dto.ClubId,
            };
        }
        public static UserDto TransferUserMapModelToDto(UserModel result)
        {
            return new UserDto
            {
                Id = result.Id,
                ClubId = result.ClubId,
            };
        }

        public static HotwheelsDto TransferHotwheelsMapModelToDto(HotwheelsModel result)
        {
            return new HotwheelsDto
            {
                Id = result.Id,
                ProprietorId = result.ProprietorId,
            };
        }

        public static HotwheelsTransferModel TransferHotwheelsMapDtoToModel(HotwheelsTransferDto dto)
        {
            return new HotwheelsTransferModel
            {
                Id = dto.hotwheelsId,
                ProprietorId = dto.ProprietorId,
            };
        }
    }
}
