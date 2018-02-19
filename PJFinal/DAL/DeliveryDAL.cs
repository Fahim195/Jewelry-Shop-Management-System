using PJFinal.DAL.DAO;
using PJFinal.UIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJFinal.DAL
{
    class DeliveryDAL
    {
        public DataTable[] SearchOrderInformationforDELIVERY_UIto_UpdateDAL(Customer aCustomer)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "SELECT Customer.* ,OrderDetails.* ,Payment.* from Customer join OrderDetails on OrderDetails.CID=Customer.ID join Payment on Payment.CID =Customer.ID where Customer.ID=" + aCustomer.ID + "";
            String query1 = "SELECT * FROM ORDERS where ORDERS.CID=" + aCustomer.ID + "";          
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            SqlCommand action1 = new SqlCommand(query1, connection);
            DataTable dTable1 = new DataTable();
            SqlDataAdapter Sda1 = new SqlDataAdapter();
            Sda.SelectCommand = action1;
            Sda.Fill(dTable1);
            connection.Close();
            return new DataTable[] { dTable, dTable1 };
        }
        public bool SaveDeliveryInformationDAL(OrderDetails aOrderDetails, Payment aPayment)
        {
            string PaymentLedger = " Delete PaymentLedger where CID=" + aOrderDetails.CID + " and [Description]='Payment_DEL' INSERT INTO PaymentLedger VALUES(" + aOrderDetails.CID + ",GETDATE()," + aPayment.LastPayment + ",'Payment_DEL') ";
            if (aPayment.Discount!=0)
            {
                PaymentLedger = " Delete PaymentLedger where CID=" + aOrderDetails.CID + " and [Description] Like '%Payment_DEL%' INSERT INTO PaymentLedger VALUES(" + aOrderDetails.CID + ",GETDATE()," + aPayment.LastPayment + ",'Payment_DEL_DIS'),(" + aOrderDetails.CID + ", GETDATE(), " + aPayment.Discount + ", 'Payment_DEL_Discount') ";
                
            }
            SqlConnection connection = DBConnection.OpenConnection();
            string query = " UPDATE OrderDetails SET FinalVori="+aOrderDetails.Final_Vori+ ",FinalAna="+aOrderDetails.Final_Ana+ ",FinalRoti="+aOrderDetails.Final_Roti+ ",FinalPoint="+aOrderDetails.Final_Point+",FinalWeight=" + aOrderDetails.FinalWeight + ", OrderStatus='"+aOrderDetails.OrderStatus+"' where CID=" +aOrderDetails.CID + " UPDATE Payment SET PaymentDate=GETDATE() ,ProductCharge=" + aPayment.ProductCharge + ", TotalBill=" + aPayment.TotalBill + ", Due=" + aPayment.Due + ",Discount=" + aPayment.Discount + ",LastPayment=" + aPayment.LastPayment + ",PaymentStatus='" + aPayment.PaymentStatus + "' where CID=" + aOrderDetails.CID + " ";
            query += PaymentLedger;
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CancelDeliveryDAL(Payment aPayment, OrderDetails aOrderDetails)
        {

            SqlConnection connection = DBConnection.OpenConnection();
            string query1 = "Select SUM(Received) from PaymentLedger where CID=" + aOrderDetails.CID + " and  [Description] NOT Like '%Payment_DEL%'";
            SqlCommand action = new SqlCommand(query1, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            if (dTable.Rows.Count > 0)
            {
                aPayment.Due =aPayment.TotalBill- float.Parse(dTable.Rows[0][0].ToString());
            }
            
            string queryToGetLastPayment = "Select* from PaymentLedger where CID = " + aOrderDetails.CID + " and  [Description] NOT Like '%Payment_DEL%' and PaymentDate=(select MAX(PaymentLedger.PaymentDate) from PaymentLedger where CID = " + aOrderDetails.CID + " and  [Description] NOT Like '%Payment_DEL%')";
            SqlCommand actionToGetLastPayment = new SqlCommand(queryToGetLastPayment, connection);
            DataTable dTableToGetLastPayment = new DataTable();
            SqlDataAdapter SdaToGetLastPayment = new SqlDataAdapter();
            SdaToGetLastPayment.SelectCommand = actionToGetLastPayment;
            SdaToGetLastPayment.Fill(dTableToGetLastPayment);
            aPayment.LastPayment =float.Parse(dTableToGetLastPayment.Rows[0][2].ToString());
            MainUnit aMainUnit = new MainUnit();
            aPayment.PaymentStatus= aMainUnit.PaymentStatusDetect(aPayment.Due.ToString());

            string queryTogetDateOfLastPayment = " SELECT  * FROM PaymentLedger Where CID=" + aOrderDetails.CID + " and [Description] NOT Like '%Payment_DEL%' and PaymentDate=(select MAX(PaymentDate) from PaymentLedger where CID=" + aOrderDetails.CID + " and [Description] Not Like '%Payment_DEL%')";
            SqlCommand ActionTogetDateOfLastPayment = new SqlCommand(queryTogetDateOfLastPayment, connection);
            DataTable dTableTogetDateOfLastPayment = new DataTable();
            SqlDataAdapter SdaTogetDateOfLastPayment = new SqlDataAdapter();
            SdaTogetDateOfLastPayment.SelectCommand = ActionTogetDateOfLastPayment;
            SdaTogetDateOfLastPayment.Fill(dTableTogetDateOfLastPayment);
            aPayment.DateTime = dTableTogetDateOfLastPayment.Rows[0][1].ToString();

            string query = "UPDATE Payment SET PaymentDate ='"+ aPayment.DateTime + "',ProductCharge="+aPayment.ProductCharge+", TotalBill =" + aPayment.TotalBill + ", Due =" + aPayment.Due + ", Discount =" + aPayment.Discount + ", LastPayment =" + aPayment.LastPayment + ", PaymentStatus ='" + aPayment.PaymentStatus + "' where CID=" + aOrderDetails.CID + " UPDATE    OrderDetails SET FinalVori =NULL, FinalAna =NULL, FinalRoti =NULL, FinalPoint =NULL, FinalWeight =NULL, OrderStatus ='" + aOrderDetails.OrderStatus+ "'  where CID=" + aOrderDetails.CID + "";
            query += " DELETE PaymentLedger WHERE CID=" + aOrderDetails.CID + " and  [Description] Like '%Payment_DEL%'";
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
