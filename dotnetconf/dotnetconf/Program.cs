using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dotnetconf
{
    public class Program
    {
        public static void Main(string[] args)
        {

#if DEBUG
            //Console.WriteLine("Waiting for debugger to attach");

            //while (!Debugger.IsAttached)
            //{
            //    Thread.Sleep(100);
            //}
            //Console.WriteLine("Debugger attached");
#endif
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
