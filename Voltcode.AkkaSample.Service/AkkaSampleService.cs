using Akka.Actor;
using System;
using Topshelf;

namespace Voltcode.AkkaSample.Service
{
    internal class AkkaSampleService : ServiceControl
    {
        static ActorSystem actorSystem;

        public bool Start(HostControl hostControl)
        {
            actorSystem = ActorSystem.Create("voltcode");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            actorSystem.Terminate().Wait(5000);
            return true;
        }
    }
}