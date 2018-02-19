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
    class OrderDAL
    {
        public int GetMaxIDforCustomerDAL()
        {
            int MaxID = 0;
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "select MAX(ID) from Customer";
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            try
            {
                MaxID = (int)dTable.Rows[0][0];
            }
            catch
            {
                MaxID = 0;
            }

            return MaxID;
        }
        public DataTable GetDesigningCharge_DAL(Design aDesign)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "select DesignCost from Design where DID="+aDesign.DID+"";
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            return dTable;

        }
        public bool SaveOrderUIInformationDAL(Customer aCustomer, OrderDetails aOrderDetails, Payment aPayment, string[,] arr , int TotalNumberOfOrder)
        {
            bool checkMultipleQuery = false; 
            string orderQuery = "INSERT into ORDERS values ";
            for (int i = 0; i < TotalNumberOfOrder; i++)
            {
                if (checkMultipleQuery)
                {
                    orderQuery += " , ";
                }
                orderQuery += "("+ aOrderDetails.CID + ","+ arr[i,8]+",'"+ arr[i,1] + "','"+ arr[i, 2] + "','"+ arr[i, 0] + "'," + arr[i, 3] + "," + arr[i, 4] + "," + arr[i, 5] + "," + arr[i, 6] + "," + arr[i, 7] + "," + arr[i,9] + ") ";
                checkMultipleQuery =true;
               
            }
            string PaymentLedger = "INSERT INTO PaymentLedger VALUES(" + aCustomer.ID + ",GETDATE()," + aPayment.LastPayment + ",'Advance')";
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "insert into Customer (ID,Name,[Address],ContactNo,Image) values (" + aCustomer.ID + ",'" + aCustomer.name + "','" + aCustomer.Address + "','" + aCustomer.ContactNo + "',@images)  "+ orderQuery + "  insert into OrderDetails(CID, IssueDate, DeliveryDate, ProductRate, DepoVori, DepoAna, DepoRoti, DepoPoint, DipositedWeight, TotalVori, TotalAna, TotalRoti, TotalPoint, TotalWeight, OrderStatus) values (" + aCustomer.ID + ",'" + aOrderDetails.IssueDate + "','" + aOrderDetails.DeliveryDate + "'," + aOrderDetails.RateOfProduct + ","+aOrderDetails.Depo_Vori+","+aOrderDetails.Depo_Ana+","+aOrderDetails.Depo_Roti+","+aOrderDetails.Depo_Point+ "," + aOrderDetails.DepositedProductAmount + ","+aOrderDetails.Total_Vori+","+aOrderDetails.Total_Ana+","+aOrderDetails.Total_Roti+","+aOrderDetails.Total_Point+ "," + aOrderDetails.TotalWeight + ",'" + aOrderDetails.OrderStatus + "') insert into Payment (CID,PaymentDate,ProductCharge,DesigningCharge,TotalBill,Advance,Due,Discount,LastPayment,PaymentStatus) values (" + aCustomer.ID + ", GETDATE() ," + aPayment.ProductCharge+ "," + aPayment.DesigningCharge + "," + aPayment.TotalBill + "," + aPayment.Advance + "," + aPayment.Due + "," + aPayment.Discount + "," + aPayment.LastPayment + ",'" + aPayment.PaymentStatus + "') "+ PaymentLedger + " ";
            SqlCommand Action = new SqlCommand(query, connection);
            Action.Parameters.Add(new SqlParameter("@images",aCustomer.images));
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
        public DataTable[] SearchOrderInformationTo_UpdateDAL(Customer aCustomer)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "SELECT Customer.* ,OrderDetails.* ,Payment.* from Customer join OrderDetails on OrderDetails.CID=Customer.ID join Payment on Payment.CID =Customer.ID where Customer.ID="+aCustomer.ID+"";
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
            return new DataTable[] {dTable,dTable1 };
        }
        public bool UpdateOrderUIInformationDAL(Customer aCustomer, OrderDetails aOrderDetails, Payment aPayment, string[,] arr, int TotalNumberOfOrder)
        {
            bool checkMultipleQuery = false;
            string orderQuery = "DELETE ORDERS where ORDERS.CID="+aCustomer.ID+"  INSERT into ORDERS values ";
            for (int i = 0; i < TotalNumberOfOrder; i++)
            {
                if (checkMultipleQuery)
                {
                    orderQuery += " , ";
                }
                orderQuery += "(" + aOrderDetails.CID + "," + arr[i, 8] + ",'" + arr[i, 1] + "','" + arr[i, 2] + "','" + arr[i, 0] + "'," + arr[i, 3] + "," + arr[i, 4] + "," + arr[i, 5] + "," + arr[i, 6] + "," + arr[i, 7] + "," + arr[i, 9] + ") ";
                checkMultipleQuery = true;
                
            }
            string PaymentLedger = "Update PaymentLedger set PaymentDate=GETDATE(),Received=" + aPayment.LastPayment + " where CID=" + aOrderDetails.CID + " and [Description]='Advance' ";
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "UPDATE Customer SET Name='" + aCustomer.name + "',[Address]='" + aCustomer.Address + "',ContactNo='" + aCustomer.ContactNo + "' where ID="+aCustomer.ID+"  " + orderQuery + "  UPDATE OrderDetails SET  IssueDate='" + aOrderDetails.IssueDate + "', DeliveryDate='" + aOrderDetails.DeliveryDate + "', ProductRate="+aOrderDetails.RateOfProduct+", DepoVori=" + aOrderDetails.Depo_Vori + ", DepoAna=" + aOrderDetails.Depo_Ana + ", DepoRoti=" + aOrderDetails.Depo_Roti + ", DepoPoint=" + aOrderDetails.Depo_Point + ", DipositedWeight=" + aOrderDetails.DepositedProductAmount + ", TotalVori=" + aOrderDetails.Total_Vori + ", TotalAna=" + aOrderDetails.Total_Ana + ", TotalRoti=" + aOrderDetails.Total_Roti + ", TotalPoint=" + aOrderDetails.Total_Point + ", TotalWeight=" + aOrderDetails.TotalWeight + ", OrderStatus='" + aOrderDetails.OrderStatus + "'  UPDATE Payment SET PaymentDate=GETDATE() ,ProductCharge=" + aPayment.ProductCharge + ",DesigningCharge=" + aPayment.DesigningCharge + ",TotalBill=" + aPayment.TotalBill + ",Advance=" + aPayment.Advance + ",Due=" + aPayment.Due + ",Discount=" + aPayment.Discount + ",LastPayment=" + aPayment.LastPayment + ",PaymentStatus='" + aPayment.PaymentStatus + "' "+PaymentLedger+"";
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
        public bool CancelOrderDAL(Customer aCustomer)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            string query = " delete OrderDetails  where CID=" + aCustomer.ID + " delete Payment  where CID=" + aCustomer.ID + "  delete Orders  where CID=" + aCustomer.ID + " Delete Customer where ID=" + aCustomer.ID + "";
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
