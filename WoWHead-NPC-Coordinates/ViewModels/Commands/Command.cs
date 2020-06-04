﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WoWHead_NPC_Coordinates.ViewModels.Commands
{
    public class Command : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public Command(Action<object> execute) : this(execute, null) { }
        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute; 
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        //public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute(parameter); // Old code, it does the same.

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter) => _execute(parameter);

    }
}
