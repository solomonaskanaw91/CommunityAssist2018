using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018.Models;
namespace CommunityAssist2018.Controllers
{
    public class RegisterController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "lastname, firstname, email, password,ApartmentNumber, Street, City, State, Zipcode, Phone")]NewPerson n)
        {
            Message m = new Message();
            int result = db.usp_Register(n.lastName, n.firstName, n.email, n.password, n.ApartmentNumber, n.Street, n.City, n.State, n.Zipcode, n.Phone);
            if (result != -1)
            {
                m.MessageText = "Welcome, " + n.firstName + n.firstName;
            }
            else
            {
                m.MessageText = "Something went horribly wrong";
            }
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}