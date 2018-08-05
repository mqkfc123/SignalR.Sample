using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}