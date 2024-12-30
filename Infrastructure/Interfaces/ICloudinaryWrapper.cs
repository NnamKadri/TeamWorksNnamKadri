using CloudinaryDotNet.Actions;

namespace Infrastructure.Interfaces
{
	public interface ICloudinaryWrapper
	{
		Task<ImageUploadResult> UploadImageAsync(ImageUploadParams uploadParams);
		Task<VideoUploadResult> UploadVideoAsync(VideoUploadParams uploadParams);
		 Task<DeletionResult> DeleteMediaAsync(DeletionParams deletionParams);
		
	}
}
