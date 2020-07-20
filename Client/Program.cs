using System;
using MassTransit;
using MassTransit.Util;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = CreateBus();

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

        private static IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
                cfg.Host(new Uri("rabbitmq://localhost/test"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                }));
        }
    }
}