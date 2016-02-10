
using Akka.Actor;

namespace Voltcode.AkkaSample.Web.Actors
{
    public class AppActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message == "hello")
            {
                
            }
        }
    }
}