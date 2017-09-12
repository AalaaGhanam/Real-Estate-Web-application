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
    public class CustomerController : Controller
    {
        private RealState2Context db = new RealState2Context();
        // GET: Customer
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return View(db.Projects.ToList());
            }
            return RedirectToAction("Login", "RegisterLogin");
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
        public ActionResult AddP()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddP([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }
        public ActionResult s(string searchstring, long? id)
        {
            var co = from c in db.Users select c;
            if (!String.IsNullOrEmpty(searchstring))
            {
                if (searchstring == "PM")
                {
                    co = co.Where(s => s.JobRole.Contains(searchstring));
                }
            }
            return View(co);
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
        // GET: Projects/Edit/5
        public ActionResult AssignProject(long? id)
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
        public ActionResult AssignProject([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,PMAccept,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        public ActionResult CustomerHome()
        {
            return View(db.Projects.ToList());

        }
    }
}