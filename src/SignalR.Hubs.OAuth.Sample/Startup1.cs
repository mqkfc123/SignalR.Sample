using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(SignalR.Hubs.OAuth.Sample.Startup1))]

namespace SignalR.Hubs.OAuth.Sample
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            app.MapSignalR();
            //cookies中间件注册
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                CookieName = "_Token"
            });
            //将自定义的逻辑塞入到Owin管道中
            app.Use<CustomerLoginMiddleware>();
        }

    }

    public class CustomerLoginMiddleware : OwinMiddleware
    {
        /// <summary>
        /// 这里中间件执行后，要给后续的中间件赋值
        /// </summary>
        public CustomerLoginMiddleware(OwinMiddleware next) : base(next)
        {

        }

        public override Task Invoke(IOwinContext context)
        {
            //1. 先判断登入页面
            var path = context.Request.Path.Value;
            if (path.Contains("login.aspx"))
            {
                //2. 读取from信息
                var from = context.Request.ReadFormAsync().Result;
                var username = from["username"];
                var password = from["password"];

                //3.验证username或者password是否是需要的值
                var isSuccess = !string.IsNullOrEmpty(username);

                if (isSuccess)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, username));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    context.Authentication.SignIn(identity);
                    context.Response.StatusCode = 200;
                    context.Response.ReasonPhrase = "Authorize";
                }
                else
                {
                    return null;
                }

            }

            return Next.Invoke(context);
        }

    }

}
