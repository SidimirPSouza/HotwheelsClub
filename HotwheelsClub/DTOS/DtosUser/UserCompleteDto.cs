using System.Text.Json.Serialization;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Models
{
    public class UserCompleteDto
    {
        public bool MonthlyFees { get; set; }
        public int? ClubId { get; set; }
        [JsonIgnore]
        public ClubModel? Club { get; set; }
        [JsonIgnore]
        public ICollection<HotwheelsModel>? hotwheels { get; set; }
    }
}
