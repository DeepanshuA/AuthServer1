using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace AuthServer1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestAuthenticationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private static int counter = 0;

        private readonly ILogger<RequestAuthenticationController> _logger;

        public RequestAuthenticationController(ILogger<RequestAuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetApproval")]
        public AuthenticationCall Get()
        {
            counter++;
            bool isEven = counter % 2 == 0;
            return new AuthenticationCall
            {
                Approved = isEven,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}