using CoffeeHouseManager.DAO;
using CoffeeHouseManager.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Window
    {
        public AddFood()
        {
            InitializeComponent();

            List<string> category = new List<string>();
            DataTable table = DataProvider.Instance.ExecuteQuery("Select FoodCategoryID, Name from dbo.FOODCATEGORY");
            foreach(DataRow row in table.Rows)
            {
                category.Add(row[0].ToString() + " - " + row[1].ToString());
            }

            cmbCategory.ItemsSource = category;
            cmbCategory.SelectedIndex = 0;
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> food = new List<string>();
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT FoodID, Name, Price FROM dbo.FOOD WHERE IDFoodCategory = '" + cmbCategory.SelectedItem.ToString().Remove(3) + "'");
            foreach (DataRow row in table.Rows)
            {
                food.Add(row[0].ToString() + " - " + row[1].ToString());
            }

            cmbFood.ItemsSource = food;
            cmbFood.SelectedIndex = 0;
        }

        private void cmbFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //txbSearch.Text = cmbFood.SelectedItem.ToString().Remove(0, cmbFood.SelectedItem.ToString().IndexOf('-') + 2);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string tableID = MainWindow.lastButton.Content.ToString().Replace("Table ", "").Remove(5);

            //if (DataProvider.Instance.ExecuteNonQuery()
            //{
                BillDAO.Instance.InsertBill(tableID);
                BillDAO.Instance.InsertBillInfo(cmbFood.SelectedItem.ToString().Remove(5), int.Parse(txbCount.Text));
            //}
            //else
            //{

            //}


            MainWindow.BillSource = Bill.Instance.GetBills(tableID.Remove(3));
            btnAddClicked(this, new EventArgs());
        }

        private static event EventHandler btnAddClicked;
        public static event EventHandler BtnAddClicked
        {
            add { btnAddClicked += value; }
            remove { btnAddClicked -= value; }
        }
    }
}
