using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class JobBoardDbContext : DbContext
{
    public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<CandidateProfile> CandidateProfiles { get; set; } = null!;
    public DbSet<JobPosting> JobPostings { get; set; } = null!;
    public DbSet<JobApplication> JobApplications { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Technology> Technologies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureJobPosting(modelBuilder);
        ConfigureTechnology(modelBuilder);
        ConfigureJobApplication(modelBuilder);
        ConfigureCandidateProfile(modelBuilder);
    }

    private static void ConfigureJobPosting(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.ToTable("JobPostings");

            entity
                .HasMany(j => j.RequiredTechnologies)
                .WithMany(t => t.JobPostings)
                .UsingEntity<Dictionary<string, object>>(
                    "JobPostingTechnology",
                    j => j.HasOne<Technology>()
                          .WithMany()
                          .HasForeignKey("TechnologyId")
                          .OnDelete(DeleteBehavior.Cascade),
                    t => t.HasOne<JobPosting>()
                          .WithMany()
                          .HasForeignKey("JobPostingId")
                          .OnDelete(DeleteBehavior.Cascade),
                    join =>
                    {
                        join.ToTable("JobPostingTechnologies");
                        join.HasKey("JobPostingId", "TechnologyId");
                    });

            entity.OwnsOne(j => j.Salary);
        });
    }

    private static void ConfigureTechnology(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Technology>(entity =>
        {
            entity.ToTable("Technologies");

            entity.HasIndex(t => t.Name)
                  .IsUnique();
        });
    }

    private static void ConfigureJobApplication(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.ToTable("JobApplications");

            entity.HasOne(ja => ja.JobPosting)
                  .WithMany()
                  .HasForeignKey(ja => ja.JobPostingId);

            entity.HasOne(ja => ja.CandidateProfile)
                  .WithMany()
                  .HasForeignKey(ja => ja.CandidateProfileId);
        });
    }

    private static void ConfigureCandidateProfile(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateProfile>(entity =>
        {
            entity.ToTable("CandidateProfiles");

            entity.HasOne(cp => cp.User)
                  .WithOne()
                  .HasForeignKey<CandidateProfile>(cp => cp.UserId);
        });
    }
}
