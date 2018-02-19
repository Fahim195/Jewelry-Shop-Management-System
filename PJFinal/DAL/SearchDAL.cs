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
    class SearchDAL
    {
        public DataTable Search_CustomerInformationDALL(Customer aCustomer, OrderDetails aOrderDetails)
        {
            string query = "SELECT Customer.ID, Customer.Name, Customer.ContactNo, Customer.Address, OrderDetails.IssueDate, OrderDetails.DeliveryDate, Payment.TotalBill, Payment.Advance, Payment.Due, Payment.Discount,OrderDetails.DepoVori, OrderDetails.DepoAna, OrderDetails.DepoRoti, OrderDetails.DepoPoint, OrderDetails.DipositedWeight, OrderDetails.TotalVori, OrderDetails.TotalAna, OrderDetails.TotalRoti,OrderDetails.TotalWeight, OrderDetails.FinalVori, OrderDetails.FinalAna, OrderDetails.FinalRoti, OrderDetails.FinalPoint, OrderDetails.FinalWeight, OrderDetails.OrderStatus,Payment.PaymentStatus FROM Customer INNER JOIN OrderDetails ON Customer.ID = OrderDetails.CID INNER JOIN ORDERS ON Customer.ID = ORDERS.CID INNER JOIN Design ON ORDERS.DID = Design.DID INNER JOIN Payment ON Customer.ID = Payment.CID";
            string Condition = "";
            bool Condition_joiner = false;
            if (aCustomer.name != "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.Name like '%" + aCustomer.name + "%'";
                Condition_joiner = true;
            }
            
            if (aCustomer.ID != 0)
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.id like '%" + aCustomer.ID + "%' ";
                Condition_joiner = true;
            }
            if (aCustomer.Address != "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.Address like '%" + aCustomer.Address + "%'";
                Condition_joiner = true;
            }           
            if (aCustomer.ContactNo != "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.ContactNo like '%" + aCustomer.ContactNo + "%'";
                Condition_joiner = true;
            }
            
            
            if (Condition_joiner)
            {
                query += " Where ";
            }

            query += Condition;
            SqlConnection connection = DBConnection.OpenConnection();
            SqlCommand Action = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dTable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dTable);
            return dTable;

        }
    }
}
