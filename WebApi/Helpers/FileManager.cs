using SharedKernel;
using SharedKernel.Errors;

namespace WebApi.Helpers;

public class FileManager(IWebHostEnvironment environment) : IFileManager
{
    private readonly IWebHostEnvironment _environment = environment;
    public string FileName { get; private set; } = string.Empty;
    public string GetFileName() => FileName;

    public async Task<Result<string, Error>> SaveAsync(IFormFile file)
    {
        if (file is null || file.Length == 0)
        {
            return FileErrors.FileNotFound;
        }

        string uploadsPath = Path.Combine(_environment.WebRootPath, "Uploads");

        if (!Directory.Exists(uploadsPath))
        {
            Directory.CreateDirectory(uploadsPath);
        }

        string filePath = Path.Combine(uploadsPath, file.FileName);
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

        string newFileName = $"{fileNameWithoutExtension}_{timestamp}{Path.GetExtension(filePath)}";
        string newFilePath = Path.Combine(uploadsPath, newFileName);

        using (FileStream stream = new(newFilePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        FileName = newFileName;

        return newFileName;
    }

    public Result<string, Error> Transform(string fileName)
    {
        string filePath = Path.Combine(_environment.WebRootPath, "Uploads", fileName);

        if (!File.Exists(filePath))
        {
            return FileErrors.FileNotFound;
        }

        return filePath;
    }
}