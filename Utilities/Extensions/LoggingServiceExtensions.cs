using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;


namespace NewsPostApp.Extensions
{
	public static class LoggingServiceExtensions
	{
		public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
		{
			// Configure file logging path from settings or use default
			var logPath = configuration["Logging:FilePath"] ?? ".\\Logs\\log-.txt";

			Log.Logger = new LoggerConfiguration()
				.WriteTo.File(
					path: logPath,
					outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
					rollingInterval: RollingInterval.Day,
					restrictedToMinimumLevel: LogEventLevel.Information
				)
				.CreateLogger();

			// Add Serilog to the service container
			services.AddLogging(loggingBuilder =>
			{
				loggingBuilder.ClearProviders(); // Remove default logging providers
				loggingBuilder.AddSerilog();    // Use Serilog as the logging provider
			});

			return services;
		}
	}


}
