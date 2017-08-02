using CoffeeHouseManager.DAO;
using CoffeeHouseManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CoffeeHouseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isAd = false;

        public ToggleButton lastButton = new ToggleButton();

        public MainWindow()
        {
            InitializeComponent();
            if (isAd)
                AdminMenuItem.IsEnabled = true;

            this.DataContext = this;
            LoadTable();
        }

        private void LoadTable()
        {
            bool SetLastButton = false;
            List<TableDTO> tablelist = TableDAO.Instance.LoadTableList();
            foreach(TableDTO table in tablelist)
            {
                ToggleButton btnTable = new ToggleButton();

                btnTable.Width = btnTable.Height = 130;

                btnTable.Background = (!table.Status)? Brushes.White : Brushes.YellowGreen;
                btnTable.Tag = (table.Status == true)? "Using" : "Readly";
                btnTable.Content = "Table " + table.Id + "\n\n  " + btnTable.Tag.ToString();
                btnTable.BorderThickness = new Thickness(0.5);
                btnTable.IsChecked = false;
                btnTable.Click += BtnTable_Click;

                wpnMain.Children.Add(btnTable);
                if(SetLastButton == false)
                {
                    lastButton = btnTable;
                    SetLastButton = !SetLastButton;
                }
            }

        }

        private void BtnTable_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as ToggleButton).Tag == "Using")
            {
                btnAddFood.Content = "Add food";
                btnDiscount.IsEnabled = true;
            }
            else
            {
                btnAddFood.Content = "Open";
                btnDiscount.IsEnabled = false;
            }
               

            if ((sender as ToggleButton).IsChecked == false)
            {
                (sender as ToggleButton).IsChecked = true;
            }
            if (btnAddFood.IsEnabled == false && btnMergeTable.IsEnabled == false)
                btnAddFood.IsEnabled = btnMergeTable.IsEnabled = true;
            
            lastButton.IsChecked = false;
            lastButton = (sender as ToggleButton);
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

        private bool MainWindowOpened = false;
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(MainWindowOpened == false)
            {
                MainWindowOpened = true;
            }
            else
            {
                for (int i = 0; i < wpnMain.Children.Count; i++)
                {
                    (wpnMain.Children[i] as ToggleButton).Height = (wpnMain.Children[i] as ToggleButton).Width = (int)(15 * this.Width / 100);
                }
            }
            
            //BindingOperations.GetBindingExpression(ButtonSize, TextBox.TextProperty).UpdateSource();
        }
    }
}
