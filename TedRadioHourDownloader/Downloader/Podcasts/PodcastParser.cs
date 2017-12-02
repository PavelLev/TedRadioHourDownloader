using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using TedRadioHourDownloader.Utility;

namespace TedRadioHourDownloader.Downloader.Podcasts
{
    public class PodcastParser : IPodcastParser
    {
        private readonly IHtmlParserService _htmlParserService;

        public PodcastParser(IHtmlParserService htmlParserService)
        {
            _htmlParserService = htmlParserService;
        }

        public IEnumerable<Podcast> Parse(string html, DateTime stopDateTime)
        {
            var document = _htmlParserService.ParseAsync(html).Result;

            foreach (var node in document.QuerySelectorAll("article.podcast-episode"))
            {
                var date = node.QuerySelector("time").Attributes["datetime"].Value;

                if (DateTime.Parse(date) <= stopDateTime)
                {
                    break;
                }

                var name = node.QuerySelector(".title").InnerHtml;


                var downloadLinkNode = node.QuerySelector("a");

                if (downloadLinkNode == null)
                {
                    continue;
                }

                var downloadLink = downloadLinkNode.Attributes["href"].Value;

                yield return new Podcast(name, date, downloadLink);
            }
        }
    }
}