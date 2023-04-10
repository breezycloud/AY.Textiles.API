using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AY.Textiles.Domain.Models;

public class Stock
{
    [Required(ErrorMessage = "Date field is required")]
    public DateTime Date { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Quantity is required")]
    public int? Quantity { get; set; } = 0;
    public bool IsDeleted { get; set; } = false;
    public long ModifiedTicks { get; set; } = DateTime.UtcNow.Ticks;    
    public DateTime ModifiedDate => DateTime.FromBinary(ModifiedTicks);
}
