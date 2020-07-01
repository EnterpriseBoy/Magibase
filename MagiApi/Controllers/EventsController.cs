using MagiApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MagiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentException(nameof(eventRepository));
        }
        [HttpGet]
        public IActionResult GetEvents()
        {
            return new OkObjectResult(_eventRepository.GetEvents());
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            return new OkObjectResult(_eventRepository.GetEvent(id));
        }
    }
}
