using System.Text.Json.Serialization;

namespace HotwheelsClub.Models
{
    public class ClubModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ProprietorId { get; set; }
        [JsonIgnore]
        public UserModel? Proprietor { get; set; }
        [JsonIgnore]
        public ICollection<UserModel>? Members { get; set; }
    }
}
