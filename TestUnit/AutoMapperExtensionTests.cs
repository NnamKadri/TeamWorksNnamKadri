using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using NewsPostApp.Extensions;

namespace TestUnit
{
	public class AutoMapperExtensionTests
	{
		[Fact]
		public void AddAutoMapperExtension_ShouldRegisterAutoMapperCorrectly()
		{
			// Arrange
			var services = new ServiceCollection();

			// Act
			services.AddAutoMapperServices();
			var serviceProvider = services.BuildServiceProvider();

			// Assert
			var mapper = serviceProvider.GetService<IMapper>();
			Assert.NotNull(mapper); // Check if AutoMapper is registered

			// Test Mapping
			var configuration = serviceProvider.GetService<AutoMapper.IConfigurationProvider>();
			Assert.NotNull(configuration);

			// Ensure configuration is valid
			configuration.AssertConfigurationIsValid();
		}

		[Fact]
		public void AutoMapper_ShouldMapSourceToDestinationCorrectly()
		{
			// Arrange
			var services = new ServiceCollection();
			//services.AddAutoMapperServices();
			services.AddAutoMapper(cfg => cfg.AddProfile<TestProfile>());

			var serviceProvider = services.BuildServiceProvider();

			var mapper = serviceProvider.GetService<IMapper>();

			// Mock source and destination
			var source = new Source { Id = 1, Name = "Test" };
			var destination = mapper.Map<Destination>(source);

			// Assert
			Assert.NotNull(destination);
			Assert.Equal(source.Id, destination.Id);
			Assert.Equal(source.Name, destination.Name);
		}

		// Mock source and destination classes
		public class Source
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}

		public class Destination
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}

		// Mock AutoMapper profile
		public class TestProfile : Profile
		{
			public TestProfile()
			{
				CreateMap<Source, Destination>();
			}
		}
	}

}

