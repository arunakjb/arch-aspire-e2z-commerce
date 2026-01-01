using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class UserReviewImage
{
    [Key]
    public int ID { get; set; }

    [StringLength(500)]
    public string BlobUrl { get; set; } = null!;

    public int ReviewId { get; set; }

    [ForeignKey("ReviewId")]
    [InverseProperty("UserReviewImages")]
    public virtual UserReview Review { get; set; } = null!;
}
