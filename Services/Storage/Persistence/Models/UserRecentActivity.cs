using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Models;

[Table("UserRecentActivity")]
public partial class UserRecentActivity
{
    [Key]
    public int ID { get; set; }

    public Guid UserId { get; set; }

    public int ProductClicked { get; set; }

    public DateTime? LastVisitedTime { get; set; }

    public int? VisitedOccurences { get; set; }

    [ForeignKey("ProductClicked")]
    [InverseProperty("UserRecentActivities")]
    public virtual Product ProductClickedNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserRecentActivities")]
    public virtual UserProfile User { get; set; } = null!;
}
