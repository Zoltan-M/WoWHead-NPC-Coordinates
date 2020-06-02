using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WoWHead_NPC_Coordinates.Services
{
    public interface IDownloadDataService
    {
        Task<string> DownloadData(string url);
    }
}
