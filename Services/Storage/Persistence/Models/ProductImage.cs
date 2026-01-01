using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class ProductImage
{
    [Key]
    public int ID { get; set; }

    [StringLength(500)]
    public string BlobUrl { get; set; } = null!;

    public DateTime? LastUpdated { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductImages")]
    public virtual Product Product { get; set; } = null!;
}
