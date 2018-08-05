using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR.Hubs.Sample
{
    public class MyHub2 : Hub
    {
        public static List<string> list = new List<string>();

        public void Hello()
        {
            Clients.All.Welcome("当前登入成功");
        }

        public override Task OnConnected()
        {
            list.Add(this.Context.ConnectionId);
            return base.OnConnected();
        }

        /// <summary>
        /// 断连
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            list.Remove(this.Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 重连
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

    }
}