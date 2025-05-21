using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
        public async Task<ActionResult<List<HotwheelsModel>>> SearchAllHotwheels()
        {
            List<HotwheelsModel> hotwheels = await _hotwheelsService.GetAllHotwheels();
            return Ok(hotwheels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotwheelsModel>> SearchForId(int id)
        {
             HotwheelsModel hotwheels = await _hotwheelsService.GetById(id);
            return Ok(hotwheels);
        }

        [HttpPost]
        public async Task<ActionResult<HotwheelsModel>> Add([FromBody] HotwheelsModel hotwheelsModel)
        {
                HotwheelsModel hotwheels = await _hotwheelsService.Add(hotwheelsModel);
            return Ok(hotwheels);
        }

        [HttpPut]
        public async Task<ActionResult<HotwheelsModel>> Update([FromBody]HotwheelsModel hotwheelsModel,int id)
        {
            HotwheelsModel hotwheels = await _hotwheelsService.Update(hotwheelsModel, id);
            return Ok(hotwheels);
        }

        [HttpDelete]
        public async Task<ActionResult<HotwheelsModel>> Delete(int id)
        {
            bool delete = await _hotwheelsService.DeleteById(id);
            return Ok(delete);
        }
    }
}
