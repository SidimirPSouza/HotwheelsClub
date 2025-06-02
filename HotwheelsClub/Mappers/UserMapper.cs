using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Mappers
{
    public class UserMapper
    {
        public static List<UserCompleteDto> UserMapModelToListDto(List<UserModel> user)
        {
            return user.Select(item => new UserCompleteDto
            {
                Id = item.Id,
                Name = item.Name,
                MonthlyFees = item.MonthlyFees,
                ClubId = item.ClubId,
            }).ToList();
        }

        public static UserCompleteDto UserMapModelToCompleteDto(UserModel user)
        {
            return new UserCompleteDto
            {
                Id = user.Id,
                Name = user.Name,
                MonthlyFees = user.MonthlyFees,
                ClubId = user.ClubId,
            };
        }
        public static UserModel UserMapRequestDtoToModel(UserRequestDto dto)
        {
            return new UserModel
            {

                Name = dto.Name,
                MonthlyFees = dto.MonthlyFees,

            };
        }
        public static UserDto UserMapModelToDto(UserModel created)
        {
            return new UserDto
            {
                Name = created.Name,
                MonthlyFees = created.MonthlyFees,
            };
        }

        public static UserDto UserMapUpdateModeTolDto(UserModel created)
        {
            return new UserDto
            {
                Id = created.Id,
                Name = created.Name,
                MonthlyFees = created.MonthlyFees,
                ClubId = created.ClubId,
            };
        }

        public static UserModel UserMapUpdateDtoToModel(UserUpdateDto dto)
        {
            return new UserModel
            {
                Id = dto.Id,
                Name = dto.Name,
                MonthlyFees = dto.MonthlyFees,
                ClubId = dto.ClubId,
            };
        }
    }
}
