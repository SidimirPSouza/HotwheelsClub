using System.Text.Json.Serialization;

namespace HotwheelsClub.Models
{
    public class UserModel
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
