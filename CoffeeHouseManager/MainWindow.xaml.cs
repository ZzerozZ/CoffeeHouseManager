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

namespace CoffeeHouseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txbCountFoodAdding_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.Key))
                e.Handled = false;
        }
        
        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePass = new ChangePasswordWindow();
            changePass.ShowDialog();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
