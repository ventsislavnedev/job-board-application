namespace Application.Companies;

public interface ICompanyService
{
    Task<int> CreateAsync(CreateCompanyRequest request);
    Task<CompanyResponse?> GetByIdAsync(int id);
    Task<IReadOnlyList<CompanyResponse>> GetAllAsync();
}