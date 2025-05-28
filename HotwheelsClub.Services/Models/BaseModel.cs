using System.Text.Json.Serialization;

namespace HotwheelsClub.Service.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
