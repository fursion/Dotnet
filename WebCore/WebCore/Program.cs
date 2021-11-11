using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Core;
using WebCore.Core.Config;

namespace WebCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DutyHander hander = new();
            //WebCore.Core.Tools.ExcelTools.test();
            
            ConfigCore.AddConfig<AuthConfig>();
            ConfigCore.AddConfig<DutyConfig>();
            ConfigCore.ConfigInit().Wait();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
