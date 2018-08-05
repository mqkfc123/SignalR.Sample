using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Hubs.Sample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 无代理js模式
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            return View();
        }


        /// <summary>
        /// Hub的Server操作 
        /// 和Persistent差不多
        /// </summary>
        /// <returns></returns>
        public ActionResult Index3()
        {
            return View();
        }
        /// <summary>
        /// Hub中的clients属性和groups属性的操作。
        /// </summary>
        /// <returns></returns>
        public ActionResult MyGroups()
        {
            return View();
        }

        /// <summary>
        /// GlobalHost 第三方监控
        /// </summary>
        /// <returns></returns>
        public ActionResult OtherIndex()
        {
            return View();
        }

        /// <summary>
        /// GlobalHost 第三方监控
        /// </summary>
        /// <returns></returns>
        public ActionResult Other()
        {
            Thread.Sleep(5000);

            var connectionID = MyHub2.list[0];
            //获取当前的持久连接
            //GlobalHost.ConnectionManager.GetConnectionContext<MyHub2>();

            var hub = GlobalHost.ConnectionManager.GetHubContext<MyHub2>();

            hub.Clients.Client(connectionID).notice("您当前已经欠费");
            return View();
        }
        

    }
}