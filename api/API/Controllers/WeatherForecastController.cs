using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
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
    }
}



//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace API.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WebApiController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//        private readonly ILogger<WeatherForecastController> _logger;

//        public WebApiController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet(Name = "GetResponseConfig/{id}")]
//        public IEnumerable<ValuesController> Get(int id)
//        {
//            string html = string.Empty;
//            string url = @$"https://randomuser.me/api/?results={id}";
//            object listOfUsers = null;

//            listOfUsers = GetFromRandomUser(url);

//            Console.WriteLine(listOfUsers);
//            return (IEnumerable<ValuesController>)Ok(listOfUsers);
//        }

//        public object GetFromRandomUser(string url)
//        {
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
//            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
//            using (Stream stream = response.GetResponseStream())
//            using (StreamReader reader = new StreamReader(stream))
//            {
//                return reader.ReadToEnd();
//            }
//        }
//    }
//}