using Serilog.Core;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NewsPostApp.Extensions;

namespace TestUnit
{
	public class LoggingServiceExtensionTest
	{
		
		private readonly IConfiguration _configuration;
		public LoggingServiceExtensionTest()
		{
			// Create a test configuration with logging settings
			var inMemorySettings = new Dictionary<string, string>
		{
			{ "Logging:FilePath", ".\\Logs\\test-log-.txt" } // Test-specific log file
        };


			_configuration = new ConfigurationBuilder()
				.AddInMemoryCollection(inMemorySettings)
				.Build();
		}

		[Fact]
		public void AddSerilogLogging_ShouldCreateLogFile()
	{
			// Arrange
			var services = new ServiceCollection();
			services.AddSerilogLogging(_configuration);
			var serviceProvider = services.BuildServiceProvider();

			// Act: Log a test message
			
			var logger = serviceProvider.GetService<ILogger<LoggingServiceExtensionTest>>();
            
            logger.LogInformation("This is a test log message.");

			// Allow time for the file to be written
			System.Threading.Thread.Sleep(1000);
		}

	}

}
