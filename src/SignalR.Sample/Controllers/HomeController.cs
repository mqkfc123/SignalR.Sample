using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Sample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Room()
        {
            return View();
        }

        //发送通知
        public ActionResult SendNotice()
        {
            ViewBag.Data = "liuyl答题";
            return View();
        }


    }
}