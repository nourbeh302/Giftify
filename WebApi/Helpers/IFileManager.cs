using SharedKernel;
using SharedKernel.Errors;

namespace WebApi.Helpers;

public interface IFileManager
{
    Task<Result<string, Error>> SaveAsync(IFormFile file);

    /// <summary>
    /// Tansforms the file name into the absolute file name
    /// </summary>
    Result<string, Error> Transform(string fileName);

    string GetFileName();
}
