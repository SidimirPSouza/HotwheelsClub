using HotwheelsClub.Models;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotwheelsClub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost("/TransferUser")]
        public async Task<ActionResult<UserDto>> TransferUser([FromBody]UserTransferDto dto)
        {
            var userModel = new UserTransferModel
            {
                Id = dto.UserId,
                ClubId = dto.ClubId,
            };
            try
            {
                var result = await _transferService.TransferUser(userModel);
            if (result == null)
                return NotFound();
            return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("/TransferHotwheels")]
        public async Task<ActionResult<HotwheelsDto>> TransferHotwheels([FromBody]HotwheelsTransferDto dto)
        {
            var hotwheelsModel = new HotwheelsTransferModel
            {
                Id = dto.hotwheelsId,
                ProprietorId = dto.ProprietorId,
            };
            var result = await _transferService.TransferHotwheels(hotwheelsModel);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
