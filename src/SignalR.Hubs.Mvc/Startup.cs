using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(SignalR.Hubs.Mvc.Startup))]
namespace SignalR.Hubs.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    public abstract class BaseController<T> : Controller where T : PersistentConnection
    {
        public IConnection Connection { get; set; }

        public IConnectionGroupManager Groups { get; set; }

        public BaseController()
        {
            var gh = GlobalHost.ConnectionManager.GetConnectionContext<T>();
            Groups = gh.Groups;
        }

    }

}
