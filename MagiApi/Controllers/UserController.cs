using AutoMapper;
using MagiApi.Interfaces;
using MagiApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagiApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IParticipantRepository _userRepository;

        public UserController(IParticipantRepository userRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var participantsEntities = _userRepository.GetParticipants();
            //_mapper.Map returns the type we want back and we pass in Source
            return Ok(_mapper.Map<IEnumerable<Participant>>(participantsEntities));
        }

        [HttpGet("{id}", Name = "GetUser")]
        [HttpHead]
        public ActionResult<UserDto>GetUser(int id)
        {
            var userEntity = _userRepository.GetParticipant(id);

            if (userEntity == null)
                return NotFound();

            return new OkObjectResult(_mapper.Map<Participant>(userEntity));
        }
    }
}
