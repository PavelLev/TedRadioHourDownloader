using System.Net.Http;
using System.Threading.Tasks;

namespace TedRadioHourDownloader.Utility
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public Task<string> GetStringAsync(string requestUri)
        {
            return _httpClient.GetStringAsync(requestUri);
        }

        public Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            return _httpClient.GetByteArrayAsync(requestUri);
        }
    }
}