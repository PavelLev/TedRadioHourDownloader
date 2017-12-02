using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TedRadioHourDownloader.Downloader.Podcasts;
using TedRadioHourDownloader.Utility;

namespace TedRadioHourDownloader.Downloader
{
    public class PodcastDownloaderService : IPodcastDownloaderService
    {
        private readonly IPodcastService _podcastService;
        private readonly IPathService _pathService;
        private readonly IFileService _fileService;
        private readonly IHttpClientService _httpClientService;
        private readonly ILoggerService _loggerService;

        public PodcastDownloaderService(IPodcastService podcastService, IPathService pathService, IFileService fileService, IHttpClientService httpClientService, ILoggerService loggerService)
        {
            _podcastService = podcastService;
            _pathService = pathService;
            _fileService = fileService;
            _httpClientService = httpClientService;
            _loggerService = loggerService;
        }

        public Task DownloadAllPodcasts(string targetDirectoryPath, string fileFormat)
        {
            return DownloadNewPodcasts(targetDirectoryPath, fileFormat, DateTime.MinValue);
        }

        public async Task DownloadNewPodcasts(string targetDirectoryPath, string fileFormat, DateTime stopDateTime)
        {
            _loggerService.Info("Started loading podcasts info");

            var podcasts = await _podcastService.GetNewPodcasts(stopDateTime);

            _loggerService.Info("Finished loading podcasts info");

            foreach (var podcast in podcasts)
            {
                var fileName = string.Format(fileFormat, podcast.Name, podcast.Date);

                var filePath = _pathService.Combine(targetDirectoryPath, fileName);


                if (!_fileService.Exists(filePath))
                {
                    var bytes = await _httpClientService.GetByteArrayAsync(podcast.DownloadLink);

                    await _fileService.WriteAllBytes(filePath, bytes);

                    _loggerService.Info($"Downloaded {fileName}");
                }
            }
        }
    }
}