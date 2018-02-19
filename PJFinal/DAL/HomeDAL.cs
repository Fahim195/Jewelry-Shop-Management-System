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
    class HomeDAL
    {
        public DataTable[] GetInformationInHomeUI_DAL()
        {
            SqlConnection connection = DBConnection.OpenConnection();
            String query = "SELECT Customer.ID, Customer.Name, Customer.ContactNo, OrderDetails.DeliveryDate, OrderDetails.OrderStatus, Payment.PaymentStatus FROM Customer INNER JOIN OrderDetails ON Customer.ID = OrderDetails.CID INNER JOIN ORDERS ON Customer.ID = ORDERS.CID INNER JOIN Design ON ORDERS.DID = Design.DID INNER JOIN Payment ON Customer.ID = Payment.CID where OrderDetails.DeliveryDate=GETDATE()";
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            


            String query12 = "SELECT OID, Item, ProductType, ProductUnit, Total FROM ORDERS  join OrderDetails on ORDERS.CID=OrderDetails.CID where OrderDetails.DeliveryDate=GETDATE()";
            SqlCommand ACTION = new SqlCommand(query12, connection);
            DataTable dT = new DataTable();
            SqlDataAdapter Sdata = new SqlDataAdapter();
            Sdata.SelectCommand = ACTION;
            Sdata.Fill(dT);
            return new DataTable[] { dTable,dT};
        }
    }
}
