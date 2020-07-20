using System;
using MassTransit;

namespace Infrastructure
{
    public static class BusFactory
    {
        public static IBusControl Create()
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
