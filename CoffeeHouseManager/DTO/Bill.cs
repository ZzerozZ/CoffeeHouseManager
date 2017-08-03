using CoffeeHouseManager.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseManager.DTO
{
    public class Bill
    {
        private static Bill instance;
        private int iD;
        private string tableID;
        private bool isPaid;
        private string foodID;
        private string foodName;
        private int foodPrice;
        private int count;

        public static Bill Instance
        {
            get
            {
                if (instance == null) instance = new Bill();
                return instance;
            }
            private set => instance = value;
        }

        public int ID { get => iD; set => iD = value; }
        public string TableID { get => tableID; set => tableID = value; }
        public bool IsPaid { get => isPaid; set => isPaid = value; }
        public string FoodID { get => foodID; set => foodID = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public int FoodPrice { get => foodPrice; set => foodPrice = value; }
        public int Count { get => count; set => count = value; }

        public List<Bill> GetBills(string _TableID)
        {
            List<Bill> list = new List<Bill>();

            DataTable table = DataProvider.Instance.ExecuteQuery("Select * from dbo.BILL where TableID = '" + _TableID + "'");

            foreach(DataRow row in table.Rows)
            {
                Bill newBill = new Bill();
                newBill.ID = int.Parse(row[0].ToString());
                newBill.TableID = _TableID;
                newBill.IsPaid = (row[2].ToString() == "1");
                
                DataTable data = DataProvider.Instance.ExecuteQuery("Select FoodID, FoodCount from dbo.BILLINFO where BillID = '" + newBill.ID + "'");
                newBill.FoodID = data.Rows[0]["FoodID"].ToString();
                newBill.Count = int.Parse(data.Rows[0]["FoodCount"].ToString());
                GetFoodInfo(ref newBill);
                list.Add(newBill);
            }

            return list;
        }

        private void GetFoodInfo(ref Bill bill)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select Name, Price from dbo.FOOD where FoodID = '" + bill.FoodID + "'");
            bill.FoodName = data.Rows[0]["Name"].ToString();
            bill.FoodPrice = int.Parse(data.Rows[0]["Price"].ToString());
        }
    }
}
