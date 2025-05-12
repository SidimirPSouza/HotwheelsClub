using HotwheelsClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotwheelsClub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HotwheelsController : Controller
    {  
        public readonly 
        public HotwheelsController() { }
       [HttpGet]
       public ActionResult<List<HotwheelsModel>> BuscarTodosHotwheels()
        {

            return Ok();
        }
    }
}
