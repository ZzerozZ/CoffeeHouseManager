using CoffeeHouseManager.DAO;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            GetAdminMode();
        }

        public void GetAdminMode()
        {
            GetFoodList();
            GetTableList();
            GetCategoryList();
            GetAccountList();
        }
        public void GetFoodList()
        {
            string query = "select * from dbo.FOOD";
            dgvFood.ItemsSource = DataProvider.Instance.ExecuteQuery(query).DefaultView;
        }

        public void GetTableList()
        {
            string query = "select * from dbo.CTABLE";
            dgvTable.ItemsSource = DataProvider.Instance.ExecuteQuery(query).DefaultView;
        }

        public void GetCategoryList()
        {
            string query = "select * from dbo.FOODCATEGORY";
            dgvCategory.ItemsSource = DataProvider.Instance.ExecuteQuery(query).DefaultView;
        }

        public void GetAccountList()
        {
            string query = "select * from dbo.ACCOUNT";
            lsvAccount.ItemsSource = DataProvider.Instance.ExecuteQuery(query/*, new object[] { "nghia3"}*/).DefaultView;
        }
    }
}
