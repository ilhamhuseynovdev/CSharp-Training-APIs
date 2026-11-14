using ECommerce_Media_Service.Utilities.Results;

namespace ECommerce_Media_Service.Services.Interfaces
{
    public interface IFileService
    {
        public Task<ServiceResult<string>> UploadFileAsync(IFormFile file,string folderName);
        public ServiceResult<bool> DeleteFile(string? filePath);
    }
}
