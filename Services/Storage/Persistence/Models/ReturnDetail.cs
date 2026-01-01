using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class ReturnDetail
{
    [Key]
    public int ID { get; set; }

    public int ProductId { get; set; }

    public Guid UserId { get; set; }

    public string? Reason { get; set; }

    public bool? IsCancelled { get; set; }

    public int DeliveryId { get; set; }

    [ForeignKey("DeliveryId")]
    [InverseProperty("ReturnDetails")]
    public virtual DeliveryDetail Delivery { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("ReturnDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ReturnDetails")]
    public virtual UserProfile User { get; set; } = null!;
}
