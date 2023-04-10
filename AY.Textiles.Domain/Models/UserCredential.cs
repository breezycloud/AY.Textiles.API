using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AY.Textiles.Domain.Models;

public class UserCredential
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string? FirstName { get; set; } = "nil";
    [Required(ErrorMessage = "Last Name is required")]
    public string? LastName { get; set; } = "nil";
    [StringLength(11, ErrorMessage = "Phone No is should 11 characters", MinimumLength = 11)]
    public string? MobileNo { get; set; }
    public string? Username { get; set; }
    [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string? HashedPassword { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageFormat { get; set; }
    public UserRole UserRole { get; set; }
    public bool IsDeleted { get; set; } = false;
    public long ModifiedDate { get; set; } = DateTime.Now.Ticks;
}
