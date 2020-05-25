using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WoWHead_NPC_Coordinates.Models;
using WoWHead_NPC_Coordinates.ViewModels.Commands;
using WoWHead_NPC_Coordinates.Views;

namespace WoWHead_NPC_Coordinates.ViewModels
{
    public class UIViewModel : UIRaiseEvent
    {
        private readonly UIModel _model;
        private WindowState _currentWindowState;
        private string _windowTitle;
        private string _npcID;
        private string _coordinates;

        private UICommand _closeMouseClickCommandCommand;
        private UICommand _minimizeMouseClickCommandCommand;
        private UICommand _copyToClipboardCommand;

        public UIViewModel() { }
        public UIViewModel(UIModel model, WindowState currentWindowState, string windowTitle) => (_model, _currentWindowState, _windowTitle) = (model, currentWindowState, windowTitle);


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
        
        public string NPCid
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
                    _closeMouseClickCommandCommand = new UICommand(_ => _model.CloseMouseClick());
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
                    _minimizeMouseClickCommandCommand = new UICommand(_ => Update(ref _currentWindowState, WindowState.Minimized, "CurrentWindowState"));
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
                    _copyToClipboardCommand = new UICommand(_ => _model.CopyToClipboard(Coordinates));
                }

                return _copyToClipboardCommand;
            }
        }

        public void CheckID(object sender, TextCompositionEventArgs e) =>  e.Handled = _model.IsNotID(e.Text);

    }
}
