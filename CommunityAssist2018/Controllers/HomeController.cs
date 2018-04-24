using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018.Models;

namespace CommunityAssist2018.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {   ////initalize entities classes
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            //pass the collection catergories to the index as a list
            return View(db.GrantTypes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}