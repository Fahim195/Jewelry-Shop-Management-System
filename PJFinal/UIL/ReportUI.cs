using PJFinal.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJFinal.UIL
{
    public partial class ReportUI : Form
    {
        int B = 0;
        int BillingID = 0;
        float Due = 0;
        public ReportUI(int A,int ID,float DUE)
        {
            InitializeComponent();
            B = A;
            BillingID = ID;
            Due = DUE;
        }

        private void ReportUI_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            string DbSereverLink = @"Data Source=DESKTOP-304LGOR\SQLEXPRESS;Database=AJMS;Integrated Security=SSPI";
            connection.ConnectionString = DbSereverLink;
            connection.Open();
            

            string query = "Select * from Customer where id=" + BillingID + "";
            SqlCommand ACtion = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = ACtion;
            DataTable dtt = new DataTable();
            sda.Fill(dtt);

            string query2 = "SELECT DID, Item, ProductType, ProductUnit, Vori, Ana, Roti, Point, Total, DesignCost FROM ORDERS where cid="+ BillingID + "";
            SqlCommand ACtion2 = new SqlCommand(query2, connection);
            SqlDataAdapter sda2 = new SqlDataAdapter();
            sda2.SelectCommand = ACtion2;
            DataTable Datas = new DataTable();
            sda2.Fill(Datas);

            
            string status = "";
            if (B==2)
            {
                status = "Order Sliip";
            }
            else if(B == 3)
            {
                status = "Delivery Sliip";
            }
            else
            {
                status = "Payment Sliip";
            }
            DataTable aDT = new DataTable();
            aDT.Clear();
            aDT.Columns.Add("SlipStatus");
            aDT.Rows.Add(new object[] { status });

            string OrderDetailsQuery = "SELECT     IssueDate, DeliveryDate, ProductRate, DepoVori, DepoAna, DepoRoti, DepoPoint, DipositedWeight, TotalVori, TotalAna, TotalRoti, TotalPoint, TotalWeight, FinalVori, FinalAna, FinalRoti, FinalPoint,FinalWeight, OrderStatus FROM OrderDetails where Cid="+ BillingID + "";
            SqlCommand oDetails_Action = new SqlCommand(OrderDetailsQuery, connection);
            SqlDataAdapter oDetails_sda = new SqlDataAdapter();
            oDetails_sda.SelectCommand = oDetails_Action;
            DataTable oDetails_dTable = new DataTable();
            oDetails_sda.Fill(oDetails_dTable);

            string payment_Query = "SELECT     PaymentDate, ProductCharge, DesigningCharge, TotalBill, Advance, Due, Discount, PaymentStatus FROM Payment where CID="+ BillingID+ "";
            SqlCommand payment_Actn = new SqlCommand(payment_Query, connection);
            SqlDataAdapter payment_sDAa = new SqlDataAdapter();
            payment_sDAa.SelectCommand = payment_Actn;
            DataTable payment_dTable = new DataTable();
            payment_sDAa.Fill(payment_dTable);

            if (float.Parse(payment_dTable.Rows[0][5].ToString()) > 0)
            {
                Billing_Report_WithDue aBillingReport_WithDue = new Billing_Report_WithDue();
                aBillingReport_WithDue.Database.Tables["Customer"].SetDataSource(dtt);
                aBillingReport_WithDue.Database.Tables["Orders"].SetDataSource(Datas);
                aBillingReport_WithDue.Database.Tables["SlipType"].SetDataSource(aDT);
                aBillingReport_WithDue.Database.Tables["OrderDetails"].SetDataSource(oDetails_dTable);
                aBillingReport_WithDue.Database.Tables["Payment"].SetDataSource(payment_dTable);
                crystalReportViewer1.ReportSource = aBillingReport_WithDue;
            }
            else
            {
                Billing_Report aBillingReport = new Billing_Report();
                aBillingReport.Database.Tables["Customer"].SetDataSource(dtt);
                aBillingReport.Database.Tables["Orders"].SetDataSource(Datas);
                aBillingReport.Database.Tables["SlipType"].SetDataSource(aDT);
                aBillingReport.Database.Tables["OrderDetails"].SetDataSource(oDetails_dTable);
                aBillingReport.Database.Tables["Payment"].SetDataSource(payment_dTable);
                crystalReportViewer1.ReportSource = aBillingReport;
            }

           
        }
    }
}
