using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace PizzaService
{
    public class PizzaService : IHostedService
    {
        private readonly IBusControl bus;

        public PizzaService(IBusControl bus)
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