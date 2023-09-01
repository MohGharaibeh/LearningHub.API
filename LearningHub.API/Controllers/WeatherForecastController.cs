using LearningHub.core.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LearningHub.API.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("chat")]
        public async Task<IActionResult> chatAsync([FromBody] ChatRequest requests)
        {
            if (requests != null && !string.IsNullOrWhiteSpace(requests.Question))
            {
                var client = new HttpClient();

                var requestBody = new { question = requests.Question };
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:4000/chatbot");
                request.Content = content;

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<JObject>(jsonResponse);

                string answer = responseObject["response_text"]?.ToString();

                return Ok(new { answer });
            }

            return BadRequest(new { answer = "Please provide a valid question." });
        }

        [HttpGet]
        [Route("GetIp")]
        public async Task<IActionResult> GetIpInfo([FromQuery] string ip)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync($"http://apiip.net/api/check?ip={ip}&accessKey=23662421-4178-44a2-9195-41baf38427a2");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IP>(content);
                    return Ok(result);
                }
                else
                {
                    // Handle the error here, such as logging or returning an error response.
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return BadRequest($"API Error: {response.StatusCode}, {errorContent}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception, and return an error response.
                // Example: Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("weather/{city}")]
        public async Task<WeatherApi> City(string city)

         {
             // Hit API

             // Hit URL ---> Current weather data

             // 1- Http Method

             // 2- URL

             // 3- API Key

             using (var http = new HttpClient())

             {
                 var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=74302e63ebdb47077c680a584441f3cd");

                 var result = await response.Content.ReadAsStringAsync(); // result as string
                 var result2 = JsonConvert.DeserializeObject<WeatherApi>(result);
                 return result2;

             }

        }

        
    }
}