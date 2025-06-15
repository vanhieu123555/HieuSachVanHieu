using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TheLoaiDAL
    {
        public DataTable GetAllTheLoai()
        {
            string query = "SELECT * FROM TheLoai";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
