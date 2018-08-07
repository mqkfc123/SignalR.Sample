using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = WebApp.Start("http://localhost:8812");
            Console.Read();

        }

    }
}
