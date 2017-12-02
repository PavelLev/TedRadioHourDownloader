using System.IO;

namespace TedRadioHourDownloader.Utility
{
    public class PathService : IPathService
    {
        public string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }
    }
}