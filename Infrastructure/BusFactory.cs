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
        
        public static IBusControl Create(IBusRegistrationContext ctx)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost/test"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
                cfg.ConfigureEndpoints(ctx);
            });
        }
    }
}
