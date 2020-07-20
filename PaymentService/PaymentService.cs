using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace PaymentService
{
    public class PaymentService : IHostedService
    {
        private readonly IBusControl bus;

        public PaymentService(IBusControl bus)
        {
            this.bus = bus;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return this.bus.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return this.bus.StopAsync(cancellationToken);
        }
    }
}