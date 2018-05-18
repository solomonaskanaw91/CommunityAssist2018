using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018.Models;

namespace CommunityAssist2018.Controllers

{
    public class LoginController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email, Password")]LoginClass lc)
        {
            Message msg = new Message();
            int results = db.usp_Login(lc.Email, lc.Password);
            int revKey = 0;
            if (results != -1)
            {
                var pkey = (from r in db.People
                            where r.PersonEmail.Equals(lc.Email)
                            select r.PersonKey).FirstOrDefault();
                revKey = (int)pkey;
                Session["PersonKey"] = revKey;

                //msg.MessageText = "Welcome, " + lc.Email;
                return RedirectToAction("Login");
            }
            else
            {
                msg.MessageText = "Invaild Login";
            }
            return View("result", msg);
    }
        public ActionResult Result (Message msg)
        {
            return View(msg);
        }
    }
}