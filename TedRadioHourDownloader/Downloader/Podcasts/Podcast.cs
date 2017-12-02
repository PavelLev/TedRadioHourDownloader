namespace TedRadioHourDownloader.Downloader.Podcasts
{
    public class Podcast
    {
        public Podcast(string name, string date, string downloadLink)
        {
            Name = name;
            Date = date;
            DownloadLink = downloadLink;
        }

        public string Name { get; }
        public string Date { get; }
        public string DownloadLink { get; }
    }
}