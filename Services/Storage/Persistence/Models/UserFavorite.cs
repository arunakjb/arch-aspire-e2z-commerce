using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

public partial class UserFavorite
{
    [Key]
    public int ID { get; set; }

    public Guid UserId { get; set; }

    public int ProductId { get; set; }

    public DateTime? CreationTime { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("UserFavorites")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserFavorites")]
    public virtual UserProfile User { get; set; } = null!;
}
