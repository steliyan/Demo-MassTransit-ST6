using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Courier;
using MassTransit.Definition;
using Microsoft.Extensions.Logging;
using GreenPipes;

namespace PizzaService.Activities
{
    public interface MakePizzaArgs
    {
        string Type { get; }
    }

    public class MakePizzaActivityDefinition : ExecuteActivityDefinition<MakePizzaActivity, MakePizzaArgs>
    {
        protected override void ConfigureExecuteActivity(
            IReceiveEndpointConfigurator endpointConfigurator,
            IExecuteActivityConfigurator<MakePizzaActivity, MakePizzaArgs> executeActivityConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Immediate(3));
        }
    }

    public class MakePizzaActivity : IExecuteActivity<MakePizzaArgs>
    {
        private readonly ILogger<MakePizzaActivity> logger;

        public MakePizzaActivity(ILogger<MakePizzaActivity> logger)
        {
            this.logger = logger;
        }

        public async Task<ExecutionResult> Execute(ExecuteContext<MakePizzaArgs> context)
        {
            this.logger.LogInformation($"Start making {context.Arguments.Type} pizza...");

            if (context.Arguments.Type.Contains("Carbonara"))
            {
                await Task.Delay(2000);
                throw new Exception("Don't have any cream!");
            }

            this.logger.LogInformation($"{context.Arguments.Type} pizza is DONE!");

            return context.Completed();
        }
    }
}