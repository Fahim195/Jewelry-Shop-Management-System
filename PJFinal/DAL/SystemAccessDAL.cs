using PJFinal.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.DAL
{
    class SystemAccessDAL
    {
        public bool SetSystemAccessDAL(SystemAccess aSyatemAccess)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            string Query = "UPDATE SystemAccess set userName='"+aSyatemAccess.userName+"',password='"+aSyatemAccess.Password+"'";
            SqlCommand Action = new SqlCommand(Query, connection);
            int res = Action.ExecuteNonQuery();
            if (res >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable CheckSystemAccessDAL()
        {
            SqlConnection connection = DBConnection.OpenConnection();
            string Query = "Select * from SystemAccess ";
            SqlCommand Action = new SqlCommand(Query,connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Action;
            DataTable dt=new DataTable();
            sda.Fill(dt);
            return dt;
            
        }
    }
}
