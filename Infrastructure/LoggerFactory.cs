using MassTransit.Context;
using Serilog;
using Serilog.Extensions.Logging;

namespace Infrastructure
{
    public static class LoggerFactory
    {
        public static void SetupMassTransitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            LogContext.ConfigureCurrentLogContext(new SerilogLoggerFactory());
        }
    }
}