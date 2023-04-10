using System;
using System.ComponentModel.DataAnnotations;

namespace AY.Textiles.Domain.Models;

public class Category
{
    [Key] 
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Field is required")]
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime ModifiedDate => DateTime.FromBinary(ModifiedTicks);
    public long ModifiedTicks { get; set; } = DateTime.UtcNow.Ticks;
}
