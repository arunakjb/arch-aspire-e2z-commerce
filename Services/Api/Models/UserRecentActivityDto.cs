namespace E2Z.Api.Models
{
    public class UserRecentActivityDto
    {
        public int ID { get; set; }
        public Guid UserId { get; set; }
        public int ProductClicked { get; set; }
        public DateTime? LastVisitedTime { get; set; }
        public int? VisitedOccurences { get; set; }
    }
}