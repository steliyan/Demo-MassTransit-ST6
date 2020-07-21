using System;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using MassTransit.Courier;

namespace PizzaService.Consumers
{
    public class OrderPizzaConsumer : IConsumer<OrderPizzaMessage>
    {
        public async Task Consume(ConsumeContext<OrderPizzaMessage> ctx)
        {
            var builder = new RoutingSlipBuilder(NewId.NextGuid());

            builder.SetVariables(ctx.Message);

            builder.AddActivity("ChargePayment", new Uri("queue:ChargePayment_execute"));
            builder.AddActivity("MakePizza", new Uri("queue:MakePizza_execute"));

            var routingSlip = builder.Build();

            await ctx.Execute(routingSlip);
        }
    }
}