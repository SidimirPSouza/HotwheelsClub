using HotwheelsClub.Models;
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
        public async Task<ActionResult<List<UserCompleteDto>>> SearchAllUser()
        {
            List<UserModel> user = await _userService.GetAllUser();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCompleteDto>> SearchForId(int id)
        {
             UserModel user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Add([FromBody] UserRequestDto dto)
        {
            var hotwheels = new UserModel
            {

            Name = dto.Name,
            MonthlyFees = dto.MonthlyFees,
                
            };

            var created = await _userService.Add(hotwheels);
            return Ok(created);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Update([FromBody]UserUpdateDto dto)
        {
            var user = new UserModel
            {
                Id = dto.Id,
                Name = dto.Name,
                MonthlyFees = dto.MonthlyFees,
                ClubId = dto.ClubId,
            };
                var created = await _userService.Update(user);
            return Ok(created);
        }

        [HttpDelete]
        public async Task<ActionResult<UserCompleteDto>> Delete(int id)
        {
            bool delete = await _userService.DeleteById(id);
            return Ok(delete);
        }
    }
}
