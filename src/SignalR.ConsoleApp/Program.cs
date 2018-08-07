using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.ConsoleApp
{
    /// <summary>
    /// 控制台部署客户端
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new HubConnection("http://localhost:7683/signalr");
            var proxy = conn.CreateHubProxy("Hub1");

            proxy.On("Welcome", (msg) =>
            {
                Console.WriteLine(msg);
            });

            conn.Start().Wait();
            var info = proxy.Invoke<string>("Hello", 100).Result;
        }


    }

}
