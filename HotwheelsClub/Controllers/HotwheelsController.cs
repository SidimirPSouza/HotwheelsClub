using HotwheelsClub.Models;
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
        public async Task<ActionResult<List<HotwheelsCompleteDto>>> SearchAllHotwheels()
        {
            List<HotwheelsModel> hotwheels = await _hotwheelsService.GetAllHotwheels();
            return Ok(hotwheels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotwheelsCompleteDto>> SearchForId(int id)
        {
             HotwheelsModel hotwheels = await _hotwheelsService.GetById(id);
            return Ok(hotwheels);
        }

        [HttpPost]
        public async Task<ActionResult<HotwheelsCompleteDto>> Add([FromBody] HotwheelsCompleteDto dto)
        {
            var hotwheels = new HotwheelsModel
            {
                Name = dto.Name,
                Model = dto.Model,
                Price = dto.Price,
                Color = dto.Color,
                Year = dto.Year,
                ProprietorId = dto.ProprietorId
            };

            var created = await _hotwheelsService.Add(hotwheels);
            return Ok(created);
        }

        [HttpPut]
        public async Task<ActionResult<HotwheelsCompleteDto>> Update([FromBody]HotwheelsDto dto)
        {
            var hotwheels = new HotwheelsModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Model = dto.Model,
                Price = dto.Price,
                Color = dto.Color,
                Year = dto.Year,
            };
            var created = await _hotwheelsService.Update(hotwheels);
            return Ok(created);
        }

        [HttpDelete]
        public async Task<ActionResult<HotwheelsCompleteDto>> Delete(int id)
        {
            bool delete = await _hotwheelsService.DeleteById(id);
            return Ok(delete);
        }
    }
}
