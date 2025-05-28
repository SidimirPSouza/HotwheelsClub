using System.Text.Json.Serialization;

namespace HotwheelsClub.Repository.Entity
{
    public class UserEntity : BaseEntity
    {
        public bool MonthlyFees { get; set; }
        public int? ClubId { get; set; }
        [JsonIgnore]
        public ClubEntity? Club { get; set; }
        [JsonIgnore]
        public ICollection<HotwheelsEntity>? hotwheels { get; set; }
    }
}
