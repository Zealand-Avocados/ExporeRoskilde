using ExploreRoskilde.Models;
using System.Collections.Generic;

namespace ExploreRoskilde.Interfaces
{
        public interface IUsersCatalog
        {
            public Dictionary<int, User> AllUsers();
            public User GetUserById(int id);
            public void AddUser(User place);
        }
}
