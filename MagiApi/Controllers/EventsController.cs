using AutoMapper;
using MagiApi.Entities;
using MagiApi.Interfaces;
using MagiApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MagiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository,IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }
        [HttpGet]
        public IActionResult GetEvents()
        {
            var eventEntities = _eventRepository.GetEvents();
            return new OkObjectResult(_mapper.Map<IEnumerable<EventDto>>(eventEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            return new OkObjectResult(_eventRepository.GetEvent(id));
        }
    }
}
