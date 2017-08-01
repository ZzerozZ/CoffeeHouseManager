using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseManager.DAO
{
    public class Account
    {
        private static Account instance;

        public static Account Instance
        {
            get { if (instance == null) instance = new Account(); return instance; }
            private set => instance = value;
        }

        public bool Login(string id, string password)
        {
            string pass = DataProvider.Instance.ExecuteScalar("SELECT UserPassword FROM dbo.ACCOUNT WHERE UserName = '" + id + "'") as string;
            if (pass == password)//Condition
            {
                bool isAdmin = ((DataProvider.Instance.ExecuteScalar("SELECT IsManager FROM dbo.ACCOUNT WHERE UserName = '" + id + "'")) as bool? == true);
                if (isAdmin)
                    MainWindow.isAd = true;

                return true;
            }

            return false;
        }
    }
}
