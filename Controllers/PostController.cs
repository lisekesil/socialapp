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
    public class PostController : Controller
    {
        private IPostRepository repository;
        private IUserRepository userRepository;
        private ICommentRepository commentRepository;
        public PostController(IPostRepository repository, IUserRepository userRepository, ICommentRepository commentRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.commentRepository = commentRepository;
        }

        // GET: Post
        public ActionResult Index()
        {
            var user = userRepository.Find(User.Identity.Name);
            if(user != null)
            {
                return View(repository.FindPostsByUserId(user.Id));
            } else
            {
                return View();
            }
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View(new PostModel());
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostModel postModel)
        {
            var user = userRepository.Find(User.Identity.Name);
            repository.AddPost(new PostModel()
            {
                DateTime = DateTime.Now,
                Content = postModel.Content,
                UserId = user.Id,
            });

            return RedirectToAction(nameof(Index));
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.GetPost(id));
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostModel postModel)
        {
            repository.UpdatePost(id, postModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.GetPost(id));
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PostModel postModel)
        {
            repository.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
