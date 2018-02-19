using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.DAL.DAO
{
    class DBConnection
    {
        public static SqlConnection OpenConnection()
        {
            string userName = System.Environment.UserName;
            string sqlServer = File.ReadAllText(@"C:\Users\" + userName + @"\Documents\DataSource.txt");
            SqlConnection connection = new SqlConnection();
            string DbSereverLink = "Data Source=" + sqlServer + ";Database=AJMS;Integrated Security=SSPI";
            connection.ConnectionString = DbSereverLink;
            connection.Open();
            return connection;
        }
    }
}
