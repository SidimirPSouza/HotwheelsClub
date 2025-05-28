using System.Text.Json.Serialization;

namespace HotwheelsClub.Service.Models
{
    public class HotwheelsModel : BaseModel
    {
        public string Model { get; set; }
        public double Price {  get; set; }
        public string Color {  get; set; }
        public int Year { get; set; }
        public int? ProprietorId { get; set; }
        [JsonIgnore]
        public virtual UserModel? Proprietor { get; set; }
    }
}
