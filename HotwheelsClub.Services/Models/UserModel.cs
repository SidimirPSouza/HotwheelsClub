using System.Text.Json.Serialization;

namespace HotwheelsClub.Service.Models
{
    public class UserModel : BaseModel
    {
        public bool MonthlyFees { get; set; }
        public int? ClubId { get; set; }
        [JsonIgnore]
        public ClubModel? Club { get; set; }
        [JsonIgnore]
        public ICollection<HotwheelsModel>? hotwheels { get; set; }
    }
}
