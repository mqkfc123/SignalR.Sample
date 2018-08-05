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


        /*Hub中的clients属性和groups属性的操作。*/
        public void GroupHello()
        {
            Clients.All.Welcome($"Welcome SignalR GroupHello:{this.Context.ConnectionId}");

            //去除当前的人
            //Clients.AllExcept(this.Context.ConnectionId).Welcome($"Welcome SignalR GroupHello:{this.Context.ConnectionId}"); 

            //给指定的人发送消息
            //Clients.Client(this.Context.ConnectionId).Welcome($"Welcome SignalR GroupHello:{this.Context.ConnectionId}");
            //给一组人发送
            //Clients.Clients
            //组的概念
            // Clients.Group("room1","dd");
            // 给指定房间中的指定人发送消息
            // Clients.Groups();

            //userID授权登入
            //Clients.User(this.Context.Request.User.Identity.Name);

            //Clients.Users();

            //this.Groups.Add();
            //this.Groups.Remove();
        }



    }
}