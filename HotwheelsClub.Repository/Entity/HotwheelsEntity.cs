using System.Text.Json.Serialization;

namespace HotwheelsClub.Repository.Entity
{
    public class HotwheelsEntity : BaseEntity
    {
        public string Model { get; set; }
        public double Price {  get; set; }
        public string Color {  get; set; }
        public int Year { get; set; }
        public int? ProprietorId { get; set; }
        [JsonIgnore]
        public virtual UserEntity? Proprietor { get; set; }
    }
}
