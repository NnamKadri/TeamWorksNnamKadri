using Microsoft.Extensions.DependencyInjection;
using Utilities.Configurations;

namespace NewsPostApp.Extensions
{
    public static class AutoMapperServiceExtension
	{
		public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MapperConfig));
			return services;
		}

	}

}
