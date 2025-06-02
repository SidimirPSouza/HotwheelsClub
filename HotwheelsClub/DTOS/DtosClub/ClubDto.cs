using System.Text.Json.Serialization;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Dto
{
    public class ClubDto
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
