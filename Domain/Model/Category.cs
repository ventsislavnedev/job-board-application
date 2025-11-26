using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Category
{
    public int Id { get; set; }

    [Required] [MaxLength(200)] public string Name { get; set; } = null!;

    public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
}