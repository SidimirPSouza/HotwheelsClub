using HotwheelsClub.Service.Dto;
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
        public async Task<ActionResult<UserDto>> TransferUserAsync([FromBody]UserTransferDto dto)
        {
            UserTransferModel userModel = Mappers.TransferMapper.TransferUserMapDtoToModel(dto);
            try
            {
                var result = await _transferService.TransferUserAsync(userModel);
                if (result == null)
                    return NotFound();
                UserDto userDto = Mappers.TransferMapper.TransferUserMapModelToDto(result);
                return Ok(userDto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

        }

        [HttpPost("/TransferHotwheels")]
        public async Task<ActionResult<HotwheelsDto>> TransferHotwheelsAsync([FromBody]HotwheelsTransferDto dto)
        {
            HotwheelsTransferModel hotwheelsModel = Mappers.TransferMapper.TransferHotwheelsMapDtoToModel(dto);
            var result = await _transferService.TransferHotwheelsAsync(hotwheelsModel);
            if (result == null)
                return NotFound();
            HotwheelsDto hotwheelsDto = Mappers.TransferMapper.TransferHotwheelsMapModelToDto(result);
            return Ok(hotwheelsDto);
        }

        
    }
}
