using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presistence.Entities;

namespace CoreMe.Controllers
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
        private IDBContext db;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDBContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            this.db.ConfigTBLs.Add(new Domain.Entity.ConfigTBL
            {
                Key=new Random().Next().ToString(),
                Value="val2"
            });
            this.db.SaveChanges();
            var key = db.ConfigTBLs.Find(1);
            key.Value = "58745";
            db.Update(key);
            db.SaveChanges();
            var key2 = db.ConfigTBLs.Where(e => e.Key == "988481003").First();
            key2.Value = "12e";
            db.Update(key2);
            db.SaveChanges();
            
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