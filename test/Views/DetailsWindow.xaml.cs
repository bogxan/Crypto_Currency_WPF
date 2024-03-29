﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using test.ViewModels;

namespace test.Views
{
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(string choosedId)
        {
            InitializeComponent();
            DataContext = new DetailsViewModel(choosedId);
        }
    }
}
