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
            var model = new UIModel();
            var currentWindowState = WindowState.Normal;
            var uiViewModel = new UIViewModel(model, currentWindowState);
            var mainWindow = new CoordsWindow { DataContext = uiViewModel };

            mainWindow.Show();
        }
    }
}
