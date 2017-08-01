﻿using CoffeeHouseManager.DAO;
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

namespace CoffeeHouseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(Account.Instance.Login(txbUserName.Text, pwbPassword.Password))
            {
                MainWindow ManagerWindow = new MainWindow();
                this.Hide();
                ManagerWindow.Show();
            }
            else
            {
                txblLoginStatus.Text = "Incorrect Username or Pasword!";
            }
        }

        private void btnExitClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "Close?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
