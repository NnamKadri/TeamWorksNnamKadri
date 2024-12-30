using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
	public class CloudinaryWrapper : ICloudinaryWrapper
	{
		private readonly Cloudinary _cloudinary;

		public CloudinaryWrapper(Cloudinary cloudinary)
		{
			_cloudinary = cloudinary;
		}

		public async Task<ImageUploadResult> UploadImageAsync(ImageUploadParams uploadParams)
		{
			return await _cloudinary.UploadAsync(uploadParams);
		}

		public async Task<VideoUploadResult> UploadVideoAsync(VideoUploadParams uploadParams)
		{
			return await _cloudinary.UploadAsync(uploadParams);
		}

		public async Task<DeletionResult> DeleteMediaAsync(DeletionParams deletionParams)
		{
			return await _cloudinary.DestroyAsync(deletionParams);
		}
	}
}
