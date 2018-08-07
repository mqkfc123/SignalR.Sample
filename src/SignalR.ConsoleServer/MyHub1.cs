using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.ConsoleServer
{
    public class MyHub1 : Hub
    {
        public void Hello()
        { 
            Clients.All.Welcome("Welcome SignalR Hub");
        }

    }

}