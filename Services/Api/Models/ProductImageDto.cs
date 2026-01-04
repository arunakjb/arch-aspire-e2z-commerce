namespace E2Z.Api.Models
{
    public class ProductImageDto
    {
        public int ID { get; set; }
        public string BlobUrl { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int ProductId { get; set; }
    }
}