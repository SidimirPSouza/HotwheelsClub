namespace HotwheelsClub.Models
{
    public class HotwheelsRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int? ProprietorId { get; set; }
    }
}