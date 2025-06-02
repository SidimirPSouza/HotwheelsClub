namespace HotwheelsClub.Service.Dto
{
    public class HotwheelsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price {  get; set; }
        public string Color {  get; set; }
        public int Year { get; set; }
        public int? ProprietorId { get; set; }
    }
} 
