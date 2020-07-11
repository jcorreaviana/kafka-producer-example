using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Carro;
using src.Services;

namespace KafkaProducer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IKafkaService kafkaService;
        public CarController(ILogger<CarController> logger, IKafkaService kafkaService)
        {
            _logger = logger;
            this.kafkaService = kafkaService;
        }

        [ProducesResponseType(typeof(CarResponse), 201)]
        [HttpPost]
        public async Task<IActionResult> SendCar([FromBody] CarRequest carRequest)
        {
            var result = await Task.Run(() => kafkaService.SendMessage(carRequest));

            return result.Contains("failed") ? StatusCode(400, new CarResponse()) : StatusCode(201, new CarResponse{ id = result});
        }
    }
}
