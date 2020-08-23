using AutoMapper;
using MagiApi.Entities;
using MagiApi.Interfaces;
using MagiApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            var eventEntities = _eventRepository.GetEvents();
            //_mapper.Map returns the type we want back and we pass in Source
            return Ok(_mapper.Map<IEnumerable<Event>>(eventEntities));
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetEvent")]
        [HttpHead]
        public IActionResult GetEvent(int id)
        {
            var eventEntity = _eventRepository.GetEvent(id);

            if (eventEntity == null)
                return NotFound();

            return new OkObjectResult(_mapper.Map<Event>(eventEntity));
        }

        //As a complex type this comes from the Body by default
        [HttpPost]
        public ActionResult<EventDto> CreateEvent([FromBody] EventCreateDto eventCreateDto)
        {
            var eventEntity = _mapper.Map<Event>(eventCreateDto);
            _eventRepository.AddEvent(eventEntity);
            _eventRepository.Save();
            
            var eventToReturn = _mapper.Map<EventDto>(eventEntity);
            
            return CreatedAtRoute("GetEvent",new { id = eventToReturn.Id }, eventToReturn);
        }
    }
}
