using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealState2.Models;
namespace RealState2.Controllers
{
    public class RegisterLoginController : Controller
    {
        // GET: RegisterLogin
        public ActionResult Index()
        {
            using (RealState2Context db = new RealState2Context())
            {
                return View(db.Users.ToList());
            }
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (RealState2Context db = new RealState2Context())
                {
                    db.Users.Add(user);
                        db.SaveChanges();
                    
                }
                ModelState.Clear();
                ViewBag.Message = user.UserName + " " + "Success.";

                if(user.JobRole=="Admin")
                  return RedirectToAction("Index", "Admin");
                else if (user.JobRole == "PM")
                    return RedirectToAction("Index", "PM");
                else if (user.JobRole == "TL")
                    return RedirectToAction("Index", "TL");
                else if (user.JobRole == "JE")
                    return RedirectToAction("Index", "JE");
                else if (user.JobRole == "Customer")
                    return RedirectToAction("Index", "Customer");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User userl)
        {
            using (RealState2Context db = new RealState2Context())
            {
                try {
                    var usr = db.Users.Single(u => u.UserName == userl.UserName && u.Password == userl.Password);
                    if (usr != null)
                    {
                        Session["ID"] = usr.ID.ToString();
                        Session["UserName"] = usr.UserName.ToString();
                        Session["FirstName"] = usr.FirstName.ToString();
                        Session["LastName"] = usr.LastName.ToString();
                        Session["Mobile"] = usr.Mobile.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["JobDescription"] = usr.JobDescription.ToString();
                        Session["JobRole"] = usr.JobRole.ToString();
                        //return RedirectToAction("Loggedin");
                        if (userl.JobRole == "Admin")
                            return RedirectToAction("Index", "Admin");
                        else if (userl.JobRole == "PM")
                            return RedirectToAction("Index", "PM");
                        else if (userl.JobRole == "TL")
                            return RedirectToAction("Index", "TL");
                        else if (userl.JobRole == "JE")
                            return RedirectToAction("Index", "JE");
                        else if (userl.JobRole == "Customer")
                            return RedirectToAction("Index", "Customer");
                    }
                    else
                        ModelState.AddModelError("", "Info Is Wrong.");
                }
                catch(Exception ex)
                {
                    
                    this.Session["userName OR password is incorrect"] = ex.Message;
                    Response.Redirect("Login.cshtml");
                    Response.Write(ex.Message + ex.StackTrace);
                    
                   
                }
                }
            return View();
        }
        public ActionResult Loggedin()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
}
}