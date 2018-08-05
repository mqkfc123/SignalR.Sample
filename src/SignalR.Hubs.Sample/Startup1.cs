using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR.Hubs.Sample.Startup1))]

namespace SignalR.Hubs.Sample
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            //app.MapSignalR();
            app.MapSignalR("/myHub", new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}
