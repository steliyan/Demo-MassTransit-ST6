using System;
using Infrastructure;
using MassTransit.Util;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
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