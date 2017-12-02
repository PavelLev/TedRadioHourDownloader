using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace TedRadioHourDownloader.Utility
{
    public class HtmlParserService : IHtmlParserService
    {
        private readonly HtmlParser _htmlParser = new HtmlParser();

        public Task<IHtmlDocument> ParseAsync(string html)
        {
            return _htmlParser.ParseAsync(html);
        }
    }
}