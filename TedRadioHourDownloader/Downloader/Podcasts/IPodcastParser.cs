using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TedRadioHourDownloader.Downloader.Podcasts
{
    public interface IPodcastParser
    {
        IEnumerable<Podcast> Parse(string html, DateTime stopDateTime);
    }
}