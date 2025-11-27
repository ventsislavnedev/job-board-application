using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly JobBoardDbContext _context;

    public JobsController(JobBoardDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public string Get()
    {
        return "Hello world";
    }

    [HttpPost]
    public async Task<IActionResult> CreateJobPosting()
    {
        return null;
    }
}