namespace E2Z.Api.Models
{
    public class ReturnDetailDto
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public Guid UserId { get; set; }
        public string? Reason { get; set; }
        public bool? IsCancelled { get; set; }
        public int DeliveryId { get; set; }
    }
}