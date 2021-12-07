using ExploreRoskilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreRoskilde.Interfaces
{
    public interface IUsersCatalog
    {
        public Dictionary<int, User> AllUsers();
        public User GetUserById(int id);
        public void AddUser(User place);
    }
}
