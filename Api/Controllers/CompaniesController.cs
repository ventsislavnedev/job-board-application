using Application.Companies;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var id = await _companyService.CreateAsync(request);

        var created = await _companyService.GetByIdAsync(id);

        return CreatedAtAction(nameof(GetById), new { id }, created);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var company = await _companyService.GetByIdAsync(id);

        if (company is null) return NotFound();

        return Ok(company);
    }

    public async Task<IActionResult> GetAll()
    {
        var companies = await _companyService.GetAllAsync();
        return Ok(companies);
    }
}