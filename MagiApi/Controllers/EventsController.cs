using AutoMapper;
using MagiApi.Entities;
using MagiApi.Interfaces;
using MagiApi.Models.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MagiApi.Controllers
{
    /// <summary>
    /// Events Controller for Event related actions
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        /// <summary>
        /// s
        /// </summary>
        /// <param name="eventRepository"></param>
        /// <param name="mapper"></param>
        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <summary>
        /// Returns all the events
        /// </summary>
        /// <returns>List of Event Objects </returns>
        /// <response code ="200"> Returns the list of events</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Event))]
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            var eventEntities = _eventRepository.GetEvents();
            //_mapper.Map returns the type we want back and we pass in Source
            return Ok(_mapper.Map<IEnumerable<Event>>(eventEntities));
        }

        /// <summary>
        /// Returns one event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code ="200"> Returns an Event</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [HttpGet("{id}", Name = "GetEvent")]
        public ActionResult<Event> GetEvent(int id)
        {
            var eventEntity = _eventRepository.GetEvent(id);

            if (eventEntity == null)
                return NotFound();

            return new OkObjectResult(_mapper.Map<Event>(eventEntity));
        }

        /// <summary>
        /// Creates an Event
        /// </summary>
        /// <param name="eventCreateDto"></param>
        /// <returns>Created Event details</returns>
        /// <remarks>
        /// Sample request (This request adds an **Event**)  
        ///     POST /events/id  
        ///     [  
        ///         {  
        ///         }  
        ///     ]  
        /// </remarks>
        /// <response code ="200"> Returns the list of events</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
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