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
    class PaymentLedgerDAL
    {
         public DataTable ViewPaymentLadgerOfSpecificDate(string LedgerType,string StartDate,String EndDate)
        {
            String query = "SELECT * FROM PaymentLedger";
            if (LedgerType=="Today")
            {
                query += " where CAST(PaymentLedger.PaymentDate AS DATE) = convert(date, getdate()) ";
            }       
            else
            {
                query += " where PaymentDate Between '"+StartDate+ "' AND '" + EndDate + "'";
            }
            SqlConnection connection = DBConnection.OpenConnection();
            
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            return dTable;
        }

        public DataTable ViewDueOfSpecificDate(string LedgerType, string StartDate, String EndDate)
        {
            String query = "SELECT Customer.ID, Customer.Name, Customer.ContactNo,Payment.Due,OrderDetails.OrderStatus FROM Customer INNER JOIN OrderDetails ON Customer.ID = OrderDetails.CID INNER JOIN ORDERS ON Customer.ID = ORDERS.CID INNER JOIN Payment ON Customer.ID = Payment.CID where Payment.Due !=0 ";
            if (LedgerType == "Old Dues")
            {
                query += " order by Customer.ID desc";
            }
            if (LedgerType == "Due In Specific Time Period")
            {
                query += " and OrderDetails.IssueDate Between '" + StartDate + "' AND '" + EndDate + "'";
            } 
            SqlConnection connection = DBConnection.OpenConnection();
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            return dTable;
        }
        public DataTable[] Information_in_ViewDailyLedgeerDAL()
        {
            SqlConnection connection = DBConnection.OpenConnection();

            String Ordersquery = "SELECT OrderDetails.DeliveryDate, OrderDetails.TotalWeight, OrderDetails.DipositedWeight,Payment.TotalBill,Payment.Due,Payment.Advance FROM Customer INNER JOIN OrderDetails ON Customer.ID = OrderDetails.CID INNER JOIN Payment ON Customer.ID = Payment.CID where CAST(OrderDetails.IssueDate AS DATE) = convert(date, getdate())";
            SqlCommand Ordersaction = new SqlCommand(Ordersquery, connection);
            DataTable OrdersdTable = new DataTable();
            SqlDataAdapter OrdersSda = new SqlDataAdapter();
            OrdersSda.SelectCommand = Ordersaction;
            OrdersSda.Fill(OrdersdTable);

            String OrderDetailsquery = "SELECT ORDERS.OID, ORDERS.DID, ORDERS.ProductType, ORDERS.ProductUnit, ORDERS.Item FROM Customer INNER JOIN OrderDetails ON Customer.ID = OrderDetails.CID INNER JOIN ORDERS ON Customer.ID = ORDERS.CID where CAST(OrderDetails.IssueDate AS DATE) = convert(date, getdate())"; 
            SqlCommand OrderDetailsaction = new SqlCommand(OrderDetailsquery, connection);
            DataTable OrderDetailsdTable = new DataTable();
            SqlDataAdapter OrderDetailsSda = new SqlDataAdapter();
            OrderDetailsSda.SelectCommand = OrderDetailsaction;
            OrderDetailsSda.Fill(OrderDetailsdTable);

            String DailyTransectionquery = "SELECT CID, Received,Description FROM PaymentLedger where CAST(PaymentLedger.PaymentDate AS DATE) = convert(date, getdate())";
            SqlCommand DailyTransectionaction = new SqlCommand(DailyTransectionquery, connection);
            DataTable DailyTransectiondTable = new DataTable();
            SqlDataAdapter DailyTransectionSda = new SqlDataAdapter();
            DailyTransectionSda.SelectCommand = DailyTransectionaction;
            DailyTransectionSda.Fill(DailyTransectiondTable);

            String TotalPAyemntquery = "SELECT SUM(Received) FROM PaymentLedger where PaymentLedger.Description = 'Payment' AND CAST(PaymentLedger.PaymentDate AS DATE) = convert(date, getdate())";
            SqlCommand TotalPAyemntaction = new SqlCommand(TotalPAyemntquery, connection);
            DataTable TotalPAyemntTable = new DataTable();
            SqlDataAdapter TotalPAyemntSda = new SqlDataAdapter();
            TotalPAyemntSda.SelectCommand = TotalPAyemntaction;
            TotalPAyemntSda.Fill(TotalPAyemntTable);

            String TotalGoldquery = "select sum(OrderDetails.TotalWeight),SUM(OrderDetails.DipositedWeight) from OrderDetails join ORDERS on ORDERS.CID=OrderDetails.CID where ORDERS.ProductType='gold' and CAST(OrderDetails.IssueDate AS DATE) = convert(date, getdate())";
            SqlCommand TotalGoldaction = new SqlCommand(TotalGoldquery, connection);
            DataTable TotalGoldTable = new DataTable();
            SqlDataAdapter TotalGoldSda = new SqlDataAdapter();
            TotalGoldSda.SelectCommand = TotalGoldaction;
            TotalGoldSda.Fill(TotalGoldTable);

            String TotalSilverquery = "select sum(OrderDetails.TotalWeight),SUM(OrderDetails.DipositedWeight) from OrderDetails join ORDERS on ORDERS.CID=OrderDetails.CID where ORDERS.ProductType='silver' and CAST(OrderDetails.IssueDate AS DATE) = convert(date, getdate())";
            SqlCommand TotalSilveraction = new SqlCommand(TotalSilverquery, connection);
            DataTable TotalSilverdTable = new DataTable();
            SqlDataAdapter TotalSilverSda = new SqlDataAdapter();
            TotalSilverSda.SelectCommand = TotalSilveraction;
            TotalSilverSda.Fill(TotalSilverdTable);

            return new DataTable[] { OrdersdTable, OrderDetailsdTable, DailyTransectiondTable, TotalPAyemntTable, TotalGoldTable, TotalSilverdTable };
        }
    }
}
