using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AY.Textiles.Domain.Models;

public class Order
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "jsonb")]
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public string? ReceiptNo { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount => OrderItems?.Sum(x => x.Quantity * x.Price) ?? 0;
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Discount { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal SubTotal => TotalAmount - Discount;
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Paid { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Balance => SubTotal - Paid;
    public PaymentMode PaymentMode { get; set; }
    public bool IsDeleted { get; set; } = false;
    public long ModifiedTicks { get; set; } = DateTime.UtcNow.Ticks;
    [Column(TypeName = "jsonb")]
    public List<OrderItem>? OrderItems { get; set; } = new();
    [Column(TypeName = "jsonb")]
    public UserCredential? User { get; set; }
}
