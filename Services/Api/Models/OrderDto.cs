namespace E2Z.Api.Models
{
    public class OrderDto
    {
        public int ID { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public int? Rating { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
    }
}