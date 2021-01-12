using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestTaskCleveroad.Models;

namespace TestTaskCleveroad.Controllers
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

        [HttpGet, Route("Current")]
        public async Task<RootObject> GetCurrent(string cityName)
        {
         
            string apiKey = "6418ce6c8e4fd8f4c2c5c0bfd7f52a17";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();


            RootObject weather = new RootObject();
           
            try
            {
                response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid={apiKey}");

                if (response.StatusCode == (HttpStatusCode)404) throw new ExceptionModel();
                HttpContent content = response.Content;

                string data = await content.ReadAsStringAsync();

                weather = JsonConvert.DeserializeObject<RootObject>(data);
                return weather;
            }
            catch (ExceptionModel exception)
            {
                Response.StatusCode = exception.Status;
                ExceptionMessage exceptionMessage = new ExceptionMessage();
                exceptionMessage.Code = exception.Status;
                exceptionMessage.Message = "City not found";

                return exceptionMessage;
             
            }              
        }

        [HttpGet, Route("Forecast")]
        public async Task<RootObjectForecast> GetForecast(string cityName)
        {

            string apiKey = "6418ce6c8e4fd8f4c2c5c0bfd7f52a17";
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&appid={apiKey}");
                if (response.StatusCode == (HttpStatusCode)404) throw new ExceptionModel();

                HttpContent content = response.Content;

                string data = await content.ReadAsStringAsync();

                RootObjectForecast weather = JsonConvert.DeserializeObject<RootObjectForecast>(data);

                return weather;
            }
            catch(ExceptionModel exception)
            {
                Response.StatusCode = 404;
                return null;
            }
        }
    }
}
