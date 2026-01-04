namespace E2Z.Api.Models
{
    public class UserReviewDto
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public int? Rating { get; set; }
        public string? Comments { get; set; }
        public int? UserImageId { get; set; }
        public Guid UserId { get; set; }
    }
}