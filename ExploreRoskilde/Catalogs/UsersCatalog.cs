using System;
using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ExploreRoskilde.Models;
using System.Collections.Generic;

namespace ExploreRoskilde.Catalogs
{
   
    public class UsersCatalog : IUsersCatalog
    {
        public Dictionary<int, User> AllUsers() => Database.Database.ReadJsonUsers(Database.Database.PlacesFilePath);

        public User GetUserById(int id)
        {
            return AllUsers()[id];
        }


        public void AddUser(User user)
        {
            Dictionary<int, User> users = AllUsers();
            users.Add(user.UserId, user);
            Database.Database.WriteToJsonUsers(Database.Database.PlacesFilePath, users);
        }
    }
}
