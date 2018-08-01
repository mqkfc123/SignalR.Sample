using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SignalR.Sample
{
    public class MyConnection1 : PersistentConnection
    {
        #region

        //public MyConnection1()
        //{
        //    Debug.WriteLine("构造函数初始化");
        //}

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            var examUseId = request.QueryString["ExamUseId"];

            this.Groups.Add(connectionId, examUseId);

            return Connection.Send(connectionId, "Welcome!");
        }

        //protected override Task OnReceived(IRequest request, string connectionId, string data)
        //{
        //    return Connection.Broadcast(data);
        //}

        //public override void Initialize(IDependencyResolver resolver)
        //{
        //    Debug.WriteLine("Initialize");
        //    base.Initialize(resolver);
        //}
        #endregion

        //持久连接中的聊天室
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            //data进来后是一个json对象 {roomname:"",data:"Welcome",}
            //return Connection.Broadcast(data); 
            //this.Groups 获取或设置连接组
            var model = JsonConvert.DeserializeObject<MyTest>(data);
            if (model.Action == "Welcome")
            {
                //通知组
                //this.Groups.Add(connectionId, model.RoomName);
                ////除了当前房间这个人，其他人都能获得推送
                //return this.Groups.Send(model.RoomName, $"Welcome New User {connectionId}", connectionId);
            }
            else
            {
                //model.Data是我们要发送的参数
            }

            return this.Groups.Send(model.RoomName, model.Data, connectionId);

        }

    }

    public class MyTest
    {
        public string RoomName { get; set; }

        public string Data { get; set; }

        public string Action { get; set; }

    }

}