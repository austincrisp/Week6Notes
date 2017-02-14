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

        [Route("u/{username}")]
        public ActionResult Detail(string userName)
        {
            ApplicationUser userInstance = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
            string me = User.Identity.GetUserId();
            string target = userInstance.Id;
            bool isFriend = db.Friends
                .Where(
                    f => (f.RequestorId == me && f.TargetId == target) ||
                         (f.TargetId == me && f.RequestorId == target)
                ).Any();
            ViewBag.isFriend = isFriend;
            return View(userInstance);
        }

        [HttpPost]
        [Route("u/{username}")]
        public ActionResult AddFriend(string userName)
        {
            var me = User.Identity.GetUserId();
            string target = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
            Friend relationship = new Friend;
            {
                RequestorId = me,
                TargetId = target
            };
            db.Friends.Add(relationship);
            db.SaveChanges();
            return RedirectToAction("Detail");
        }
    }
}