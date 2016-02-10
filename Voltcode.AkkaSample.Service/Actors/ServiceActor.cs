using System;

using Akka.Actor;

namespace Voltcode.AkkaSample.Service.Actors
{
    public class ServiceActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message == "hello")
            {                
                Console.WriteLine("ServiceActor HELLO received");

                Context.ActorSelection("akka.tcp://voltcode@localhost:5001/user/appActor").Tell("hello");
            }
        }
    }
}
