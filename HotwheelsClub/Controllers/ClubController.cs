using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;
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
        public async Task<ActionResult<List<ClubDto>>> SearchAllClubs()
        {
            List<ClubModel> club = await _clubService.GetAllClubs();
            return Ok(club);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubDto>> SearchForId(int id)
        {
             ClubModel club = await _clubService.GetById(id);
            return Ok(club);
        }

        [HttpPost]
        public async Task<ActionResult<ClubDto>> Add([FromBody] ClubDto dto)
        {
            var club = new ClubModel
            {
                Name = dto.Name,
                Description = dto.Description,
                ProprietorId = dto.ProprietorId,
                Proprietor = dto.Proprietor,
                Members = dto.Members
            };

            var created = await _clubService.Add(club);
            return Ok(created);
        }

        [HttpPut]
        public async Task<ActionResult<ClubDto>> Update([FromBody]ClubDto dto)
        {
            var club = new ClubModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ProprietorId = dto.ProprietorId,
                Proprietor = dto.Proprietor,
                Members = dto.Members,
            };

            var created = await _clubService.Update(club);
            return Ok(created);
        }

        [HttpDelete]
        public async Task<ActionResult<ClubDto>> Delete(int id)
        {
            bool delete = await _clubService.DeleteById(id);
            return Ok(delete);
        }
    }
}
