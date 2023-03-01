using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaneyDataDLL
{
   public class DatabaseConnection
    {
        private static string str = ConfigurationManager.ConnectionStrings["Dbcon"].ConnectionString;

        private static SqlConnection con = new SqlConnection(str);
        public SqlConnection getConnection()
        {
            return con;
        }
        public void OpenConnection()
        {
            con.Open();
            // Console.WriteLine("connection established");
        }
        public void CloseConnection()
        {
            con.Close();
            Console.WriteLine("connection closed");
        }
    }
}
