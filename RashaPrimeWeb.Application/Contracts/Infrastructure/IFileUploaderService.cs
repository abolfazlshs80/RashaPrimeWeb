using Microsoft.AspNetCore.Http;

namespace RashaPrimeWeb.Application.Contracts.Infrastructure
{
    public interface IFileUploaderService
    {

        Task<string> UploadFile(Stream fileStream, string directoryName, string fileName);
        Task<string> UpdloadFile(IFormFile file, string directoryName,  string Name);
        Task DeleteFile(string directoryName, string Name);
        string DownloadFile(string filename, string type);

    }
}
