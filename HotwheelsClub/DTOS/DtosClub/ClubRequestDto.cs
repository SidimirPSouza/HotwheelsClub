namespace HotwheelsClub.Models
{
    public class ClubRequestDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? MembersId { get; set; }
    }
}