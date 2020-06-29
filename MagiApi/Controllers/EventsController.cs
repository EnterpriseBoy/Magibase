using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MagiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEvents()
        {
            return new BadRequestObjectResult(new List<object>()
            {
                new {id=1,Name="Event One"},
                new {id=2,Name="Event Two"}
            });
        }
    }
}
