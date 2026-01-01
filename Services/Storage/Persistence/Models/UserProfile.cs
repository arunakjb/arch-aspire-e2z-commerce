using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

[Table("UserProfile")]
[Index("Email", Name = "UQ__UserProf__A9D105347E52D5ED", IsUnique = true)]
public partial class UserProfile
{
    [Key]
    public Guid UserId { get; set; }

    [StringLength(200)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Gender { get; set; }

    public string? Preferences { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime? CreationTime { get; set; }

    public bool? IsLoggedIn { get; set; }

    public DateTime? LastLoggedInTime { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    [InverseProperty("User")]
    public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<ReturnDetail> ReturnDetails { get; set; } = new List<ReturnDetail>();

    [InverseProperty("User")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [InverseProperty("User")]
    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

    [InverseProperty("User")]
    public virtual ICollection<UserRecentActivity> UserRecentActivities { get; set; } = new List<UserRecentActivity>();

    [InverseProperty("User")]
    public virtual ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
}
