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
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

         IUserService service;
         Service<User> s;
         IBillService Billservice;
         IBirthCertificateService Bservice;
         IVoterIdService NIDservice;
         IComplainService ComplainService;
         Service<Complain> cs;

        public AdminController()
        {
            this.service = Injector.Container.Resolve<IUserService>();
            this.s = new Service<User>();
            this.cs = new Service<Complain>();
            this.Billservice = Injector.Container.Resolve<IBillService>();
            this.Bservice = Injector.Container.Resolve<IBirthCertificateService>();
            this.NIDservice = Injector.Container.Resolve<IVoterIdService>();
            this.ComplainService = Injector.Container.Resolve<IComplainService>();

        }

        public ActionResult Index()
        {
            return View(service.GetAll());
        }

       

        public ActionResult AdminProfile()
        {
            int id = Convert.ToInt32(Session["ID"]);
            return View(this.service.Get(id));
        }
        //[HttpGet]
        //public ActionResult UpdateAdmin()
        //{
            
        //    return View();
        //}
        //[HttpPost]
        public ActionResult UpdateAdmin(User user)
        {
           
                return View(this.service.GetAll());
           
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(this.s.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {

            this.s.Update(user);

            return RedirectToAction("UpdateAdmin");

        }
        [HttpGet]
        public ActionResult BillInfo()
        {

            return View(this.service.GetAll());
        }

        [HttpGet]
        public ActionResult CreateBill(int id)
        {
           //ViewBag.userid = id;
            Session["userid"] = id;

            return View();
        }
        [HttpPost]
        public ActionResult CreateBill(Bill bill)
        {
            int userId = Convert.ToInt32(Session["userid"]);
            if (ModelState.IsValid && bill.UserId==userId)
            {
                this.Billservice.Insert(bill);
                return RedirectToAction("BillInfo");
            }
            else if (bill.UserId != userId)
            {
                ModelState.AddModelError("", "You have to type the correct userid!");
            }
          
            return View();
        }
        public ActionResult DetailsBills(int id)
        {

            return View(this.Billservice.GetBillByUserId(id));
        }
        public ActionResult BirthCertificateRegisters()
        {

            return View(this.Bservice.GetAll());
        }
        public ActionResult NIDRegisters()
        {

            return View(this.NIDservice.GetAll());
        }
        public ActionResult UsersComplainInfo()///show complain
        {
            
            return View(this.ComplainService.GetAll());

        }

        public ActionResult Delete(int id)
        {
            Complain com = this.ComplainService.GetComplainById(id);
            this.cs.Delete(com);
            return RedirectToAction("UsersComplainInfo");

        }
        
    }

}

