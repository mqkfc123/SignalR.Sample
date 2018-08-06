using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Hubs;

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

            //GlobalHost.DependencyResolver = new CustomerDependencyResolver();

        }
    }

    public class CustomerDependencyResolver : DefaultDependencyResolver
    {

        public override object GetService(Type serviceType)
        {
            var model = base.GetService(serviceType);

            return model;

        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

    }

    public class MyJavaScriptMinifier : IJavaScriptMinifier
    {
        public string Minify(string source)
        {
            throw new NotImplementedException();
        }
    }

}

