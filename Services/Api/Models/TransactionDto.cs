namespace E2Z.Api.Models
{
    public class TransactionDto
    {
        public int ID { get; set; }
        public Guid UserId { get; set; }
        public string? PaymentMode { get; set; }
        public int DeliveryId { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? DiscountedAmount { get; set; }
        public bool? IsTransactionSuccess { get; set; }
        public DateTime? TransactionTime { get; set; }
        public string? InvoiceNumber { get; set; }
    }
}