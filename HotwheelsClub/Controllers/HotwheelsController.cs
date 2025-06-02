using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotwheelsClub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HotwheelsController : ControllerBase
    {
        private readonly IHotwheelsService _hotwheelsService;
        public HotwheelsController(IHotwheelsService hotwheelsService)
        {
            _hotwheelsService = hotwheelsService;
        }
        [HttpGet]
        public async Task<ActionResult<List<HotwheelsCompleteDto>>> SearchAllHotwheelsAsync()
        {
            List<HotwheelsModel> hotwheels = await _hotwheelsService.GetAllHotwheelsAsync();
            return Ok(Mappers.HotwheelsMapper.HotwheelsMapModelToListDto(hotwheels));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotwheelsCompleteDto>> SearchHotwheelsForIdAsync(int id)
        {
             HotwheelsModel hotwheels = await _hotwheelsService.GetHotwheelsByIdAsync(id);
            var hotwheelsDto = Mappers.HotwheelsMapper.HotwheelsMapModelToDto(hotwheels);
            return Ok(hotwheelsDto);
        }

        [HttpPost]
        public async Task<ActionResult<HotwheelsCompleteDto>> AddHotwheelsAsync([FromBody] HotwheelsCompleteDto dto)
        {
            HotwheelsModel hotwheels = Mappers.HotwheelsMapper.HotwheelsMapCompleteDtoToModel(dto);

            var created = await _hotwheelsService.AddHotwheelsAsync(hotwheels);

            var hotwheelsDto = Mappers.HotwheelsMapper.HotwheelsMapModelToDto(created);
            return Ok(hotwheelsDto);
        }


        [HttpPut]
        public async Task<ActionResult<HotwheelsCompleteDto>> UpdateHotwheelsAsync([FromBody]HotwheelsDto dto)
        {
            HotwheelsModel hotwheels = Mappers.HotwheelsMapper.HotwheelsMapDtoToModel(dto);
            var created = await _hotwheelsService.UpdateHotwheelsAsync(hotwheels);
            HotwheelsCompleteDto hotwheelsDto = Mappers.HotwheelsMapper.HotwheelsMapModelToDto(created);
            return Ok(hotwheelsDto);
        }

        [HttpDelete]
        public async Task<ActionResult<HotwheelsCompleteDto>> DeleteHotwheelsAsync(int id)
        {
            bool delete = await _hotwheelsService.DeleteHotwheelsById(id);
            return Ok(delete);
        }
    }
}
