using FinalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalEntity;
using Final.App_Start;

namespace Final.Controllers
{
    public class BCController : Controller
    {
        //
        // GET: /BC/
        IBirthCertificateService Bservice;
        public BCController()
        {
            this.Bservice = Injector.Container.Resolve<IBirthCertificateService>();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BirthRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BirthRegistration(BirthCertificate birth)
        {
            int id = birth.UserId;
            BirthCertificate bid = this.Bservice.GetByID(id);
            if (ModelState.IsValid && id == Convert.ToInt32(Session["ID"]) && bid==null)
            {
                this.Bservice.Insert(birth);
                ModelState.Clear();
                return RedirectToAction("Details");
            }
            else if (id != Convert.ToInt32(Session["ID"]))
            {
                ModelState.AddModelError("", "You typed wrong UserId!");
                return View(birth);
            }
            else if (bid!= null)
            {
                ModelState.AddModelError("", "You have already registered for Birth Certificate");
                return View(birth);
            }
            else
            {
                return View(birth);
            }
            
        }
        public ActionResult Details()
        {
            int id = Convert.ToInt32(Session["ID"]);
            //Response.Write(id);
            //BirthCertificate bs = this.Bservice.GetByID(id);
            //Response.Write(bs.Id);
            return View(this.Bservice.GetByID(id));
        }

    }
}
