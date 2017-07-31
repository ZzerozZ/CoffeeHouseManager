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
            GetAccountList();
        }

        public void GetAccountList()
        {
            string conectionString = "Data Source=NGHIA-ACER;Initial Catalog=CoffeeHouse;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conectionString);
            connection.Open();
            string query = "Select * from dbo.ACCOUNT";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adap = new SqlDataAdapter(command);
            DataTable data = new DataTable();

            adap.Fill(data);

            connection.Close();
            
        }
    }
}
