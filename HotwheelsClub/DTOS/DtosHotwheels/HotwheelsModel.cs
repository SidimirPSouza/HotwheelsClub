using System.Text.Json.Serialization;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Dto
{
    public class HotwheelsCompleteDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price {  get; set; }
        public string Color {  get; set; }
        public int Year { get; set; }
        public int? ProprietorId { get; set; }
        [JsonIgnore]
        public virtual UserModel? Proprietor { get; set; }
    }
}
