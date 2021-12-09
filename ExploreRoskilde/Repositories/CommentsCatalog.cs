using System.Collections.Generic;
using System.Linq;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Repositories
{
    public class CommentsCatalog : ICommentsCatalog
    {
        public Dictionary<string, Comment> AllComments() => Database.Database.ReadJsonComments();

        public Comment GetCommentById(string id)
        {
            return AllComments()[id];
        }
        
        public List<Comment> GetCommentsByPlaceId(string id)
        {
            return AllComments().Values.Where(i => i.IdPlace == id).ToList();
        }


        public void AddComment(Comment comment)
        {
            Dictionary<string, Comment> comments = AllComments();
            comments.Add(comment.Id, comment);
            Database.Database.WriteToJsonComments(comments);
        }
        
        public void DeleteComment(Comment comment)
        {
            Dictionary<string, Comment> comments = AllComments();
            comments.Remove(comment.Id);
            Database.Database.WriteToJsonComments(comments);
        }
    }
}