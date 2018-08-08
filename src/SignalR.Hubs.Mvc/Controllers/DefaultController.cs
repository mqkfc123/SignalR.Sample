using SignalR.Hubs.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Hubs.Mvc.Controllers
{
    public class DefaultController : BaseController<MyConnection1>
    {
        // GET: Default
        public ActionResult Index()
        {

            return View();
        }

    }
}