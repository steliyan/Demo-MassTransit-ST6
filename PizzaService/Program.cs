﻿using System.Reflection;
using System.Threading.Tasks;
using Infrastructure;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace PizzaService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LoggerFactory.SetupMassTransitLogger();

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddBus(BusFactory.Create);

                        x.AddConsumers(Assembly.GetExecutingAssembly());
                        x.AddActivities(Assembly.GetExecutingAssembly());
                    });

                    services.AddSingleton<IHostedService, PizzaService>();
                })
                .ConfigureLogging((hostingContext, logging) => { logging.AddSerilog(dispose: true); });

            await builder.RunConsoleAsync();
        }
    }
}