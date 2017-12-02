using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TedRadioHourDownloader.Downloader.Podcasts
{
    public interface IPodcastService
    {
        Task<List<Podcast>> GetNewPodcasts(DateTime stopDateTime);
    }
}