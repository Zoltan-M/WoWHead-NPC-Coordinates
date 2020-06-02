using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WoWHead_NPC_Coordinates.Models;
using WoWHead_NPC_Coordinates.ViewModels.Commands;
using WoWHead_NPC_Coordinates.Views;
using WoWHead_NPC_Coordinates.Services;

namespace WoWHead_NPC_Coordinates.ViewModels
{
    public class ViewModel : EventRaiser
    {
        private readonly Model _model;
        private WindowState _currentWindowState;
        private string _windowTitle;
        private int _npcID;
        private string _coordinates;
        private readonly string _url;
        private readonly IDownloadDataService _downloadDataService;
        private bool _isStartButtonEnabled;
       

        private Command _closeMouseClickCommandCommand;
        private Command _minimizeMouseClickCommandCommand;
        private Command _copyToClipboardCommand;
        private Command _getCoordinatesCommand;

        public ViewModel() { _coordinates = string.Empty; _npcID = 0; _isStartButtonEnabled = true; }
        public ViewModel(Model model, WindowState currentWindowState, string windowTitle, string url, DownloadDataService downloadDataService) : this() =>
            (_model, _currentWindowState, _windowTitle, _url, _downloadDataService) = (model, currentWindowState, windowTitle, url, downloadDataService);


        public WindowState CurrentWindowState
        {
            get => _currentWindowState;
            set => Update(ref _currentWindowState, value);
        }

        public string WindowTitle
        {
            get => _windowTitle;
            set => Update(ref _windowTitle, value);
        }
        
        public int NPCid
        {
            get => _npcID;
            set => Update(ref _npcID, value);
        }

        public string Coordinates
        {
            get => _coordinates;
            set => Update(ref _coordinates, value);
        }

        public ICommand CloseMouseClickCommand
        {
            get
            {
                if (_closeMouseClickCommandCommand == null)
                {
                    _closeMouseClickCommandCommand = new Command(_ => _model.CloseMouseClick());
                }

                return _closeMouseClickCommandCommand;
            }
        }

        public ICommand MinimizeMouseClickCommand
        {
            get
            {
                if (_minimizeMouseClickCommandCommand == null)
                {
                    _minimizeMouseClickCommandCommand = new Command(_ => Update(ref _currentWindowState, WindowState.Minimized, "CurrentWindowState"));
                }

                return _minimizeMouseClickCommandCommand;
            }
        }

        public ICommand CopyToClipboardCommand
        {
            get
            {
                if (_copyToClipboardCommand == null)
                {
                    _copyToClipboardCommand = new Command(_ => _model.CopyToClipboard(Coordinates, _isStartButtonEnabled));
                }

                return _copyToClipboardCommand;
            }
        }

        public ICommand GetCoordinatesCommand
        {
            get
            {
                if (_getCoordinatesCommand == null)
                {
                    _getCoordinatesCommand = new Command(async _ => await GetCoordinates(string.Concat(_url, NPCid)));
                }

                return _getCoordinatesCommand;
            }
        }

        public async Task GetCoordinates(string url)
        {
            if (_isStartButtonEnabled && NPCid != 0)
            {
                _isStartButtonEnabled = false;
                Coordinates = "Loading...";
                Coordinates = await _downloadDataService.DownloadData(url);
                _isStartButtonEnabled = true;
            }
        }

        public void CheckID(object sender, TextCompositionEventArgs e) =>  e.Handled = _model.IsNotID(e.Text);
        public void CheckSpaceKey (object sender, KeyEventArgs e) => e.Handled = e.Key == Key.Space || false;

    }
}
