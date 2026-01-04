namespace E2Z.Api.Models
{
    public class UserFavoriteDto
    {
        public int ID { get; set; }
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}