using System.Threading.Tasks;
using MassTransit.Courier;
using Microsoft.Extensions.Logging;

namespace PaymentService.Activities
{
    public interface ChargePaymentArgs
    {
        string CardNumber { get; }
        
        decimal Amount { get; }
    }

    public interface ChargePaymentLog
    {
        string CardNumber { get; }
        decimal Amount { get; }
    }

    public class ChargePaymentActivity : IActivity<ChargePaymentArgs, ChargePaymentLog>
    {
        private readonly ILogger<ChargePaymentActivity> logger;

        public ChargePaymentActivity(ILogger<ChargePaymentActivity> logger)
        {
            this.logger = logger;
        }

        public async Task<ExecutionResult> Execute(ExecuteContext<ChargePaymentArgs> context)
        {
            this.logger.LogInformation($"Charging {context.Arguments.Amount} from {context.Arguments.CardNumber}.");

            return context.Completed(new
            {
                context.Arguments.CardNumber,
                context.Arguments.Amount,
            });
        }

        public async Task<CompensationResult> Compensate(CompensateContext<ChargePaymentLog> context)
        {
            this.logger.LogInformation($"Reverse charging {context.Log.Amount} from {context.Log.CardNumber}.");
            return context.Compensated();
        }
    }
}