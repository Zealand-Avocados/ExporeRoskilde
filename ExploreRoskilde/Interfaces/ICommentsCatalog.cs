using System.Collections.Generic;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Interfaces
{
    public interface ICommentsCatalog
    {
        public Comment GetCommentById(string id);

        public void AddComment(Comment place);

        public List<Comment> GetCommentsByPlaceId(string id);
        
        public void DeleteComment(Comment place);
    }
}