using ECommerce_Media_Service.Services.Interfaces;
using ECommerce_Media_Service.Utilities.Results;

namespace ECommerce_Media_Service.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public ServiceResult<bool> DeleteFile(string? filePath)
        {

            filePath = Path.Combine(_env.WebRootPath, filePath);

            if (!File.Exists(filePath))
            {
                return ServiceResult<bool>.Failure("File doesnt exixts",404);
            }

            File.Delete(filePath);


            return ServiceResult<bool>.Success(true);

        }



        public async Task<ServiceResult<string>> UploadFileAsync(IFormFile file,string folderName)
        {
            if (file is null || file.Length == 0)
            {
                return ServiceResult<string>.Failure("File cant be null",400);
            }


            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                return ServiceResult<string>.Failure($"only {string.Join(", ", allowedExtensions)} allowed", 400);
            }

            if(file.Length > 5 * 1024 * 1024)
            {
                return ServiceResult<string>.Failure($"only 5mb allowed", 400);

            }

            string folderPath = Path.Combine(_env.WebRootPath,folderName);
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string fullFilePath = Path.Combine(folderPath,fileName);

            using var stream = new FileStream(fullFilePath,FileMode.Create);

            await file.CopyToAsync(stream);

            string relativePath = $"/{folderName}/{fileName}";
            return ServiceResult<string>.Success(relativePath);
        }
    }
}
