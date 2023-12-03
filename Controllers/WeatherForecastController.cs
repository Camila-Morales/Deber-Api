using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //RUTA 
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> ListWeatherForecasts = new List<WeatherForecast>();

        //CONSTRUCTOR DEL CONTROLADOR 
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (ListWeatherForecasts == null || !ListWeatherForecasts.Any()){

                ListWeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast 
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    })
                    .ToList();
            }

        }

        //METODO GET 
        [HttpGet(Name = "GetWeatherForecast")]
        //RUTAS DEL METODO  GET
        //[Route("Get/WeatherForecast")]
        //[Route("Get/WeatherForecast2")]
        //[Route("[action]")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogDebug("Retornando la lista ");
            return ListWeatherForecasts;
            
        }

        //METODO POST
        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast){
            ListWeatherForecasts.Add(weatherForecast);

            return Ok();
        }

        //METODO DELETE 
        [HttpDelete("{index}")]
        public IActionResult Delete(int index){
            ListWeatherForecasts.RemoveAt(index);

            return Ok();
        }
    }
}
