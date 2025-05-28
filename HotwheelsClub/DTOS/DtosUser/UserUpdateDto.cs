namespace HotwheelsClub.Models
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool MonthlyFees { get; set; }
        public int? ClubId { get; set; }
    }
} 
