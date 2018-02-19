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
    class PaymentDAL
    {
        public bool SavePaymenInformationtDAL(Payment aPayment)
        {
            string PaymentLedger = "INSERT INTO PaymentLedger VALUES(" + aPayment.CID + ",GETDATE()," + aPayment.LastPayment + ",'Payment')"; 
            SqlConnection connection = DBConnection.OpenConnection();
            string query = "UPDATE Payment SET PaymentDate =GETDATE(), Due =" + aPayment.Due + ", Discount =" + aPayment.Discount + ", LastPayment =" + aPayment.LastPayment + ", PaymentStatus ='" + aPayment.PaymentStatus + "' where CID=" +aPayment.CID + "";
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
        public int CancelPaymentDAL(Payment aPayment)
        {
            MainUnit aMainUnit = new MainUnit();
            int a = 2;
            SqlConnection connection = DBConnection.OpenConnection();
            string GetLASTpayment_Query = " SELECT  * FROM PaymentLedger Where CID="+aPayment.CID+ " and Description='Payment' and PaymentDate=(select MAX(PaymentDate) from PaymentLedger where CID=" + aPayment.CID + " and Description='Payment')";
            SqlCommand Action = new SqlCommand(GetLASTpayment_Query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
                if (dTable.Rows.Count != 0)
                {
                aPayment.Due = aPayment.Due + float.Parse(dTable.Rows[0][2].ToString());
                string DeleteLASTpayment_and_getpreviouslastPayment_Query = "Delete PaymentLedger Where CID=" + aPayment.CID + " and Description='Payment' and PaymentDate=(select MAX(PaymentDate) from PaymentLedger where CID=" + aPayment.CID + " and Description='Payment')";
                SqlCommand Action1 = new SqlCommand(DeleteLASTpayment_and_getpreviouslastPayment_Query, connection);
                int Result = Action1.ExecuteNonQuery();
               
                DataTable dTable1 = new DataTable();
                SqlDataAdapter Sda1 = new SqlDataAdapter();
                Sda1.SelectCommand = Action;
                Sda.Fill(dTable1);
                if (dTable1.Rows.Count != 0)
                {
                    aPayment.LastPayment = float.Parse(dTable1.Rows[0][2].ToString());
                    aPayment.PaymentStatus = aMainUnit.PaymentStatusDetect(aPayment.Due.ToString());
                    aPayment.DateTime = dTable.Rows[0][1].ToString();
                    
                    a = 1;

                }
                else
                {
                    string queryTogetDateOfAdvance = "SELECT  * FROM PaymentLedger Where CID=" + aPayment.CID + " and  PaymentDate=(select MAX(PaymentDate) from PaymentLedger where CID=" + aPayment.CID + " and Description !='Payment' and Description !='Payment_DEL_DIS')";
                    SqlCommand ActionTogetDateOfAdvance = new SqlCommand(queryTogetDateOfAdvance, connection);
                    DataTable dTableTogetDateOfAdvance = new DataTable();
                    SqlDataAdapter SdaTogetDateOfAdvance = new SqlDataAdapter();
                    SdaTogetDateOfAdvance.SelectCommand = ActionTogetDateOfAdvance;
                    SdaTogetDateOfAdvance.Fill(dTableTogetDateOfAdvance);
                    aPayment.LastPayment = float.Parse(dTableTogetDateOfAdvance.Rows[0][2].ToString());
                    aPayment.PaymentStatus = aMainUnit.PaymentStatusDetect(aPayment.Due.ToString());
                    aPayment.DateTime = dTableTogetDateOfAdvance.Rows[0][1].ToString();

                    a = 1;
                }
               
                string query = "UPDATE Payment SET PaymentDate ='" + aPayment.DateTime + "', Due =" + aPayment.Due + ", LastPayment =" + aPayment.LastPayment + ", PaymentStatus ='" + aPayment.PaymentStatus + "' where CID=" + aPayment.CID + "";
                SqlCommand Action2 = new SqlCommand(query, connection);
                Action2.ExecuteNonQuery();
                return a;
            }
            else
            {
                return a;
            }    
        }
    }
}
