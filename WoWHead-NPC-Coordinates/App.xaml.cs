using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WoWHead_NPC_Coordinates.Models;
using WoWHead_NPC_Coordinates.ViewModels;
using WoWHead_NPC_Coordinates.Views;
using WoWHead_NPC_Coordinates.Services;

namespace WoWHead_NPC_Coordinates
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var model = new Model();
            var currentWindowState = WindowState.Normal;
            var windowTitle = "WoWHead NPC Coords";
            var url = "http://www.wowhead.com/npc=";
            var downloadDataService = new DownloadDataService();
            var uiViewModel = new ViewModel(model, currentWindowState, windowTitle, url, downloadDataService);
            var mainWindow = new CoordsWindow { DataContext = uiViewModel };
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    
            mainWindow.Show();
        }
    }
}
