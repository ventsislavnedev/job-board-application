using System.ComponentModel.DataAnnotations;
using Domain.Enum;
using Domain.ValueObject;

namespace Domain.Model;

public class JobPosting
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Position { get; set; } = null!;
    
    [Required]
    [MaxLength(200)]
    public string Location { get; set; } = null!;
    
    public Salary? Salary { get; set; }

    [Required]
    [MaxLength(3000)]
    public string Requirements { get; set; } = null!; // keep as string for now

    [Required]
    [MaxLength(3000)]
    public string Benefits { get; set; } = null!;
    
    [Required]
    public WorkModel WorkModel { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public Category Category { get; set; } = null!;

    [Required]
    public Company Company { get; set; } = null!;
    
    public ICollection<Technology> RequiredTechnologies { get; set; } = new List<Technology>();
}