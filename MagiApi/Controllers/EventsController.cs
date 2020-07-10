using AutoMapper;
using MagiApi.Entities;
using MagiApi.Interfaces;
using MagiApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MagiApi.Controllers
{
    [ApiController]
    [Route("api/events")]
    //Inherit controller base as that does not have support for views
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
        public ActionResult<IEnumerable<User>> GetEvents()
        {
            var eventEntities = _eventRepository.GetEvents();
            //_mapper.Map returns the type we want back and we pass in Source
            return Ok(_mapper.Map<IEnumerable<User>>(eventEntities));
        }

        [HttpGet("{id}", Name ="GetEvent")]
        public IActionResult GetEvent(int id)
        {
            var eventEntity = _eventRepository.GetEvent(id);

            if (eventEntity == null)
                return NotFound();

            return new OkObjectResult(_mapper.Map<User>(eventEntity));
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody]EventCreateDto eventCreateDto)
        {
            var eventEntity = _mapper.Map<Entities.Event>(eventCreateDto);
            _eventRepository.AddEvent(eventEntity);
            _eventRepository.Save();
            var eventToReturn = _mapper.Map<User>(eventEntity);
            return CreatedAtRoute("GetEvent",
                new { eventId = eventToReturn.Id }, eventToReturn);
        }
    }
}
