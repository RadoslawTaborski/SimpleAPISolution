using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetActionResult()
        {
            return new string[] {"value1", "value2"};
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Something else";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }
    }
}