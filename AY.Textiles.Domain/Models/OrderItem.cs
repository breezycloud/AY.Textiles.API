using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AY.Textiles.Domain.Models;

public class OrderItem
{        
    [Column(TypeName = "jsonb")]
    public Item? Item { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }    
    public bool IsDeleted { get; set; } = false;
    public long ModifiedTicks { get; set; } = DateTime.UtcNow.Ticks;        
}
