using System.Text.Json.Serialization;

namespace HotwheelsClub.Repository.Entity
{
    public class ClubEntity : BaseEntity
    {
        public string? Description { get; set; }
        public int? ProprietorId { get; set; }
        [JsonIgnore]
        public UserEntity? Proprietor { get; set; }
        [JsonIgnore]
        public ICollection<UserEntity>? Members { get; set; }
    }
}
