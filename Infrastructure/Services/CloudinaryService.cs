using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{

	public class CloudinaryService : ICloudinaryService
	{
		private readonly Cloudinary _cloudinary;
		//private readonly ICloudinaryWrapper _cloudinaryWrapper;

		public CloudinaryService(Cloudinary cloudinary)
		{
			_cloudinary = cloudinary;
			//_cloudinaryWrapper = cloudinaryWrapper;	
		}

		
		public async Task<ImageUploadResult> UploadImage(IFormFile file)
		{
			
			var allowedImageExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".avif" };

			var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

			if (!allowedImageExtensions.Contains(fileExtension))
			{
				throw new InvalidOperationException("Invalid file type. Only image files are allowed.");
			}

			var uploadResult = new ImageUploadResult();

			if (file.Length > 0)
			{
				using var stream = file.OpenReadStream();
				var uploadParams = new ImageUploadParams
				{
					File = new FileDescription(file.FileName, stream),
					Transformation = new Transformation().Crop("fill").Gravity("face").Width(500).Height(500)
				};

				uploadResult = await _cloudinary.UploadAsync(uploadParams);
				//uploadResult = await _cloudinaryWrapper.UploadImageAsync(uploadParams);
			}

			return uploadResult;
		}


		public async Task<DeletionResult> DeleteImageOrVideo(string publicId)
		{
			var deletionParams = new DeletionParams(publicId);
			var result = await _cloudinary.DestroyAsync(deletionParams);
			return result;
		}

		public async Task<VideoUploadResult> UploadVideo(IFormFile file)
		{

			var uploadResult = new VideoUploadResult();

			var allowedExtensions = new List<string> { ".mp4", ".mov", ".avi", ".mkv" };
			var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

			if (!allowedExtensions.Contains(fileExtension))
			{
				throw new InvalidOperationException("Invalid file type. Only video files are allowed.");
			}

			await using var stream = file.OpenReadStream();

			var uploadParams = new VideoUploadParams
			{
				File = new FileDescription(file.FileName, stream)
			};

			uploadResult = await _cloudinary.UploadAsync(uploadParams).ConfigureAwait(false);
			return uploadResult;

		}
	}
}
