using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CloudinaryDotNet;
using NewsPostApp.Extensions.Utilities.Extensions;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using System.Reflection;
using Utilities.Configurations;
using System.Runtime.InteropServices;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Moq;

namespace TestUnit
{

	public class CloudinaryServiceTests
	{
		private readonly IConfiguration _configuration;

		public CloudinaryServiceTests()
		{
			// Use in-memory settings to mock configuration values
			var inMemorySettings = new Dictionary<string, string>
		{
			{ "CloudinarySettings:CloudName", "testCloud" },
			{ "CloudinarySettings:ApiKey", "testApiKey" },
			{ "CloudinarySettings:ApiSecret", "testApiSecret" }
		};

			_configuration = new ConfigurationBuilder()
				.AddInMemoryCollection(inMemorySettings)
				.Build();
		}

		[Fact]
		public void AddCloudinaryService_ShouldRegisterCloudinaryWithCorrectSettings()
		{
			// Arrange
			var services = new ServiceCollection();
			services.AddCloudinaryService(_configuration);
			services.AddScoped<ICloudinaryService, CloudinaryService>();

			var serviceProvider = services.BuildServiceProvider();

			// Act
			var cloudinaryService = serviceProvider.GetService<ICloudinaryService>();

			// Assert
			Assert.NotNull(cloudinaryService);

			// Validate Cloudinary instance via CloudinaryService
			var cloudinaryField = typeof(CloudinaryService)
				.GetField("_cloudinary", BindingFlags.NonPublic | BindingFlags.Instance);
			var cloudinary = (Cloudinary)cloudinaryField?.GetValue(cloudinaryService);

			Assert.NotNull(cloudinary);

			//Assert.NotNull(account);
			Assert.Equal("dtlguq304", cloudinary.Api.Account.Cloud);
			Assert.Equal("668451417956457", cloudinary.Api.Account.ApiKey);
			Assert.Equal("KtF8krKjSP5ptuwFQbvlibg8DJ4", cloudinary.Api.Account.ApiSecret);
		}


		//[Fact]
		//public async Task UploadImage_ShouldReturnExpectedResult()
		//{
		//	// Arrange
		//	var mockWrapper = new Mock<ICloudinaryWrapper>();
		//	var expectedResult = new ImageUploadResult { SecureUrl = new Uri("https://example.com/test.jpg") };

		//	mockWrapper
		//		.Setup(w => w.UploadImageAsync(It.IsAny<ImageUploadParams>()))
		//		.ReturnsAsync(expectedResult);

		//	var cloudinaryService = new CloudinaryService(mockWrapper.Object);

		//	var mockFile = new Mock<IFormFile>();
		//	mockFile.Setup(f => f.OpenReadStream()).Returns(new MemoryStream());
		//	mockFile.Setup(f => f.FileName).Returns("test.jpg");

		//	// Act
		//	var result = await cloudinaryService.UploadImage(mockFile.Object);

		//	// Assert
		//	Assert.NotNull(result);
		//	Assert.Equal(expectedResult.SecureUrl, result.SecureUrl);
		//}

		//[Fact]
		//public async Task DeleteMedia_ShouldReturnExpectedResult()
		//{
		//	// Arrange
		//	var mockWrapper = new Mock<ICloudinaryWrapper>();
		//	var expectedResult = new DeletionResult { Result = "ok" };

		//	mockWrapper
		//		.Setup(w => w.DeleteMediaAsync(It.IsAny<DeletionParams>()))
		//		.ReturnsAsync(expectedResult);

		//	var cloudinaryService = new CloudinaryService(mockWrapper.Object);

		//	// Act
		//	var result = await cloudinaryService.DeleteImageOrVideo("testPublicId");

		//	// Assert
		//	Assert.NotNull(result);
		//	Assert.Equal("ok", result.Result);

		//	// Verify
		//	mockWrapper.Verify(w => w.DeleteMediaAsync(It.Is<DeletionParams>(p => p.PublicId == "testPublicId")), Times.Once);
		//}

		//[Fact]
		//public async Task UploadVideo_ShouldReturnExpectedResult()
		//{
		//	// Arrange
		//	var mockWrapper = new Mock<ICloudinaryWrapper>();
		//	var expectedResult = new VideoUploadResult { SecureUrl = new Uri("https://example.com/test.mp4") };

		//	mockWrapper
		//		.Setup(w => w.UploadVideoAsync(It.IsAny<VideoUploadParams>()))
		//		.ReturnsAsync(expectedResult);

		//	var cloudinaryService = new CloudinaryService(mockWrapper.Object);

		//	var mockFile = new Mock<IFormFile>();
		//	mockFile.Setup(f => f.OpenReadStream()).Returns(new MemoryStream());
		//	mockFile.Setup(f => f.FileName).Returns("test.mp4");

		//	// Act
		//	var result = await cloudinaryService.UploadVideo(mockFile.Object);

		//	// Assert
		//	Assert.NotNull(result);
		//	Assert.Equal(expectedResult.SecureUrl, result.SecureUrl);

		//	// Verify
		//	mockWrapper.Verify(w => w.UploadVideoAsync(It.IsAny<VideoUploadParams>()), Times.Once);
		//}


	}

}

