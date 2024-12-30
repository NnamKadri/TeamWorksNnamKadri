using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Repository.IRepository;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsPostApp.Extensions.Utilities.Extensions;


namespace NewsPostApp.Extensions
{
	public static class DIServiceExtension
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			// Add services
			services.AddCloudinaryService(configuration);
			services.AddSingleton<ICloudinaryWrapper, CloudinaryWrapper>();
			services.AddScoped<ICloudinaryService, CloudinaryService>();
			services.AddSerilogLogging(configuration);
			services.AddSwaggerDocumentation();


			return services;
		}
	}


}
