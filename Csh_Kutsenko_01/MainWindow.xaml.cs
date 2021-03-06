﻿using Csh_Kutsenko_01.Tools.Managers;
using Csh_Kutsenko_01.ViewModels;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Csh_Kutsenko_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            NavigateManager.Instance.Innitialize(new BaseNavigationModel(this));
            NavigateManager.Instance.Navigate(ViewType.Main);
        }

        public ContentControl ContentControl
        {
            get
            {
                return _contentControl;
            }
        }
    }
}
