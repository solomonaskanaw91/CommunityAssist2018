using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018.Models;

namespace CommunityAssist2018.Controllers
{
    public class GrantApplicationController : Controller
    {
        // GET: GrantApplication
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message msg = new Message();
                msg.MessageText = "Please logged in to apply";
                return RedirectToAction("Result", msg);
            }
            ViewBag.GrantList = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, GrantTypeKey, GrantApplicationDate, GrantApplicationReason, GrantApplicationRequestedAmount, GrantApplicationStatusKey ")]GrantApplication g)
        {
            try
            {
                g.PersonKey = (int)Session["PersonKey"];
                g.GrantAppicationDate = DateTime.Now;
                g.GrantApplicationStatusKey = 1;
                db.SaveChanges();
                Message m = new Message("Thank you. Application has been received!.");
                return RedirectToAction("Result", m);
            }
            catch (Exception e)
            {
                Message m = new Message();
                m.MessageText = e.Message;
                return RedirectToAction("Result", m);
            }
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }

}
