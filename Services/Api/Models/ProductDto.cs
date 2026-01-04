namespace E2Z.Api.Models
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int? ProductImageId { get; set; }
        public string? Features { get; set; }
        public bool? IsReturnApplicable { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}