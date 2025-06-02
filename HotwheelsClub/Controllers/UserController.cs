using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotwheelsClub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserCompleteDto>>> SearchAllUserAsync()
        {
            List<UserModel> user = await _userService.GetAllUserAsync();
            return Ok(Mappers.UserMapper.UserMapModelToListDto(user));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCompleteDto>> SearchUserForIdAsync(int id)
        {
            UserModel user = await _userService.GetUserByIdAsync(id);
            UserCompleteDto userDto = Mappers.UserMapper.UserMapModelToCompleteDto(user);
            return Ok(userDto);
        }

        

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUserAsync([FromBody] UserRequestDto dto)
        {
            UserModel user = Mappers.UserMapper.UserMapRequestDtoToModel(dto);

            var created = await _userService.AddUserAsync(user);
            UserDto userDto = Mappers.UserMapper.UserMapModelToDto(created);
            return Ok(userDto);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUserAsync([FromBody]UserUpdateDto dto)
        {
            UserModel user = Mappers.UserMapper.UserMapUpdateDtoToModel(dto);

            var created = await _userService.UpdateUserAsync(user);
            UserDto userDto = Mappers.UserMapper.UserMapUpdateModeTolDto(created);
            return Ok(userDto);
        }

        

        [HttpDelete]
        public async Task<ActionResult<UserCompleteDto>> DeleteUserAsync(int id)
        {
            bool delete = await _userService.DeleteUserById(id);
            return Ok(delete);
        }
    }
}
