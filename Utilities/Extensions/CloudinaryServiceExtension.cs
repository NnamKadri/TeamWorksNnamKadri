using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Configurations;


namespace NewsPostApp.Extensions
{

	namespace Utilities.Extensions
	{
		public static class CloudinaryServiceExtension
		{
			public static IServiceCollection AddCloudinaryService(this IServiceCollection services, IConfiguration configuration)
			{
				
				var cloudinarySettings = new CloudinarySettings
				{
					CloudName = Environment.GetEnvironmentVariable("Cloudinary_CloudName")
						?? configuration["CloudinarySettings:CloudName"],
					ApiKey = Environment.GetEnvironmentVariable("Cloudinary_ApiKey")
					 ?? configuration["CloudinarySettings:ApiKey"],
					ApiSecret = Environment.GetEnvironmentVariable("Cloudinary_ApiSecret")
						?? configuration["CloudinarySettings:ApiSecret"]
				};
				var cloudinaryAccount = new Account(
					cloudinarySettings.CloudName,
					cloudinarySettings.ApiKey,
					cloudinarySettings.ApiSecret
				);

				var cloudinary = new Cloudinary(cloudinaryAccount);
				services.AddSingleton(cloudinary);

				return services;
			}
		}
	}


}
