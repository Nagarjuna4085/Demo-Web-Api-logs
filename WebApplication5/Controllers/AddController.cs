using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("math")]
    public class AddController : ControllerBase
    {
        private readonly ILogger<AddController> _logger;

        public AddController(ILogger<AddController> logger)
        {
            _logger = logger;
        }


        [HttpPost("add")]
        public IActionResult Addition([FromBody] Add Num)
{
    try
    {
        _logger.LogTrace("Received numbers for addition: {0} and {1}", Num.Num1, Num.Num2);
        
        if (Num.Num1 == 0 || Num.Num2 == 0)
        {
            _logger.LogWarning("One of the numbers is zero, which could lead to unexpected results");
        }

        int result = Num.Num1 + Num.Num2;
        _logger.LogInformation("Addition result: {0}", result);

        return Ok(result); // You can also return this in a custom response model if needed
                
    }
    catch (Exception ex) // Updated the variable name to 'ex'
    {
        _logger.LogError(ex, "An error occurred while adding the numbers");
        return StatusCode(500, "Internal Server Error");
    }
}

        [HttpGet("TestLog")]
        public string Test()
        {
            _logger.LogInformation("Hello From TEsting log");
            return "return from test";
        }

    }
}
