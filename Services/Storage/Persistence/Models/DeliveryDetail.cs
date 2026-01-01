using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class DeliveryDetail
{
    [Key]
    public int ID { get; set; }

    public Guid UserId { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? DeliveryInstructions { get; set; }

    public bool? IsDelivered { get; set; }

    public bool? IsCashOnDelivery { get; set; }

    public bool? ReturnProduct { get; set; }

    [InverseProperty("Delivery")]
    public virtual ICollection<ReturnDetail> ReturnDetails { get; set; } = new List<ReturnDetail>();

    [ForeignKey("UserId")]
    [InverseProperty("DeliveryDetails")]
    public virtual UserProfile User { get; set; } = null!;
}
