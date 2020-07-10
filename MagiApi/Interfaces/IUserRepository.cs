using MagiApi.Models;
using System.Collections.Generic;

namespace MagiApi.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        bool UserExists(int userId);
        void AddUser(User userEntity);
        bool Save();
    }
}
