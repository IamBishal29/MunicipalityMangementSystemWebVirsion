using Final.Controllers;
using FinalEntity;
using FinalService;
using Injection;
using Injection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.App_Start
{
    public class Injector
    {
        public static IInjectionContainer Container { get; set; }

        static Injector()
        {
            Container = new Container();
        }

        public static void Configure()
        {

            Container.Register<IUserService, UserService>().Singleton();
            Container.Register<IBirthCertificateService, BirthcertificateService>().Singleton();
             Container.Register<IBillService, BillService>().Singleton();
             Container.Register<IVoterIdService, VoterIdService>().Singleton();
             Container.Register<IComplainService, ComplainService>();
            //ControllerBuilder.Current.SetControllerFactory(new InjectionControllerFactory());
        }
    }
}