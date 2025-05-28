using System.Text.Json.Serialization;

namespace HotwheelsClub.Repository.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
