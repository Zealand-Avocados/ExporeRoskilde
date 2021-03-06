using ExploreRoskilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreRoskilde.Interfaces
{
    public interface IUsersCatalog
    {
        public Dictionary<string, User> AllUsers();
        public User GetUserById(string id);
        public bool Register(User user);
        public User Login(string username, string password);

        public User GetUserByUsername(string username);

    }
}
