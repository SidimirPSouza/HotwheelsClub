using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
        public async Task<ActionResult<List<UserModel>>> SearchAllUser()
        {
            List<UserModel> user = await _userService.GetAllUser();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> SearchForId(int id)
        {
             UserModel user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Add([FromBody] UserRequestDto userDto)
        {
            UserDto user = await _userService.Add(userDto);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Update([FromBody]UserUpdateDto userDto,int id)
        {
            UserDto user = await _userService.Update(userDto, id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Transfer([FromBody]UserTransferDto userDto,int id)
        {
            UserDto user = await _userService.Transference(userDto, id);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool delete = await _userService.DeleteById(id);
            return Ok(delete);
        }
    }
}
