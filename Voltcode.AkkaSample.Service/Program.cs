using Akka.Actor;
using Topshelf;

namespace Voltcode.AkkaSample.Service
{
    class Program
    {
        static ActorSystem actorSystem;

        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.SetServiceName("Voltcode.AkkaSample.Service");
                x.SetDisplayName("Voltcode.AkkaSample.Service");
                x.SetDescription("Voltcode.AkkaSample.Service");

                x.UseAssemblyInfoForServiceInfo();
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.Service<AkkaSampleService>();
                x.EnableServiceRecovery(r => r.RestartService(1));
            });
        }
    }
}
