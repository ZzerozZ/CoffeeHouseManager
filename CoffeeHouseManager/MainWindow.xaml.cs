using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public static bool isAd = false;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            if (isAd)
                AdminMenuItem.IsEnabled = true;
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
            if (MessageBox.Show("Do you want to login with other account?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                LoginWindow login = new LoginWindow();
                login.Show();
            }
            else
                Application.Current.Shutdown();
        }

        private void AppCreator_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This application was developed by Trọng Nghĩa(zzerodev)\n\nContact me at:\nFacebook: http:://facebook.com/zzerodev\nEmail: nghiaduong.170697@outlook.com.vn");
        }

        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            if(isAd)
            {
                AdminWindow admin = new AdminWindow();
                admin.ShowDialog();
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            isAd = false;
        }
    }
}
