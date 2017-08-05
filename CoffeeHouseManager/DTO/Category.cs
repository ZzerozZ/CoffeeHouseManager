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
    public class Category
    {
        private static Category instance;

        public static Category Instance
        {
            get
            {
                if (instance == null) instance = new Category();
                return instance;
            }

            private set => instance = value;
        }

        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }

        private string iD;
        private string name;

        public Category() { }
        public Category(string _id, string _name)
        {
            iD = _id;
            name = _name;
        }

        public ObservableCollection<Category> GetCategory()
        {
            ObservableCollection<Category> list = new ObservableCollection<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FOODCATEGORY");

            foreach(DataRow row in data.Rows)
            {
                list.Add(new Category(row[0].ToString(), row[1].ToString()));
            }

            return list;
        }
    }
}
