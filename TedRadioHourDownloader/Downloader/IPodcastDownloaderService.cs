using System;
using System.Threading.Tasks;

namespace TedRadioHourDownloader.Downloader
{
    public interface IPodcastDownloaderService
    {
        Task DownloadAllPodcasts(string targetDirectoryPath, string fileFormat);
        Task DownloadNewPodcasts(string targetDirectoryPath, string fileFormat, DateTime stopDateTime);
    }
}