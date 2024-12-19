using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{

	public interface ICloudinaryService
		{
			Task<ImageUploadResult> UploadImage(IFormFile file);

			Task<DeletionResult> DeleteImageOrVideo(string publicId);

			Task<VideoUploadResult> UploadVideo(IFormFile file);


		}
}
