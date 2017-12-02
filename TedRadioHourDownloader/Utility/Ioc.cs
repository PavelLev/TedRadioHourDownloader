using System.Net.Http;
using TedRadioHourDownloader.Downloader;
using TedRadioHourDownloader.Downloader.Podcasts;
using TedRadioHourDownloader.DryIoc;

namespace TedRadioHourDownloader.Utility
{
    public class Ioc
    {
        static Ioc()
        {
            RegisterAllDependencies();
        }

        private static void RegisterAllDependencies()
        {
            Container.Register<IPodcastParser, PodcastParser>(Reuse.Singleton);
            Container.Register<IPodcastService, PodcastService>(Reuse.Singleton);

            Container.Register<IPodcastDownloaderService, PodcastDownloaderService>(Reuse.Singleton);

            
            Container.Register<IFileService, FileService>(Reuse.Singleton);
            Container.Register<IHtmlParserService, HtmlParserService>(Reuse.Singleton);
            Container.Register<IHttpClientService, HttpClientService>(Reuse.Singleton);
            Container.Register<ILoggerService, ConsoleLoggerService>(Reuse.Singleton);
            Container.Register<IPathService, PathService>(Reuse.Singleton);
        }

        public static IContainer Container { get; } = new Container();
    }
}