using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class Order
{
    [Key]
    public int ID { get; set; }

    public Guid UserId { get; set; }

    public int Quantity { get; set; }

    public int? Rating { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? OriginalPrice { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DiscountedPrice { get; set; }

    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Orders")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual UserProfile User { get; set; } = null!;
}
