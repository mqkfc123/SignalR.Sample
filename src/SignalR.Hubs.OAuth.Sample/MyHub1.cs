using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR.Hubs.OAuth.Sample
{
    public class MyHub1 : Hub
    {
        /// <summary>
        /// 
        /// </summary>
        [Authorize]
        public void Hello()
        {
            //this.Context.User.Identity.IsAuthenticated;

            Clients.All.Welcome("欢迎登入");
        }
    }
}