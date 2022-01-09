using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Mgt.Models;

namespace Student_Mgt.Controllers
{
    public class LoginController : Controller
    {

        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
          [HttpPost]
          [ValidateAntiForgeryToken]
        public ActionResult Index(user objck)
        {
            if(ModelState.IsValid)
            {
                using (Student_MgtEntities db = new Student_MgtEntities())
                {
                    var obj = db.users.Where(a => a.username.Equals(objck.username) && a.password.Equals(objck.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("" ,"The UserName and Password is Incorrect!");
                    }
                }
            }

           
            return View(objck);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index" ,"Login");
        }

    }
}