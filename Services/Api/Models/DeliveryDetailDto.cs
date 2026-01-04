namespace E2Z.Api.Models
{
    public class DeliveryDetailDto
    {
        public int ID { get; set; }
        public Guid UserId { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? DeliveryInstructions { get; set; }
        public bool? IsDelivered { get; set; }
        public bool? IsCashOnDelivery { get; set; }
        public bool? ReturnProduct { get; set; }
    }
}