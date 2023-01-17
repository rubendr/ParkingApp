using Microsoft.AspNetCore.Mvc;

namespace ParkingWebFrontend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IHttpClientFactory httpClientFactory;
        public WeatherForecastController(
            IHttpClientFactory httpClientFactory, 
            ILogger<WeatherForecastController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

    

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("checkinget")]
        public IResult GetCheckIn()
        {
            //Console.WriteLine(value);
            //var client = httpClientFactory.CreateClient();
            //var link = new Uri("http://localhost:9999/api/parking");
            //var content = new StringContent(value, System.Text.Encoding.UTF8, "application/json");
            //var resp = client.PostAsync(link, content).Result;
            //return Results.Ok(resp);
            return Results.Ok("OK");

        }

        [HttpPost("checkin")]
        public IResult PostCheckIn([FromBody] string value)
        {
            Console.WriteLine(value);
            //var client = httpClientFactory.CreateClient();
            //var link = new Uri("http://localhost:9999/api/parking");
            //var content = new StringContent(value, System.Text.Encoding.UTF8, "application/json");
            //var resp = client.PostAsync(link, content).Result;
            //return Results.Ok(resp);
            return Results.Ok(value);

        }


    }
}