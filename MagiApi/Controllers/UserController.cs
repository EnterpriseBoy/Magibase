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
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers() 
        {
            var userEntities = _userRepository.GetUsers();
            //_mapper.Map returns the type we want back and we pass in Source
            return Ok(_mapper.Map<IEnumerable<User>>(userEntities));
        }
    }
}
