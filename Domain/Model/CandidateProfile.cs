using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class CandidateProfile
{
    public int Id { get; set; }
    
    [Required] [MaxLength(100)] public string FirstName { get; set; } = null!;

    [Required] [MaxLength(100)] public string LastName { get; set; } = null!;

    [Required] [MaxLength(100)] public string Location { get; set; } = null!;

    [Required] [MaxLength(3000)] public string? Summary { get; set; }
    
    [Required]
    public int UserId { get; set; }

    [Required] public User User { get; set; } = null!;
}