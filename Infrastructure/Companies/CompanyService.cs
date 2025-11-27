using Application.Companies;
using Domain.Model;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Companies;

public class CompanyService : ICompanyService
{
    private readonly JobBoardDbContext _context;

    public CompanyService(JobBoardDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(CreateCompanyRequest request)
    {
        var company = new Company
        {
            Name = request.Name,
            Description = request.Description,
            WebsiteUrl = request.WebsiteUrl,
            Location = request.Location,
            OwnerUserId = request.OwnerUserId
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return company.Id;
    }

    public async Task<IReadOnlyList<CompanyResponse>> GetAllAsync()
    {
        var companies = await _context.Companies.AsNoTracking().ToListAsync();

        return companies.Select(MapToResponse).ToList();
    }

    public async Task<CompanyResponse?> GetByIdAsync(int id)
    {
        var company = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        return company is null ? null : MapToResponse(company);
    }

    private static CompanyResponse MapToResponse(Company company)
    {
        return new CompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            Description = company.Description,
            WebsiteUrl = company.WebsiteUrl,
            Location = company.Location,
            OwnerUserId = company.OwnerUserId
        };
    }
}