using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HotwheelsClub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ClubModel>>> SearchAllHotwheels()
        {
            List<ClubModel> club = await _clubService.GetAllClubs();
            return Ok(club);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubModel>> SearchForId(int id)
        {
             ClubModel club = await _clubService.GetById(id);
            return Ok(club);
        }

        [HttpPost]
        public async Task<ActionResult<ClubModel>> Add([FromBody] ClubModel clubModel)
        {
                ClubModel club = await _clubService.Add(clubModel);
            return Ok(club);
        }

        [HttpPut]
        public async Task<ActionResult<ClubModel>> Update([FromBody]ClubModel clubModel,int id)
        {
            ClubModel club = await _clubService.Update(clubModel, id);
            return Ok(club);
        }

        [HttpDelete]
        public async Task<ActionResult<ClubModel>> Delete(int id)
        {
            bool delete = await _clubService.DeleteById(id);
            return Ok(delete);
        }
    }
}
