using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialapp.Models;
using socialapp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Controllers
{
    [Authorize]
    public class FindController : Controller
    {
        private IUserRepository repository;
        private IPostRepository postRepository;
        public FindController(IUserRepository repository, IPostRepository postRepository)
        {
            this.repository = repository;
            this.postRepository = postRepository;
        }
        // GET: FindController
        public ActionResult Index(string searching)
        {
            var users = new List<UserModel>();
            if (!String.IsNullOrEmpty(searching))
            {
                users = repository.FindUsersBySearch(searching);
            }

            return View(users);
        }
 
        public ActionResult Details(string id)
        {
            var user = repository.FindById(id);
            var posts = postRepository.FindPostsByUserId(id);
            var userPosts = new UserPosts()
            {
                User = user,
                Posts = posts
            };

            return View(userPosts);
        }
    }
}
