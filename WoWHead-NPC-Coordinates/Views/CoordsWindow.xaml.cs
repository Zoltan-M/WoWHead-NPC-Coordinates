﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WoWHead_NPC_Coordinates.Views
{
    /// <summary>
    /// Interaction logic for CoordsWindow.xaml
    /// </summary>
    public partial class CoordsWindow : Window
    {
        public CoordsWindow()
        {
            InitializeComponent();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e) => this.DragMove();

    }
}
