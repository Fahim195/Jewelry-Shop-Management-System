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
    class DesignDAL
    {
        public DataTable SaveDesignDAL(Design aDesign)
        {
            DataTable dTable = new DataTable ();
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "Insert Into Design Values("+aDesign.DID+","+aDesign.DesignCost+",'"+aDesign.Details+"',@images)";
            SqlCommand Action = new SqlCommand(query, connection);
            Action.Parameters.Add(new SqlParameter("@images",aDesign.images));
            int result=Action.ExecuteNonQuery();
            if (result<=0)
            {
                return dTable=null;
            }
            else
            {
                dTable = GetDesignInformationInGridView();
                return dTable;
            }

        }
        public DataTable GetDesignInformationInGridView()
        {
            DataTable dTable = new DataTable();
            SqlConnection connection = DBConnection.OpenConnection();
            string Query_getDesigns = "Select * from Design";
            SqlCommand Action_getDesigns = new SqlCommand(Query_getDesigns, connection);
            SqlDataAdapter SDA = new SqlDataAdapter();
            SDA.SelectCommand = Action_getDesigns;
            SDA.Fill(dTable);
            return dTable;
        }
        public DataTable UpdateDesignDAL(Design aDesign,int  DesignID_BeforeUpdate)
        {
            int result = 0;
            DataTable dTable = new DataTable();
            SqlConnection connection = DBConnection.OpenConnection();
            try
            {
                string query = "update Design set  DID=" + aDesign.DID + ",DesignCost=" + aDesign.DesignCost + ",Details='" + aDesign.Details + "',image=@images where DID=" + DesignID_BeforeUpdate + "";
                SqlCommand Action = new SqlCommand(query, connection);
                Action.Parameters.Add(new SqlParameter("@images", aDesign.images));
                result = Action.ExecuteNonQuery();
            }
            catch
            {
                string query = "update Design set  DID=" + aDesign.DID + ",DesignCost=" + aDesign.DesignCost + ",Details='" + aDesign.Details + "' where DID=" + DesignID_BeforeUpdate + "";
                SqlCommand Action = new SqlCommand(query, connection);
               
                result = Action.ExecuteNonQuery();
            }
           
            if (result <= 0)
            {
                return dTable = null;
            }
            else
            {
                dTable = GetDesignInformationInGridView();
                return dTable;
            }

        }
        public DataTable DeleteDesign_DAL(Design aDesign)
        {
            DataTable dTable = new DataTable();
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "Delete Design Where DID="+aDesign.DID+"";
            SqlCommand Action = new SqlCommand(query, connection);  
            int result = Action.ExecuteNonQuery();
            if (result <= 0)
            {
                return dTable = null;
            }
            else
            {
                dTable = GetDesignInformationInGridView();
                return dTable;
            }

        }
        public DataTable GetDesignIn_GalleryDAL()
        {
            DataTable dTable = new DataTable();
            SqlConnection connection = DBConnection.OpenConnection();
            string Query_getDesigns = "Select * from Design";
            SqlCommand Action_getDesigns = new SqlCommand(Query_getDesigns, connection);
            SqlDataAdapter SDA = new SqlDataAdapter();
            SDA.SelectCommand = Action_getDesigns;
            SDA.Fill(dTable);
            return dTable;
        }
    }
}
