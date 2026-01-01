using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class CartDetail
{
    [Key]
    public int ID { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public Guid UserId { get; set; }

    public bool? IsBought { get; set; }

    public bool? IsDeleted { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("CartDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("CartDetails")]
    public virtual UserProfile User { get; set; } = null!;
}
