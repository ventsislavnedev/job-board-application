using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Model;

public class JobApplication
{
    public int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public string CvFilePath { get; set; } = null!;
    
    [MaxLength(3000)]
    public string? CoverLetter { get; set; }

    [Required]
    public DateTime ApplicationDate { get; set; }
    
    [Required]
    public JobApplicationStatus Status { get; set; }
    
    [Required]
    public int CandidateProfileId { get; set; }
    
    [Required]
    public int JobPostingId { get; set; }

    [Required]
    public CandidateProfile CandidateProfile { get; set; } = null!;

    [Required]
    public JobPosting JobPosting { get; set; } = null!;
}