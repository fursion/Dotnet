using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
namespace WebServer
{
    public class Program
    {
        public static void Init()
        {
            Console.Title = "WebServer";
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        public static void Main(string[] args)
        {
            Init();
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseUrls("http://*:10000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
