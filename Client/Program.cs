using System;
using System.Threading.Tasks;
using Contracts;
using Infrastructure;
using MassTransit.Util;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LoggerFactory.SetupMassTransitLogger();
            var bus = BusFactory.Create();

            try
            {
                TaskUtil.Await(() => bus.StartAsync());

                while (true)
                {
                    try
                    {
                        Console.Write("Enter something (quit exits): ");
                        var line = Console.ReadLine();
                        if (line == "quit")
                        {
                            break;
                        }

                        await bus.Publish<OrderPizzaMessage>(new
                        {
                            Amount = 10.0m,
                            CardNumber = "1234",
                            Type = line,
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error occurred: {ex}");
                    }
                }
            }
            finally
            {
                TaskUtil.Await(() => bus.StopAsync());
            }
        }
    }
}