using System.Text.Json.Serialization;

namespace HotwheelsClub.Service.Models
{
    public class ClubModel : BaseModel
    {
        public string? Description { get; set; }
        public int? ProprietorId { get; set; }
        [JsonIgnore]
        public UserModel? Proprietor { get; set; }
        [JsonIgnore]
        public ICollection<UserModel>? Members { get; set; }
    }
}
