using FinalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalEntity;
using Final.App_Start;
using System.Web.Security;

namespace Final.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        IUserService service;
        IBillService Billservice;
        IComplainService ComplainService;
        Service<User> s;

        public UserController()
        {
            this.s = new Service<User>();
            this.service = Injector.Container.Resolve<IUserService>();
            this.Billservice = Injector.Container.Resolve<IBillService>();
            this.ComplainService = Injector.Container.Resolve<IComplainService>();

        }

        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        [HttpGet]
        public ActionResult Registration()
        {
            Session["ID"] = 0;
            return View();
        }


        [HttpPost]
        public ActionResult Registration(User user,string ConfirmPass)
        {
            
            User u = this.service.GetByEmail(user.Email);
            user.AdminCheck = false;
            if (ModelState.IsValid && u==null && user.Password==ConfirmPass)
            {
                this.service.Insert(user);
                return RedirectToAction("Login");
            }
            else if (u!= null)
            {
                ModelState.AddModelError("", "This Email Id Already exists!");
                return View(user);
            }
            else if (user.Password != ConfirmPass)
            {
                ModelState.AddModelError("", "Password didn't match!");
                return View(user);
            }
            else
            {
                return View(user);
            }
            
        }
        [HttpGet]
        public ActionResult Login()
        {
            Session["ID"] = 0;
            ViewBag.loginmessage = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email,string pass)
        {
            User user = this.service.GetByEmailPass(Email,pass);
           
            if (user!= null)
            {
                if (Email == user.Email && pass == user.Password && user.AdminCheck==false)
                {
                    Response.Write(user.Email + user.Password);
                    Session["ID"] = user.Id;
                   
                    return RedirectToAction("profile");

                }
                else if (Email == user.Email && pass == user.Password && user.AdminCheck == true)
                {
                    Response.Write(user.Email + user.Password);
                    Session["ID"] = user.Id;

                    return RedirectToAction("AdminProfile", "Admin");
                }
                else if (Email != user.Email || pass != user.Password)
                {
                    ModelState.AddModelError("", "You have to type the correct User Id!");
                    return View("Login");

                }
            }

            else
            {
                Session["ID"] = 0;
                ViewBag.loginmessage = "Email or password is wrong!!";
            }
            return View();
        }

        public ActionResult profile()
        {
            int id = Convert.ToInt32(Session["ID"]);
            return View(this.service.Get(id));
        }
        [HttpGet]
        public ActionResult Editprofile(int id)
        {
            return View(this.s.Get(id));
        }
        [HttpPost]
        public ActionResult Editprofile(User user)
        {
            if (ModelState.IsValid)
            {
                this.s.Update(user);
                return RedirectToAction("profile");
            }
            else
            {
                return View(user);
            }
        }
        public ActionResult BillDetails()
        {
            int id = Convert.ToInt32(Session["ID"]);
            Bill bill = this.Billservice.GetBillByUserId(id);
            return View(bill);
        }

        [HttpGet]
        public ActionResult CreateComplain()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComplain(Complain com)
        {
           // Session["ComplainId"] = 0;
            if (ModelState.IsValid && com.UserId==Convert.ToInt32( Session["ID"]))
            {
               // Session["ComplainId"] = com.UserId;
                this.ComplainService.Insert(com);
                return RedirectToAction("ComplainDetails");
            }
            else if (com.UserId != Convert.ToInt32(Session["ID"]))
            {
                ModelState.AddModelError("", "You have to type the correct User Id!");
                return View(com);
            }
            else
            {
                return View(com);
            }
            
        }
        public ActionResult ComplainDetails()
        {
            int Uid = Convert.ToInt32(Session["ID"]);
            int cid = Convert.ToInt32(Session["ComplainId"]); 
            Complain comp = this.ComplainService.GetComplainByUserId(Uid);
            return View(this.ComplainService.Get(comp.Id));
            
        }

        public ActionResult Logout()
        {
           
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
          //  Session["ID"] = 0;
            return RedirectToAction("Login");
          //  return View("okk");

        }
        //public ActionResult ComplainDelete()
        //{
        //    //int id = Convert.ToInt32(Session["ID"]);
        //    this.ComplainService.Delete()
        //    return RedirectToAction("ComplainDetails");

        //}
    }
}
