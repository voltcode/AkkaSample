using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Voltcode.AkkaSample.Web.Actors;

namespace Voltcode.AkkaSample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static ActorSystem actorSystem;

        private static IActorRef appActor;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            actorSystem = ActorSystem.Create("voltcode");

            appActor = actorSystem.ActorOf<AppActor>("appActor");
        }

        protected void Application_End()
        {
            actorSystem.Terminate().Wait(5000);
        }
    }
}
