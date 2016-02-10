using Akka.Actor;
using System;

using Akka.Actor.Dsl;

using Topshelf;

using Voltcode.AkkaSample.Service.Actors;

namespace Voltcode.AkkaSample.Service
{
    internal class AkkaSampleService : ServiceControl
    {
        static ActorSystem actorSystem;

        private static IActorRef serviceActor;

        public bool Start(HostControl hostControl)
        {
            actorSystem = ActorSystem.Create("voltcode");

            serviceActor = actorSystem.ActorOf<ServiceActor>();

            actorSystem.Scheduler.ScheduleTellRepeatedly(new TimeSpan(0,0,0), new TimeSpan(0,0,2), serviceActor, "hello", ActorRefs.NoSender  );

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            actorSystem.Terminate().Wait(5000);
            return true;
        }
    }
}