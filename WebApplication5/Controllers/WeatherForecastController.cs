using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers;

[ApiController]
[Route("getData")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Haha()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
// ✅ NEW CONTROLLER ADDED IN SAME FILE
[ApiController]
[Route("api/hello")] // 👈 This controller handles "api/hello"
public class HelloController : ControllerBase
{
    [HttpGet] // 👈 Handles GET request at "api/hello"
    public string GreetMessage()
    {
        return "hi"; // ✅ Returns "hi"
    }
    [HttpGet("Namaste")]
    public string Namaste()
    {
        return "Namaste";
    }

    [HttpPost("place")]
    public string Place([FromBody] PlaceName placeName)
    {
        return $"Place: {placeName.Name}, Temp: {placeName.temp}";
    }

}