using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using events_demo_v2.Handlers.Products;
using MediatR;

namespace events_demo_v2.Controllers 
{

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("getError")]
    public async Task<IEnumerable<WeatherForecast>> GetError()
    {
        await _mediator.Publish(new CreatedFileFailedNotification
        {
            Name = "xyz678"
        });

        Random rnd = new Random();

        var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rnd.Next(-20, 55),
            Summary = Summaries[rnd.Next(Summaries.Length)]
        })
        .ToArray();

        return result;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        try
        {

        Random rnd = new Random();

        var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rnd.Next(-20, 55),
            Summary = Summaries[rnd.Next(Summaries.Length)]
        })
        .ToArray();

        await _mediator.Publish(new CreatedFileSucceededNotification
        {
            Name = "abc123"
        });

        return result;

        }
        catch(Exception e)
        {
            await _mediator.Publish(new CreatedFileFailedNotification
            {
                Name = "xyz678"
            });
            return null;
        }
    }
}
}
