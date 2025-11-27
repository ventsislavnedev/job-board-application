using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Company
{
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; } = null!;

    [MaxLength(3000)] public string? Description { get; set; }

    [MaxLength(200)] [Url] public string? WebsiteUrl { get; set; }

    [Required] [MaxLength(200)] public string Location { get; set; } = null!; // keep as string for now

    [Required] public int OwnerUserId { get; set; }

    [Required] public User OwnerUser { get; set; } = null!;

    public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();

    // can add later:
    // Team (list of Employee IDs)
    // each employee has Name, Position, Picture, Description, DisplayOrderNumber (not sure best way to implement)
    // List of social media (SocialMedia object with SocialMediaPlatform and URL maybe)
}