using System;

namespace TedRadioHourDownloader.Utility
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void Info(string value)
        {
            Console.WriteLine($"{value}{Environment.NewLine}");
        }
    }
}