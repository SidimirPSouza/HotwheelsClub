using HotwheelsClub.Service.Dto;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<ClubDto>>> SearchAllClubsAsync()
        {
            List<ClubModel> club = await _clubService.GetAllClubsAsync();
            return Mappers.ClubMappers.MapListModelToDto(club);
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubDto>> SearchClubForId(int id)
        {
             ClubModel club = await _clubService.GetClubByIdAsync(id);
            var clubDto = Mappers.ClubMappers.MapModelToDto(club); 
            return Ok(clubDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClubDto>> AddClubAsync([FromBody] ClubDto dto)
        {
            var club = Mappers.ClubMappers.MapDtoToModel(dto);

            var created = await _clubService.AddClubAsync(club);

            var clubDto = Mappers.ClubMappers.MapModelToDto(created);
            return Ok(clubDto);
        }

        [HttpPut]
        public async Task<ActionResult<ClubDto>> UpdateClubAsync([FromBody]ClubDto dto)
        {
            ClubModel club = Mappers.ClubMappers.MapDtoToModel(dto);

            var created = await _clubService.UpdateClubAsync(club);

            ClubDto clubDto = Mappers.ClubMappers.MapModelToDto(club);
            return Ok(clubDto);
        }

         

        [HttpDelete]
        public async Task<ActionResult<ClubDto>> DeleteClubAsync(int id)
        {
            bool delete = await _clubService.DeleteClubById(id);
            return Ok(delete);
        }

        
    }
}
