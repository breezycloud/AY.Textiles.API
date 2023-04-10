using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AY.Textiles.Domain.Models;
public class Item
{
    [Key] public Guid Id { get; set; }
    [Column(TypeName = "jsonb")]
    public Category? Category { get; set; }

    [Required(ErrorMessage = "Name is required!")]
    public string? ItemName { get; set; }
    public string? Description { get; set; }
    [Required(ErrorMessage = "Qty is required!")]
    public int? Quantity { get; set; }    
    [Column(TypeName = "decimal(18, 2)")]
    [Required(ErrorMessage = "Amount is required!")]
    public decimal? Price { get; set; }
    [Column(TypeName = "decimal(18, 2)")]    
    public decimal? SellPrice => IsDiscounted ? Price * Discount : Price;
    public bool IsDiscounted { get; set; } = false;    
    [Column(TypeName = "decimal(18, 2)")]    
    public decimal? Discount { get; set; } = 0;
    public bool IsDeleted { get; set; } = false;
    public long ModifiedTicks { get; set; } = DateTime.UtcNow.Ticks;    
    [Column(TypeName = "jsonb")]
    public List<Stock>? Stocks { get; set; } = new();
    [Column(TypeName = "jsonb")]
    public List<Review>? Reviews { get; set; } = new();
    [Column(TypeName = "jsonb")]
    public List<ItemImage>? Images { get; set; } = new();
}

public class Review
{
    public DateOnly Date { get; set; }
    public int Rate { get; set; }
    public string? Comment { get; set; }
    public UserCredential? User { get; set; }
}

public class ItemImage
{
    public string? Url { get; set; }
}
