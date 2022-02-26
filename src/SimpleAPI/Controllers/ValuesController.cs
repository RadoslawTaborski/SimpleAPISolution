using System;
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
            return new string[] {"dotnet", "azure"}; 
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
}
