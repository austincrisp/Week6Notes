using Day1AttrRoute.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1AttrRoute.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userInstance = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            return View(userInstance);
        }

        [Route("User/{username}")]
        public ActionResult Detail(string userName)
        {
            var userInstance = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
            return View(userInstance);
        }
    }
}