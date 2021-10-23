using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Core.Config;

namespace WebCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigCore.AddConfig<AuthConfig>();
            ConfigCore.AddConfig<DutyConfig>();
            ConfigCore.ConfigInit();
            Console.WriteLine(ConfigCore.GetConfig.GetConfigItem<DutyConfig>("DutyConfig").SavePath);
            //ConfigCore.GetConfig["DutyConfig"]
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
