using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using socialapp.Models;

namespace socialapp.Repositories
{
    public interface IPostRepository
    {
        PostModel AddPost(PostModel post);
        List<PostModel> FindPostsByUserId(string id);

        PostModel GetPost(int postId);
        void UpdatePost(int postId, PostModel post);
        void DeletePost(int postId);
    }
}
