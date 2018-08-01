using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR.Sample.Startup1))]

namespace SignalR.Sample
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            //app.MapSignalR<MyConnection1>("/myconn");
            //开启jsonp
            //app.MapSignalR<MyConnection1>("/myconn", new Microsoft.AspNet.SignalR.ConnectionConfiguration()
            //{
            //    EnableJSONP = true
            //});


            app.Map("/myconn", (map) =>
            {
                map.RunSignalR<MyConnection1>(new Microsoft.AspNet.SignalR.HubConfiguration()
                {
                    //1. 开启jsonp 跨域
                    EnableJSONP = true
                });
                //2.开启cors 跨域
                //从nuget中获取一个中间件Microsoft.Owin.Cors 
                map.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            });


        }
    }
}
