using System;
using System.Threading.Tasks;
using TedRadioHourDownloader.Downloader;
using TedRadioHourDownloader.DryIoc;
using TedRadioHourDownloader.Utility;

namespace TedRadioHourDownloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage - [executable name] [directory path] [file format]");
                return;
            }

            var directoryPath = args[0];

            var fileFormat = args[1];

            var podcastDownloadService = Ioc.Container.Resolve<IPodcastDownloaderService>();

            await podcastDownloadService.DownloadAllPodcasts(directoryPath, fileFormat);
        }
    }
}
