using Microsoft.AspNetCore.Mvc;
using workspace.Models;

namespace workspace.Controllers;

/// <summary>
/// 날씨 조회 API
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;


    /// <summary>
    /// I로거 의존성 주입과 생성자
    /// </summary>
    /// <param name="logger">I로거 인스턴스</param>
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }


    /// <summary>
    /// 날씨 얻어오기
    /// </summary>
    /// <returns>날씨 총 리스트</returns>
    [HttpGet(Name = "GetWeatherForecaseModel")]
    public IEnumerable<WeatherForecastModel> Get()
    {
        _logger.LogInformation("날씨 데이터를 받아옵니다.");

        var data = Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        _logger.LogInformation("날씨 데이터를 성공적으로 조회하였습니다.");

        return data;
    }
}

// GET API를 실행해보면 I로거를 통해 로그가 콘솔에 지속적으로 쌓인다. 브라우저 개발자 현재 콘솔 로그에서... 자바로 치면 slf4j같은 녀석인것 같다.