using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E2Z.DB.ORM.Models;

public partial class Transaction
{
    [Key]
    public int ID { get; set; }

    public Guid UserId { get; set; }

    [StringLength(50)]
    public string? PaymentMode { get; set; }

    public int DeliveryId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AmountPaid { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DiscountedAmount { get; set; }

    public bool? IsTransactionSuccess { get; set; }

    public DateTime? TransactionTime { get; set; }

    [StringLength(100)]
    public string? InvoiceNumber { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Transactions")]
    public virtual UserProfile User { get; set; } = null!;
}
