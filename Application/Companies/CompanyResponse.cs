namespace Application.Companies;

public class CompanyResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? WebsiteUrl { get; set; }
    public string Location { get; set; } = null!;
    public int OwnerUserId { get; set; }
}