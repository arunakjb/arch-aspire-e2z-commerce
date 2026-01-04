using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E2Z.DB.ORM.Models;

public partial class Product
{
    [Key]
    public int ID { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }

    public int? ProductImageId { get; set; }

    public string? Features { get; set; }

    public bool? IsReturnApplicable { get; set; }

    public DateTime? CreationTime { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    [InverseProperty("Product")]
    public virtual ICollection<ReturnDetail> ReturnDetails { get; set; } = new List<ReturnDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

    [InverseProperty("ProductClickedNavigation")]
    public virtual ICollection<UserRecentActivity> UserRecentActivities { get; set; } = new List<UserRecentActivity>();

    [InverseProperty("Product")]
    public virtual ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
}
