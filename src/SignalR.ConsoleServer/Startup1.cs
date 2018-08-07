using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR.ConsoleServer.Startup1))]

namespace SignalR.ConsoleServer
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            //app.MapSignalR();

            //安装跨域中间件
            //2.开启cors 跨域
            //从nuget中获取一个中间件Microsoft.Owin.Cors 
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll).MapSignalR();

        }
    }
}
