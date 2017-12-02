using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TedRadioHourDownloader.Utility;

namespace TedRadioHourDownloader.Downloader.Podcasts
{
    public class PodcastService : IPodcastService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IPodcastParser _podcastParser;

        private readonly string _podcastUrl = "https://www.npr.org/podcasts/510298/ted-radio-hour/partials?start={0}";

        public PodcastService(IHttpClientService httpClientService, IPodcastParser podcastParser)
        {
            _httpClientService = httpClientService;
            _podcastParser = podcastParser;
        }

        public async Task<List<Podcast>> GetNewPodcasts(DateTime stopDateTime)
        {
            var allPodcasts = new List<Podcast>();

            var index = 1;

            while (true)
            {
                var currentUrl = string.Format(_podcastUrl, index);

                var html = await _httpClientService.GetStringAsync(currentUrl);


                var podcasts = _podcastParser.Parse(html, stopDateTime).ToList();

                if (podcasts.Count == 0)
                {
                    break;
                }

                index += podcasts.Count;

                allPodcasts.AddRange(podcasts);
            }

            return allPodcasts;
        }
    }
}