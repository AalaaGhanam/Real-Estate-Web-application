using RealState2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RealState2.Controllers
{
    public class AdminController : Controller
    {
        private RealState2Context db = new RealState2Context();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return View(db.Projects.ToList());
            }
            return RedirectToAction("Login", "RegisterLogin");
        }
        public ActionResult ControlUser()
        {
            return View(db.Users.ToList());
        }
        public ActionResult HomePage()
        {
            return View(db.Projects.ToList());
        }
        // GET: Users/Create
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser([Bind(Include = "ID,FirstName,LastName,UserName,Password,Mobile,Email,JobDescription,JobRole")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("ControlUser");
            }

            return View(user);
        }
        
        // GET: Users/Delete/5
        public ActionResult DeleteUser(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ControlUser");
        }
        
        // GET: Projects/Edit/5
        public ActionResult ApproveProject(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveProject([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,PMAccept,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        public ActionResult AddProject()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProject([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }
        // GET: Projects/Edit/5
        public ActionResult UpdateProject(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProject([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        // GET: Projects/Delete/5
        public ActionResult DeleteProject(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("DeleteProject")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProjectConfirmed(long id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}