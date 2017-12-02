using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace TedRadioHourDownloader.Utility
{
    public interface IHtmlParserService
    {
        Task<IHtmlDocument> ParseAsync(string html);
    }
}