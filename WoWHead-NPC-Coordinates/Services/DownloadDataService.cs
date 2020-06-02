using System;
using System.Collections.Generic;
using System.Net; // WebClient
using System.Text;
using System.Threading.Tasks;

namespace WoWHead_NPC_Coordinates.Services
{
    public class DownloadDataService : IDownloadDataService
    {
        public async Task<string> DownloadData(string url)
        {
            string websiteData = string.Empty;
            try
            {
                using var webClient = new WebClient { Encoding = Encoding.UTF8 };
                Uri uri = new Uri(url);
                websiteData = await webClient.DownloadStringTaskAsync(uri);
            }
            catch (WebException) { websiteData = "There is an error with the connection."; }

            return websiteData;
        }
    }
}
