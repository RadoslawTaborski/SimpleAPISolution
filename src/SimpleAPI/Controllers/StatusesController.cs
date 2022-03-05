using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Repositories;

namespace SimpleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusesController : ControllerBase
{
    private readonly IStatusRepository _repository;

    public StatusesController(IStatusRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Status>>> Get()
    {
        return Ok((await _repository.Get()).Collection);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Status>> Get(int id)
    {
        Status? st = await _repository.Get(id);
        return st!=null?Ok(st):NotFound();
    }

    [HttpPost]
    public async Task Post([FromBody] Status value)
    {
        if(value==null){
            return;
        }
        await _repository.Add(value);
    }
}