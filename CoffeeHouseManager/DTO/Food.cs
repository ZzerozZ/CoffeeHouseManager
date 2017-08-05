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
    public class Food
    {
        private static Food instance;

        public static Food Instance
        {
            get
            {
                if (instance == null)
                    instance = new Food();
                return instance;
            }
            private set => instance = value;
        }

        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }

        private string iD;
        private string name;
        private int price;

        public Food()
        { }

        public Food(string _ID, string _Name, int _Price)
        {
            iD = _ID;
            name = _Name;
            price = _Price;
        }

        public ObservableCollection<Food> GetFood(string categoryID = "")
        {
            ObservableCollection<Food> list = new ObservableCollection<Food>();

            DataTable data = new DataTable();
            string query = "SELECT * FROM dbo.FOOD";
            if(categoryID != "")
            {
                query += " WHERE IDFoodCategory = '" + categoryID + "'";
            }

            data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                list.Add(new Food((row[0]).ToString(), (row[1]).ToString(), int.Parse(row[2].ToString())));
            }

            return list;
        }
    }
}
