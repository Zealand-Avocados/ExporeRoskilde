using System;
using System.Collections.Generic;
using System.Linq;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Repositories
{
    public class UserFavouritesCatalog : IUserFavouritesCatalog
    {
        public Dictionary<string, UserFavourites> AllUserFavourites() => Database.Database.ReadJsonUserFavourites();


        public List<UserFavourites> GetUserFavouritesByPlaceId(string id)
        {
            return AllUserFavourites().Values.Where(i => i.IdPlace == id).ToList();
        }

        public List<UserFavourites> GetUserFavouritesByUsername(string username)
        {
            return AllUserFavourites().Values.Where(i => i.Username == username).ToList();
        }


        public void AddUserFavourite(UserFavourites userFavourite)
        {
            if (IsUserFavourite(userFavourite.IdPlace, userFavourite.Username)) return;
            Dictionary<string, UserFavourites> userFavourites = AllUserFavourites();
            userFavourites.Add(userFavourite.Id, userFavourite);
            Database.Database.WriteToJsonUserFavourites(userFavourites);
        }

        public void DeleteUserFavouriteById(string id)
        {
            Dictionary<string, UserFavourites> userFavourites = AllUserFavourites();
            userFavourites.Remove(id);
            Database.Database.WriteToJsonUserFavourites(userFavourites);
        }

        public void DeleteUserFavourite(string placeId, string username)
        {
            Dictionary<string, UserFavourites> userFavourites = AllUserFavourites();
            Dictionary<string, UserFavourites> toBeRemoved =
                new Dictionary<string, UserFavourites>(userFavourites.Where(i =>
                    i.Value.IdPlace == placeId && i.Value.Username == username));
            foreach (string id in toBeRemoved.Keys)
            {
                userFavourites.Remove(id);
            }

            Database.Database.WriteToJsonUserFavourites(userFavourites);
        }

        public bool IsUserFavourite(string idPlace, string username)
        {
            if (String.IsNullOrEmpty(username)) return false;
            return GetUserFavouritesByPlaceId(idPlace).Any(i => i.Username == username);
        }
    }
}