using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Models
{
    public class UserPosts
    {
        public UserModel User { get; set; }
        public List<PostModel> Posts { get; set; }
    }
}
