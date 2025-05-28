
namespace HotwheelsClub.Repository.Entity
{
    public class UserTransferEntity
    {
        public int Id { get; set; }
        public int? ClubId { get; set; }
        public bool MonthlyFees { get; set; }
    }
}
