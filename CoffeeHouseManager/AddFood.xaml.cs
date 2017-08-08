using CoffeeHouseManager.DAO;
using CoffeeHouseManager.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //Need to repair!

        ObservableCollection<Category> ListCategory = new ObservableCollection<Category>();

        public AddFood()
        {
            InitializeComponent();

            List<string> category = new List<string>();
            DataTable table = DataProvider.Instance.ExecuteQuery("Select FoodCategoryID, Name from dbo.FOODCATEGORY");
            foreach (DataRow row in table.Rows)
            {
                category.Add(row[0].ToString() + " - " + row[1].ToString());
            }

            //cmbCategory.ItemsSource = category;
            //cmbCategory.SelectedIndex = 0;

            LoadFoodCategory();
            lsbCategory.ItemsSource = ListCategory;
            lsbCategory.SelectedIndex = 0;
        }


        public void LoadFoodCategory()
        {
            ListCategory = Category.Instance.GetCategory();

            foreach(Category cate in ListCategory)
            {
                cate.Foods = Food.Instance.GetFood(cate.ID);
            }
        }


        //private void LoadFoodToListView()
        //{
        //    ObservableCollection<Food> list = Food.Instance.GetFood();
        //    lsbFood.ItemsSource = list;
        //}

        //private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    List<string> food = new List<string>();
        //    DataTable table = DataProvider.Instance.ExecuteQuery("SELECT FoodID, Name, Price FROM dbo.FOOD WHERE IDFoodCategory = '" + cmbCategory.SelectedItem.ToString().Remove(3) + "'");
        //    foreach (DataRow row in table.Rows)
        //    {
        //        food.Add(row[0].ToString() + " - " + row[1].ToString());
        //    }

        //    cmbFood.ItemsSource = food;
        //    cmbFood.SelectedIndex = 0;


        //}

        //private void cmbFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (cmbFood.SelectedItem != null)
        //        txbSearch.Text = cmbFood.SelectedItem.ToString().Remove(0, cmbFood.SelectedItem.ToString().IndexOf('-') + 2);
        //}

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    string tableID = MainWindow.lastButton.Content.ToString().Replace("Table ", "").Remove(3);

        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT B.ID FROM dbo.BILLINFO AS BI, dbo.BILL AS B WHERE B.ID = BI.BillID AND B.TableID = '" + tableID + "' AND BI.FoodID = '" + cmbFood.SelectedItem.ToString().Remove(5) + "'");
        //    if (data.Rows.Count == 0)
        //    {
        //        BillDAO.Instance.InsertBill(tableID);
        //        BillDAO.Instance.InsertBillInfo(cmbFood.SelectedItem.ToString().Remove(5), int.Parse(txblCount.Text));
        //    }
        //    else
        //    {
        //        DataProvider.Instance.ExecuteQuery("UPDATE dbo.BILLINFO SET FoodCount = FoodCount + " + txblCount.Text + " WHERE BillID = " + data.Rows[0]["ID"]);
        //    }

        //    MainWindow.BillSource = Bill.Instance.GetBills(tableID);
        //    btnAddClicked(this, new EventArgs());

        //    txblCount.Text = "1";
        //}

        private static event EventHandler btnAddClicked;
        public static event EventHandler BtnAddClicked
        {
            add { btnAddClicked += value; }
            remove { btnAddClicked -= value; }
        }

        //private void btnUp_Click(object sender, RoutedEventArgs e)
        //{
        //    txblCount.Text = (int.Parse(txblCount.Text) + 1).ToString();
        //}

        //private void btnDown_Click(object sender, RoutedEventArgs e)
        //{
        //    if(int.Parse(txblCount.Text) > 1)
        //        txblCount.Text = (int.Parse(txblCount.Text) - 1).ToString();
        //}


        private void lsbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lsbFood.ItemsSource = ListCategory[lsbCategory.SelectedIndex].Foods;
        }

        private void btnAddFoodInFoodList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveFoodInFoodList_Click(object sender, RoutedEventArgs e)
        {
            int count = int.Parse((((sender as Button).Parent as Grid).Children[2] as TextBlock).Text);
            if (count > 1)
                (((sender as Button).Parent as Grid).Children[2] as TextBlock).Text = (count - 1).ToString();
            else
            {
            }
        }
    }
}
