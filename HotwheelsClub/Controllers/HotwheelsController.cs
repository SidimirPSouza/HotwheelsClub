using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotwheelsClub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HotwheelsController : Controller
    {
        private readonly IHotwheelsRepository _hotwheelsRepository;
        public HotwheelsController(IHotwheelsRepository hotwheelsRepository)
        {
            _hotwheelsRepository = hotwheelsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<HotwheelsModel>>> BuscarTodosHotwheels()
        {
            List<HotwheelsModel> hotwheels = await _hotwheelsRepository.GetAllHotwheels();
            return Ok(hotwheels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotwheelsModel>> BuscarPorId(int id)
        {
             HotwheelsModel hotwheels = await _hotwheelsRepository.GetById(id);
            return (hotwheels);
        }

        [HttpPost]
        public async Task<ActionResult<HotwheelsModel>> Adicionar([FromBody] HotwheelsModel hotwheelsModel)
        {
            HotwheelsModel hotwheels = await _hotwheelsRepository.Add(hotwheelsModel);
            return (hotwheels);
        }
    }
}
