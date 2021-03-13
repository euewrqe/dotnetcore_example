using Microsoft.Extensions.Hosting;
using System;

namespace DotnetTestFromConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run()
        }

        // IHostBuilder Microsoft.Extensions.Hosting.Abstractions
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
