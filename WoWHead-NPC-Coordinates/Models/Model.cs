using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace WoWHead_NPC_Coordinates.Models
{
    public class Model
    {
        public Model() { }
        public void CloseMouseClick()
        {
            Application.Current.Shutdown();
        }

        public void CopyToClipboard(string text, bool isStartButtonEnabled)
        {
            try
            {
                if(!text.Equals(string.Empty) && isStartButtonEnabled)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(text);
                }
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
