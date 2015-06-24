using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using Microsoft.AspNet.Identity;

namespace HelloWorld.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.Include(s=>s.Tags).ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int postId = (int)id;
            PostComment postComment = new PostComment();
            postComment.Post = db.Posts.Find(id);
            postComment.Comments = db.Comments.Where(s => s.Post.PostId == postId).ToList();
            
            ViewBag.CurrentUserId = User.Identity.GetUserId();

            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            CreatePostView model = new CreatePostView();
            model.TagList = new SelectList(db.Tags);
            
            return View(model);
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostView post)
        {
            Post currPost = new Post {  
                                       Title = post.Title, 
                                       Description = post.Description, 
                                       PostDate = DateTime.Now, 
                                       Tags = null,
                                       CommentsNumber = 0,
                                       LikesNumber = 0
                                     };

            if (ModelState.IsValid)
            {
                var tags = db.Tags.Where(s => s.TagName.Equals(post.SelectedTag)).ToList();  
                currPost.Tags = tags;
                db.Posts.Add(currPost);
                db.SaveChanges();
                return RedirectToAction("Index", "Posts");
            }

            return View(currPost);
        }

        // GET: Posts/ByTag/tagName
        public ActionResult ByTag(string tagName)
        {

            //return View(db.Posts.Include(s => s.Tags).ToList());

            List<Post> Posts = new List<Post>();
            //Posts = db.Posts.ToList();

            foreach (var post in db.Posts.Include(s => s.Tags).ToList())
            {
                if (post.Tags != null && post.Tags.Count > 0)
                {
                    foreach (var tag in post.Tags)
                    {
                        if (tag.TagName.Equals(tagName))
                            Posts.Add(post);
                    }
                }
            }

            return View("Index", Posts);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "PostId,Title,Description")]*/ Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostDate = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
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
