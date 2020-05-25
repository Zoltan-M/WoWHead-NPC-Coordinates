using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WoWHead_NPC_Coordinates.ViewModels
{
    public abstract class UIRaiseEvent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Update<T>(ref T variable, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(value, variable))
            {
                variable = value;
                RaisePropertyChangedEvent(propertyName);
            }
        }
    }
}
