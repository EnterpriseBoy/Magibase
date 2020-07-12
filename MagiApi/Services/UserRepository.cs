using MagiApi.Context;
using MagiApi.Entities;
using MagiApi.Interfaces;
using MagiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagiApi.Services
{
    public class UserRepository : IUserRepository
    {
        private EventStaffContext _context;

        public UserRepository(EventStaffContext eventStaffContext)
        {
            _context = eventStaffContext?? throw new ArgumentNullException(nameof(eventStaffContext));
        }

        public User GetUser(int eventId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == eventId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UserExists(int userId)
        {
            if (userId.Equals(null))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users.Any(a => a.Id == userId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void AddUser(User userEntity)
        {
            throw new NotImplementedException();
        }
    }
}
