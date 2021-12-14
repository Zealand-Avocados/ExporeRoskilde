using System.Collections.Generic;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Interfaces
{
    public interface IUserFavouritesCatalog
    {
        
        public List<UserFavourites> GetUserFavouritesByPlaceId(string id);
        public List<UserFavourites> GetUserFavouritesByUsername(string username);
        public void AddUserFavourite(UserFavourites userFavourite);
        public void DeleteUserFavouriteById(string id);
        public bool IsUserFavourite(string idPlace, string username);
        public void DeleteUserFavourite(string placeId, string username);







    }
}