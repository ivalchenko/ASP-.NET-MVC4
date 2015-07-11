using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        //
        // GET: /Guestbook/
        // 
        private Guestbook.Models.GuestbookContext _db = new Guestbook.Models.GuestbookContext();

        public ActionResult Index()
        {
            var mostRecentEntries = (from entry in _db.Entries orderby entry.PostDate descending select entry).Take(20);
            ViewBag.Entries = mostRecentEntries.ToList();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] // action selector
        public ActionResult Create(Guestbook.Models.GuestbookEntry entry) // model binding
        {
            entry.UserName = User.Identity.Name;
            entry.PostDate = DateTime.Now;
            _db.Entries.Add(entry);
            _db.SaveChanges();
            //return Content("New entry successfully added.");
            return RedirectToAction("Index"); // HTTP 302
        }

        public ActionResult Show(int id)
        {
            var entry = _db.Entries.Find(id);
            //bool hasPermission = User.Identity.Name == entry.UserName;
            //ViewData["hasPermission"] = hasPermission;
            return View(entry);
        }

    }
}
