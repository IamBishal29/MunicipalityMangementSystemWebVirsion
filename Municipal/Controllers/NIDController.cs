using Final.App_Start;
using FinalEntity;
using FinalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class NIDController : Controller
    {
        //
        // GET: /NID/
        IVoterIdService NIDservice;
        public NIDController()
        {
            this.NIDservice = Injector.Container.Resolve<IVoterIdService>();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NIDRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NIDRegistration(VoterId voterId)
        {
            int uid = voterId.UserId;
            VoterId vId = this.NIDservice.GetByUserID(uid);
            if (ModelState.IsValid && uid == Convert.ToInt32(Session["ID"]) && vId == null)
            {
                this.NIDservice.Insert(voterId);
                ModelState.Clear();
                return RedirectToAction("Details");
            }
            else if (uid != Convert.ToInt32(Session["ID"]))
            {
                ModelState.AddModelError("", "You typed wrong UserId!");
                return View(voterId);
            }
            else if (vId != null)
            {
                ModelState.AddModelError("", "You have already registered for VoterId");
                return View(voterId);
            }
            else
            {
                return View(voterId);
            }

        }
        public ActionResult Details()
        {
            int id = Convert.ToInt32(Session["ID"]);
            return View(this.NIDservice.GetByUserID(id));
        }


    }
}
