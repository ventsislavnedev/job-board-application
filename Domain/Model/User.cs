using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Model;

public class User
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; } = null!;
    
    [Required]
    public UserRole Role { get; set; } 
    
    [Required]
    public DateTime DateCreated { get; set; }
    
    public DateTime? LastLogin { get; set; }
}