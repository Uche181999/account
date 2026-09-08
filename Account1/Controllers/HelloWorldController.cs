using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Account1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
    //    private readonly ILogger<HelloWorldController> _logger;
    //    public HelloWorldController(ILogger<HelloWorldController> logger)
    //     {
    //         _logger = logger;
    //     }
       [HttpGet]
       public IActionResult Get()
        {
            // _logger.LogInformation("helloWorld GET endpoint hit at time : {Time}", DateTime.Now);
            return Ok("hello world");
        }
        [HttpGet("{name}")]
       public IActionResult Get(string name)
        {
            // _logger.LogInformation("helloWorld GET endpoint with name ({Name}) hit at time : {Time}",name, DateTime.Now);
            return Ok($"hello {name}");
        }
    }
}