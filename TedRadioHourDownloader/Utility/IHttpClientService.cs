using System.Threading.Tasks;

namespace TedRadioHourDownloader.Utility
{
    public interface IHttpClientService
    {
        Task<string> GetStringAsync(string requestUri);
        Task<byte[]> GetByteArrayAsync(string requestUri);
    }
}