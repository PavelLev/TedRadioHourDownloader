using System.Threading.Tasks;

namespace TedRadioHourDownloader.Utility
{
    public interface IFileService
    {
        bool Exists(string filePath);
        Task WriteAllBytes(string path, byte[] bytes);
    }
}