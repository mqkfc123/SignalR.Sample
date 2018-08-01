using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace SignalR.Sample
{
    public class MyConnection1 : PersistentConnection
    {
        public MyConnection1()
        {
            Debug.WriteLine("构造函数初始化");
        }

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, "Welcome!");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }

        public override void Initialize(IDependencyResolver resolver)
        {
            Debug.WriteLine("Initialize");

            base.Initialize(resolver);
        }


    }
}