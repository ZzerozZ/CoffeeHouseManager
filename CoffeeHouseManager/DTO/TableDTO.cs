using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseManager.DTO
{
    public class TableDTO
    {
        private string id;
        private bool status;

        public string Id { get => id; set => id = value; }
        public bool Status { get => status; set => status = value; }

        public TableDTO(string _id, bool _status)
        {
            id = _id;
            status = _status;
        }

        public TableDTO(DataRow row)
        {
            id = (string)row["TableID"];
            status = (bool)row["IsAvailable"];
        }
    }
}
