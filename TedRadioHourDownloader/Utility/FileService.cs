using System.IO;
using System.Threading.Tasks;

namespace TedRadioHourDownloader.Utility
{
    public class FileService : IFileService
    {
        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public Task WriteAllBytes(string path, byte[] bytes)
        {
            return Task.Run(() =>
            {
                File.WriteAllBytes(path, bytes);
            });
        }
    }
}