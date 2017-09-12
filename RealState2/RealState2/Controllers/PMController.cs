using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealState2.Models;
using System.Net;
using System.Data.Entity;

namespace RealState2.Controllers
{
    public class PMController : Controller
    {
        private RealState2Context db = new RealState2Context();
        // GET: PM
        public ActionResult PieCart()
        {
            return View(db.Projects.ToList());
        }
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                List<object> MyModel = new List<object>();
                MyModel.Add(db.Users.ToList());
                MyModel.Add(db.Projects.ToList());
                return View(MyModel);
            }
            return RedirectToAction("Login", "RegisterLogin");
        }
        // GET: Projects/Edit/5
        public ActionResult AcceptOrReject(long? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptOrReject([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,PMAccept,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        public ActionResult Submit(long? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,PMAccept,TLAccept,JEAccept,Assign,Delivered,Submit,Report,Feedback,Comments")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        // GET: Projects/Edit/5
        public ActionResult CreateTeam(long? id)
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
        public ActionResult s(string searchstring, long? id)
        {
            var co = from c in db.Users select c;
            if(!String.IsNullOrEmpty(searchstring))
            {
                if (searchstring == "TL"|| searchstring == "JE")
                {
                    co = co.Where(s => s.JobRole.Contains(searchstring));
                }
            }
            return View(co);
        }
        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTeam([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,PMAccept,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        // GET: Projects/Edit/5
        public ActionResult EditTeam(long? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeam([Bind(Include = "ID,CustomerName,PMName,TLName,JEName,Name,Description,Price,Date,Code,Comment,Approval,PMAccept,TLAccept,JEAccept,Assign,Delivered,Feedback")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        public ActionResult PMHome()
        {
            return View(db.Projects.ToList());

        }
    }
}