using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NetBlog.Api.Contracts;
using NetBlog.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace NetBlog.Api.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet(ApiRoutes.WeatherForecast.Get)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IEnumerable<WeatherForecast>> Get() => await Mediator.Send(new GetWeatherForecastsQuery());
}