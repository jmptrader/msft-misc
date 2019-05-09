﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MSimpson.ConsoleTemplate
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
              .ConfigureAppConfiguration((hostingContext, config) =>
              {
                  config.AddJsonFile("appsettings.json", optional: true);
                  config.AddEnvironmentVariables();

                  if (args != null)
                  {
                      config.AddCommandLine(args);
                  }
              })
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddOptions();
                  services.Configure<AppConfig>(hostContext.Configuration.GetSection("AppConfig"));

                  services.AddSingleton<IHostedService, GenericService>();
              })
              .ConfigureLogging((hostingContext, logging) =>
              {
                  logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                  logging.AddConsole();
              });

            await builder.RunConsoleAsync();
        }
    }
}
