using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(SignalR.Hubs.Sample.Startup1))]

namespace SignalR.Hubs.Sample
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            //app.MapSignalR();
            //app.MapSignalR("/myHub", new Microsoft.AspNet.SignalR.HubConfiguration());
            app.MapSignalR("/myHub2", new Microsoft.AspNet.SignalR.HubConfiguration());

            //GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(2);

            ////redis
            //GlobalHost.DependencyResolver.UseRedis("localhost", 6379, null, "");
            //app.MapSignalR();
        }
    }
}
