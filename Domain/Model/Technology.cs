using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Technology
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    
    // add technology image later
}