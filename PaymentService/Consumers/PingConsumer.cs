using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace PaymentService.Consumers
{
    public class PingConsumer : IConsumer<PingMessage>
    {
        private readonly ILogger<PingConsumer> logger;

        public PingConsumer(ILogger<PingConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<PingMessage> context)
        {
            this.logger.LogInformation($"Ping-pong: {context.Message.Data}");
            return context.ConsumeCompleted;
        }
    }
}