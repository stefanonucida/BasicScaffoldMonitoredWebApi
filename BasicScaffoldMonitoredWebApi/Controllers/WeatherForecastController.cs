using Microsoft.AspNetCore.Mvc;

namespace BasicScaffoldMonitoredWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[] {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Receive whole wheatherforecast list
    /// </summary>
    /// <returns></returns>
    [HttpGet] 
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(0, 5).Select(index => new WeatherForecast
        {
            id= index,
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    /// <summary>
    /// Receive a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public WeatherForecast Get(int id)
    {
        int idx = id <= 0 ? 0 : Math.Min(5 - 1, id);
        return Enumerable.Range(0, 5).Select(index => new WeatherForecast
        {
            id= index,
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .First(w => w.id == idx);
    }
}