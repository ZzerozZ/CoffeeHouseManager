using CoffeeHouseManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
            private set => instance = value;
        }

        public void InsertBill(string TableID)
        {
            DataProvider.Instance.ExecuteQuery("INSERT dbo.BILL( TableID) VALUES  ( '" + TableID.Remove(3).ToString() + "' )");
        }

        public void InsertBillInfo(string FoodID, int FoodCount)
        {
            DataProvider.Instance.ExecuteQuery("INSERT dbo.BILLINFO( BillID, FoodID, FoodCount ) VALUES (" + GetMaxBillID() + ", '" + FoodID + "'," + FoodCount.ToString() +" )");
        }

        private string GetMaxBillID()
        {
            return DataProvider.Instance.ExecuteScalar("SELECT MAX(ID) FROM dbo.BILL").ToString();
        }
    }
}
