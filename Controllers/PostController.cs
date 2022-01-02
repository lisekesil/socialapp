using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Controllers
{
    public class PostController : Controller
    {
        private static IList<PostModel> posts = new List<PostModel>()
        {
            new PostModel() { PostId = 1, Content = "UGAGAGAGGA", DateTime = new DateTime(2008, 6, 1, 7, 47, 0), UserId = 1},
            new PostModel() { PostId = 2, Content = "post numer 2", DateTime = DateTime.Now, UserId = 1}
        };
        // GET: PostController
        public ActionResult Index()
        {
            return View(posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View(new PostModel());
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostModel postModel)
        {
            postModel.PostId = posts.Count + 1;
            postModel.DateTime = DateTime.Now;
            postModel.UserId = 1;
            posts.Add(postModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(posts.FirstOrDefault(x => x.PostId == id));
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostModel postModel)
        {
            PostModel post = posts.FirstOrDefault(x => x.PostId == id);
            post.Content = postModel.Content;
            post.DateTime = DateTime.Now;
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(posts.FirstOrDefault(x => x.PostId == id));
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PostModel postModel)
        {
            PostModel post = posts.FirstOrDefault(x => x.PostId == id);
            posts.Remove(post);
            return RedirectToAction(nameof(Index));
        }
    }
}
