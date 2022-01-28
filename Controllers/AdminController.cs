using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "AdminAccess")]
    public class AdminController : Controller
    {
        private IUserRepository userRepository;

        public AdminController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View(userRepository.FindAll());
        }

        public ActionResult Delete(string id)
        {
            return View(userRepository.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, UserModel userModel)
        {
            userRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
