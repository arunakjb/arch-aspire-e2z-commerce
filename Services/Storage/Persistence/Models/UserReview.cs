using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class UserReview
{
    [Key]
    public int ID { get; set; }

    public int ProductId { get; set; }

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    public int? UserImageId { get; set; }

    public Guid UserId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("UserReviews")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserReviews")]
    public virtual UserProfile User { get; set; } = null!;

    [InverseProperty("Review")]
    public virtual ICollection<UserReviewImage> UserReviewImages { get; set; } = new List<UserReviewImage>();
}
