using Microsoft.EntityFrameworkCore.ChangeTracking;
using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Repositories
{
    public class EFPostRepository : IPostRepository
    {
        private AppDbContext context;
        public EFPostRepository(AppDbContext context)
        {
            this.context = context;
        }

        public PostModel AddPost(PostModel post)
        {
            EntityEntry<PostModel> entityEntry = context.Posts.Add(post);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public List<PostModel> FindPostsByUserId(string id)
        {
            return context.Posts.Where(p => p.UserId == id).ToList();
        }

        public PostModel GetPost(int postId)
        {
            return context.Posts.SingleOrDefault(x => x.PostId == postId);
        }

        public void UpdatePost(int postId, PostModel post)
        {
            var result = context.Posts.SingleOrDefault(x => x.PostId == postId);
            if(result != null)
            {
                result.Content = post.Content;
                result.DateTime = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            var result = context.Posts.SingleOrDefault(x => x.PostId == postId);
            if(result != null)
            {
                context.Posts.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
