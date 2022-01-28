using Microsoft.EntityFrameworkCore.ChangeTracking;
using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Repositories
{
    public class EFCommentRepository : ICommentRepository
    {
        private AppDbContext context;
        public EFCommentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public CommentModel Add(CommentModel commentModel)
        {
            EntityEntry<CommentModel> entityEntry = context.Comments.Add(commentModel);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            var result = context.Comments.SingleOrDefault(x => x.CommentId == id);
            if (result != null)
            {
                context.Comments.Remove(result);
                context.SaveChanges();
            }
        }

        public CommentModel Find(int id)
        {
            return context.Comments.SingleOrDefault(x => x.CommentId == id);
        }

        public IList<CommentModel> FindAllByPost(int postId)
        {
            return context.Comments.Where(x => x.PostId == postId).ToList();
        }
    }
}
