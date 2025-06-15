using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VaiTroDAL
    {
        public DataTable GetAllVaiTro()
        {
            string query = "SELECT * FROM VaiTro";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
