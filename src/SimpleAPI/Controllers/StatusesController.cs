using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Repositories;

namespace SimpleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusesController : ControllerBase
{
    private readonly StatusRepository _repository;

    public StatusesController(StatusRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetActionResult()
    {
        return new string[] { "dotnet", "azure" };
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        return "Radox";
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
        Console.WriteLine("value");
        throw new NotImplementedException();
    }
}