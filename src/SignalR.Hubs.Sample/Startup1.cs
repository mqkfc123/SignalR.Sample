using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Ajax.Utilities;
using System.Linq;

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

            //GlobalHost.HubPipeline.AddModule(new CustomerHubPipeLineMouble());
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
            return new Minifier().MinifyJavaScript(source);
            //throw new NotImplementedException();
        }
    }


    /// <summary>
    /// HubPipeLine管道
    /// 方法执行之前，方法执行之后的拦截。
    /// </summary>
    public class CustomerHubPipeLineMouble : IHubPipelineModule
    {
        public Func<HubDescriptor, IRequest, bool> BuildAuthorizeConnect(Func<HubDescriptor, IRequest, bool> authorizeConnect)
        {
            throw new NotImplementedException();
        }

        public Func<IHub, Task> BuildConnect(Func<IHub, Task> connect)
        {
            throw new NotImplementedException();
        }

        public Func<IHub, bool, Task> BuildDisconnect(Func<IHub, bool, Task> disconnect)
        {
            return disconnect;

        }

        /// <summary>
        /// 入流
        /// </summary>
        /// <param name="invoke"></param>
        /// <returns></returns>
        public Func<IHubIncomingInvokerContext, Task<object>> BuildIncoming(Func<IHubIncomingInvokerContext, Task<object>> invoke)
        {
            return (context) =>
            {
                var method = context.MethodDescriptor.Name;
                var args = context.Args.ToList();
                //日志
                //逻辑判断

                return invoke(context);
            };

        }

        /// <summary>
        /// 出流
        /// </summary>
        /// <param name="send"></param>
        /// <returns></returns>
        public Func<IHubOutgoingInvokerContext, Task> BuildOutgoing(Func<IHubOutgoingInvokerContext, Task> send)
        {
            return send;

        }

        public Func<IHub, Task> BuildReconnect(Func<IHub, Task> reconnect)
        {
            return reconnect;
        }

        public Func<HubDescriptor, IRequest, IList<string>, IList<string>> BuildRejoiningGroups(Func<HubDescriptor, IRequest, IList<string>, IList<string>> rejoiningGroups)
        {
            return rejoiningGroups;
        }
    }

}

