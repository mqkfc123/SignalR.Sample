using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Hubs.Sample
{
    public class MyHub1 : Hub
    {
        //public void Hello()
        //{
        //    //获取参数
        //    var username = this.Context.QueryString["username"];
        //    Clients.All.Welcome("Welcome SignalR Hub");
        //}
        public void Hello(int msg)
        {
            Clients.All.Welcome("Welcome SignalR Hub");
        }
      
        [HubMethodName("MyHolle")]
        public void Hello(string msg)
        {
            Clients.All.Welcome("我是字符串");
        }

        /*下面三个重写方法来维护connetionID*/

        public override Task OnConnected()
        {
            var connectionId = this.Context.ConnectionId;

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }


    }
}