using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class ImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Images
        public ActionResult Art()
        {
            return View(db.Images.ToList());
        }

        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        /*GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGg*/

        // POST: Images/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        /*public ActionResult Create(Image image, HttpPostedFileBase file)
        {
            string newFileName = "";
            if (file != null && file.ContentLength > 0)
            {
                var fileName = System.IO.Path.GetFileName(file.FileName);
                string format = file.ContentType;
                Console.Out.Write(format);
                newFileName = Guid.NewGuid().ToString() + fileName; //global identificator
                var path = System.IO.Path.Combine(Server.MapPath("../../Content/img/upload/"), newFileName);
                file.SaveAs(path);
                image.ImagePath = newFileName;

                return RedirectToAction("Art");
            }
            return View(image);
        }*/
        
        public ActionResult Create(Image img, HttpPostedFileBase file)
        {
            //if (ModelState.IsValid)
            //{
            if (file != null && file.ContentLength > 0)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Content/img/") + file.FileName);
                img.ImagePath = file.FileName;
                db.Images.Add(img);
                db.SaveChanges();
                return RedirectToAction("Art");
            }
            //}
            return RedirectToAction("Create","Images");
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Art");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
