using CoffeeHouseManager.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseManager.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return instance;
            }
            private set => instance = value;
        }

        public ObservableCollection<TableDTO> LoadTableList()
        {
            ObservableCollection<TableDTO> list = new ObservableCollection<TableDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.CTABLE");
            
            foreach(DataRow row in data.Rows)
            {
                TableDTO table = new TableDTO(row);
                list.Add(table);
            }
            return list;
        }
    }
}
