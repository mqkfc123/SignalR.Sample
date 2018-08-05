using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR.Hubs.Sample
{
    public class MyHub1 : Hub
    {
        public void Hello()
        {
            //获取参数
            var username = this.Context.QueryString["username"];
            Clients.All.Welcome("Welcome SignalR Hub");
        }
    }
}