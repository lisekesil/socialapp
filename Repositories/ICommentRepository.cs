using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Repositories
{
    public interface ICommentRepository
    {
        CommentModel Find(int id);
        IList<CommentModel> FindAllByPost(int postId);

        void Delete(int id);
        CommentModel Add(CommentModel commentModel);
    }
}
