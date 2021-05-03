using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Entities;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;

namespace Braveior.BuddyRewards.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogging();
            DB.InitAsync("buddyrewards", "localhost", 27017).GetAwaiter().GetResult();
            CreateHostBuilder(args).Build().Run();
        }
        private static void ConfigureLogging()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog(Log.Logger);
    }
}
