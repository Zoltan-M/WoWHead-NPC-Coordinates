using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WoWHead_NPC_Coordinates.Models
{
    public class UIModel
    {
        public UIModel() { }
        public void CloseMouseClick()
        {
            Application.Current.Shutdown();
        }

        public void MoveWindow()
        {

        }

        public void CopyToClipboard(string text)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(text);
            }
            catch (Exception) { }
        }


        public bool IsNotID(string text)
        {
            Regex regex = new Regex(@"^\d$");
            return !regex.IsMatch(text);
        }


    }
}
