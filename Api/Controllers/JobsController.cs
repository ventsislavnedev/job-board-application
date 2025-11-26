using Microsoft.AspNetCore.Mvc;

namespace JobBoardApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello world";
    }
}