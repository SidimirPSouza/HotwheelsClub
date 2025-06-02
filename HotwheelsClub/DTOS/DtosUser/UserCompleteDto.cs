using System.Text.Json.Serialization;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Dto
{
    public class UserCompleteDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool MonthlyFees { get; set; }
        public int? ClubId { get; set; }
        [JsonIgnore]
        public ClubModel? Club { get; set; }
        [JsonIgnore]
        public ICollection<HotwheelsModel>? hotwheels { get; set; }
    }
}
