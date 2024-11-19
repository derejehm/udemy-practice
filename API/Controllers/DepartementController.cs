using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartementController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("Get all Student");
    }
    
    [HttpGet("{code}")]
    public IActionResult GetA(string code)
    {
        return Ok("Get this" + code + " Department data");
    }
    
    [HttpPost]
    public IActionResult Insert()
    {
        return Ok("Insert new departement");
    }
    
    [HttpPut("{code}")]
    public IActionResult update(string code)
    {
        return Ok("Update this" + code + " Department data");
    }

}