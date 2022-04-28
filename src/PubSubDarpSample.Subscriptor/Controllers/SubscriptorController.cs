using Microsoft.AspNetCore.Mvc;
using PubSubDaprSample.Contracts;
using System.Text.Json;
using Dapr;

namespace PubSubDarpSample.Subscriptor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class SubscriptorController : ControllerBase
    {

        private readonly ILogger<SubscriptorController> _logger;

        public SubscriptorController(ILogger<SubscriptorController> logger)
        {
            _logger = logger;
        }

        [HttpPost("subscriptor")]
        [Topic("subscriptor-microservice", "mydaprdemoeventhub")]
        public async Task<IActionResult> Subscriptor(JsonElement obj)
        {
            var eventPayload = obj.Deserialize<SomeObject>();
            return new OkResult();
        }
    }
}