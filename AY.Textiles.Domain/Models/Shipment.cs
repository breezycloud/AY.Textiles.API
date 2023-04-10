using System;
using System.ComponentModel.DataAnnotations;

namespace AY.Textiles.Domain.Models;

public class Shipment
{
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    public string? Email { get; set; }
    [StringLength(11, ErrorMessage = "Phone No is should 11 characters", MinimumLength = 11)]
    public string? MobileNo { get; set; }
    [Required(ErrorMessage = "State is required")]
    public string? State { get; set; }
    [Required(ErrorMessage = "City is required")]
    public string? City { get; set; }
    [Required(ErrorMessage = "City is required")]
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? Notes { get; set; }
}
