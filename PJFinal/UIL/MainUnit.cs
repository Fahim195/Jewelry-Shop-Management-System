using PJFinal.BLL;
using PJFinal.DAL;
using PJFinal.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJFinal.UIL
{
    public partial class MainUnit : Form
    {
        public MainUnit()
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            OrderDetailsdataGridView1.AllowUserToAddRows = false;

            HomeBLL aHomeBLL = new HomeBLL();
            DataTable[] dTables = aHomeBLL.GetInformationInHomeUI_BLL();
            HOME_Deliverable_Orders_dataGridView1.DataSource = dTables[0];
            HOME_Deliverable_Products_dataGridView2.DataSource = dTables[1];

        }
        int A = 0;
        public void MenuStripDesignOnClick(int valueofA)
        {

            if (valueofA == 1)
            {
                hOMEToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                hOMEToolStripMenuItem.ForeColor = Color.White;

            }
            if (valueofA == 2)
            {
                oRDERToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                oRDERToolStripMenuItem.ForeColor = Color.White;
            }
            if (valueofA == 3)
            {
                dELIVERYToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                dELIVERYToolStripMenuItem.ForeColor = Color.White;
            }
            if (valueofA == 4)
            {
                pAYMENTToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                pAYMENTToolStripMenuItem.ForeColor = Color.White;
            }
            if (valueofA == 5)
            {
                dELIVERYSCHEDULEToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                dELIVERYSCHEDULEToolStripMenuItem.ForeColor = Color.White;
            }
            if (valueofA == 6)
            {
                sEARCHToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                sEARCHToolStripMenuItem.ForeColor = Color.White;
            }
            if (valueofA == 7)
            {
                dESIGNToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                dESIGNToolStripMenuItem.ForeColor = Color.White;
            }
            if (valueofA == 8)
            {
                aDMINToolStripMenuItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#000040");
                aDMINToolStripMenuItem.ForeColor = Color.White;
            }
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.DarkSlateGray, rc);
                }
            }
        }
        private void MainUnit_Load(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = false;
            ORDER_Search_button14.Visible = false;
            ActionStataus__label16.Visible = false;
            HOME_panel16.Visible = true;
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            SEARCH_panel.Visible = false;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;


        }
        public string CheckProductUnitType()
        {
            string unit = "";
            if (ORDER_21K_radioButton2.Checked == true)
            {
                unit = "21-K";
            }
            if (ORDER_21kHOL_radioButton4.Checked == true)
            {
                unit = "21-K-HOL";

            }
            if (ORDER_22K_radioButton3.Checked == true)
            {
                unit = "22-K";
            }
            return unit;
        }
        private void Clear_OrderUI_Orders_TextBoxes()
        {
            ORDER_21K_radioButton2.Checked = false;
            ORDER_21kHOL_radioButton4.Checked = false;
            ORDER_22K_radioButton3.Checked = false;
            ORDER_ProductType_comboBox1.Text = "";
            ORDER_ItemTtypecomboBox1.Text = "";
                    
            ORDER_DesignIDtextBox6.Text = "";
            OrderSpecificDesignCosttextBox1.Text = "";
            OrderPanel_OrdersInVori_textBox1.Text = "";
            OrderProdutWeight_Point_textBox3.Text = "";
            OrderProdutWeight_Roti_textBox2.Text = "";
            OrderProdutWeight_Ani_textBox1.Text = "";
            OrderProdutWeight_Vori__textBox1.Text = "";
            OrderPanel_OrdersInVori_textBox1.Text = "";
            TotalPoint_textBox4.Text = "";
            TotalRoti_textBox3.Text = "";
            TotalAna_textBox2.Text = "";
            TotalVori_textBox1.Text = "";
            ORDER_Total_Weight_textBox7.Text = "";
            Order_Depo_Point_textBox1.Text = "";
            Order_Depo__Roti_textBox2.Text = "";
            Order_Depo__Ana_textBox3.Text = "";
            Order_Depo__Vori_textBox4.Text = "";
            TotalDepoWeight_textBox3.Text = "";
            OrderDetailsdataGridView1.Rows.Clear();
            PAYMENT_dataGridView1.Rows.Clear();
            ORDER_Customer_pictureBox3.Image = null;
        }
        private void Clear_OrderUI_ALL_TextBoxes()
        {
            SEARCH_Result_dataGridView1.DataSource = null;
            ORDER_orderIDtextBox2.Text ="";
            ORDER_CustomerNametextBox1.Text = "";
            ORDER_Address_textBox4.Text = "";
            ORDER_ContactNotextBox3.Text = "";
            ORDER_IssueDate_dateTimePicker1.Text = "";
            ORDER_DeliveryDatedateTimePicker2.Text = "";
            ORDER_RateofProduct_textBox5.Text = "";
            ORDER_Total_Weight_textBox7.Text = "";
            TotalDepoWeight_textBox3.Text = "";
            ORDER_ProductPrice_textBox10.Text = "";
            ORDER_DesigningCharge_textBox11.Text = "";
            ORDER_NumberOfItemstextBox9.Text = "";
            ORDER_TotalCost_textBox15.Text = "";
            ORDER_AdvancetextBox12.Text = "";
            ORDER_DuetextBox13.Text = "";
            Clear_OrderUI_Orders_TextBoxes();
            OrderDetailsdataGridView1.Rows.Clear();
            gridViewColumnAssign();
            Delivery_orderIDtextBox2.Text = "";
            Delivery_CustomerNametextBox1.Text = "";
            Delivery_Address_textBox4.Text = "";
            Delivery_ContactNotextBox3.Text = "";
            Delivery_IssueDate_dateTimePicker1.Text = "";
            Delivery_DeliveryDatedateTimePicker2.Text = "";
            Delivery_RateofProduct_textBox5.Text = "";
            Delivery_ProductPrice_textBox10.Text = "";
            Delivery_DesigningCharge_textBox11.Text = "";
            Delivery_Depo_Point_textBox1.Text = "";
            Delivery_Depo__Roti_textBox2.Text = "";
            Delivery_Depo__Ana_textBox3.Text = "";
            Delivery_Depo__Vori_textBox4.Text = "";
            Delivery_DepositedAmount_textBox8.Text = "";
            Delivery_TotalPoint_textBox4.Text = "";
            Delivery_TotalRoti_textBox3.Text = "";
            Delivery_TotalAna_textBox2.Text = "";
            Delivery_TotalVori_textBox1.Text = "";
            Delivery_Total_Weight_textBox7.Text = "";
            Delivery_NumberOfItemstextBox9.Text = "";
            DELIVERY_FinalWeight_Point_textBox7.Text = "";
            DELIVERY_FinalWeight_Roti_textBox6.Text = "";
            DELIVERY_FinalWeight__Ana_textBox5.Text = "";
            DELIVERY_FinalWeight_Vori_textBox4.Text = "";
            Delivery_FinalWeight_textBox3.Text = "";
            DELIVERY_PaindAmount_textBox3.Text = "";
            DEL_DIS_textBox3.Text = "";
            Delivery_TotalCost_textBox15.Text = "";
            Delivery_DuetextBox13.Text = "";
            Delivery_Payment___textBox3.Text = "";
            Delivery_OrderDetailsdataGridView1.Rows.Clear();
            CostHelper_label48.Text = "";
            Delivery_DuetextBox13.Text = "";
            PAYMENT_orderIDtextBox2textBox15.Text = "";
            PAYMENT_CustomerNametextBox17.Text = "";
            PAYMENT_Address_textBox12.Text = "";
            PAYMENT_ContactNotextBox13.Text = "";
            PAYMENT_T_Point_textBox20.Text = "";
            PAYMENT_T_Roti_Textbox22.Text = "";
            PAYMENT_T_Ana_textBox18.Text = "";
            PAYMENT_T_VoritextBox17.Text = "";
            PAYMENT_T_Total_textBox21.Text = "";
            PAYMENT_D_Point_textBox13.Text = "";
            PAYMENT_D_Roti_textBox12.Text = "";
            PAYMENT_D_Ana_textBox11.Text = "";
            PAYMENT_D_Vori_textBox10.Text = "";
            PAYMENT_D_Total_textBox15.Text = "";
            PAYMENT_F_Point_textBox8.Text = "";
            PAYMENT_F_Roti_textBox7.Text = "";
            PAYMENT_F_Ana_textBox4.Text = "";
            PAYMENT_F_Vori_ttextBox3.Text = "";
            PAYMENT_F_Total_textBox9.Text = "";
            payment_RateofProduct_textBox8.Text = "";
            PAYMENT_Delivery_ProductPrice_textBox7.Text = "";
            pAYMENT_DesigningCharge_textBox4.Text = "";
            PAYMENT_NOofItems_textBox3.Text = "";
            PAYMENT_TotalCost_textBox10.Text = "";
            PAYMENT_Paid_textBox9.Text = "";
            PAYMENT_Discount_textBox1.Text = "";
            PAYMENT_Payment_textBox12.Text = "";
            PAYMENT_DuetextBox11.Text = "";
            label117.Text = "";
            LastPayment_Helper_label118.Text = "";
            Payment_label84.Text = "";
            payment_CostHelper_label84.Text = "";
            Payment_AdvanceAmountlabel49label91.Text = "";
            PAYMENT_TotalCost_textBox10.Text = "";
            Due_label49.Text = "";
            AdvanceAmountlabel49.Text = "";
            SEARCH_CustomerID_textBox3.Text = "";
            CUSTOMER_Name_textBox4.Text = "";
            SEARCH_Address_textBox7.Text = "";
            SEARCH_ContactNo_textBox8.Text = "";
            issueDATE = "";
            deliveryDATE = "";
            DESIGN_DesignID_textBox4.Text = "";
            DESIGN_ItemType_comboBox1.Text = "";
            DESIGN_DesignCost_textBox3.Text = "";
            AdminPaswordChange_UserName_ADDMINtextBox4.Text = "";
            AdminPaswordChange_Password_textBox7.Text = "";
            AdminPaswordChange_confirmPassword_textBox3.Text = "";
            Order_Depo_Point_textBox1.Text = "";
            Order_Depo__Roti_textBox2.Text = "";
            Order_Depo__Ana_textBox3.Text = "";
            Order_Depo__Vori_textBox4.Text = "";
            TotalDepoWeight_textBox3.Text = "";
            PathLocationlabel133.Text = "";            
            PAYMENT_dataGridView1.Rows.Clear();

        }
        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SearchBYid_panel1.Visible = false;
            ORDER_Search_button14.Visible = false;
            ActionStataus__label16.Visible = false;
            Clear_OrderUI_ALL_TextBoxes();
            hOMEToolStripMenuItem.BackColor = Color.Gainsboro;
            hOMEToolStripMenuItem.ForeColor = Color.Black;
            MenuStripDesignOnClick(A);
            HOME_panel16.Visible = true;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            A = 1;

        }
        private void gridViewColumnAssign()
        {
            OrderDetailsdataGridView1.ColumnCount = 11;
            OrderDetailsdataGridView1.Columns[0].Width = 25;
            OrderDetailsdataGridView1.Columns[1].Width = 40;
            OrderDetailsdataGridView1.Columns[2].Width = 50;
            OrderDetailsdataGridView1.Columns[3].Width = 50;
            OrderDetailsdataGridView1.Columns[4].Width = 45;
            OrderDetailsdataGridView1.Columns[5].Width = 55;
            OrderDetailsdataGridView1.Columns[6].Width = 50;
            OrderDetailsdataGridView1.Columns[7].Width = 50;
            OrderDetailsdataGridView1.Columns[8].Width = 60;
            OrderDetailsdataGridView1.Columns[9].Width = 50;
            OrderDetailsdataGridView1.Columns[10].Width = 70;

            OrderDetailsdataGridView1.Columns[0].Name = "N0.";
            OrderDetailsdataGridView1.Columns[1].Name = "Item";
            OrderDetailsdataGridView1.Columns[2].Name = "P_Type";
            OrderDetailsdataGridView1.Columns[3].Name = "P_Unit";
            OrderDetailsdataGridView1.Columns[4].Name = "Vori";
            OrderDetailsdataGridView1.Columns[5].Name = "Ani";
            OrderDetailsdataGridView1.Columns[6].Name = "Roti";
            OrderDetailsdataGridView1.Columns[7].Name = "Point";
            OrderDetailsdataGridView1.Columns[8].Name = "Total(vori)";
            OrderDetailsdataGridView1.Columns[9].Name = "DID";
            OrderDetailsdataGridView1.Columns[10].Name = "DesignCost";
        }
        private void Delivery_gridViewColumnAssign()
        {
            Delivery_OrderDetailsdataGridView1.ColumnCount = 11;
            Delivery_OrderDetailsdataGridView1.Columns[0].Width = 25;
            Delivery_OrderDetailsdataGridView1.Columns[1].Width = 40;
            Delivery_OrderDetailsdataGridView1.Columns[2].Width = 50;
            Delivery_OrderDetailsdataGridView1.Columns[3].Width = 50;
            Delivery_OrderDetailsdataGridView1.Columns[4].Width = 45;
            Delivery_OrderDetailsdataGridView1.Columns[5].Width = 55;
            Delivery_OrderDetailsdataGridView1.Columns[6].Width = 50;
            Delivery_OrderDetailsdataGridView1.Columns[7].Width = 50;
            Delivery_OrderDetailsdataGridView1.Columns[8].Width = 60;
            Delivery_OrderDetailsdataGridView1.Columns[9].Width = 50;
            Delivery_OrderDetailsdataGridView1.Columns[10].Width = 70;

            Delivery_OrderDetailsdataGridView1.Columns[0].Name = "N0.";
            Delivery_OrderDetailsdataGridView1.Columns[1].Name = "Item";
            Delivery_OrderDetailsdataGridView1.Columns[2].Name = "P_Type";
            Delivery_OrderDetailsdataGridView1.Columns[3].Name = "P_Unit";
            Delivery_OrderDetailsdataGridView1.Columns[4].Name = "Vori";
            Delivery_OrderDetailsdataGridView1.Columns[5].Name = "Ani";
            Delivery_OrderDetailsdataGridView1.Columns[6].Name = "Roti";
            Delivery_OrderDetailsdataGridView1.Columns[7].Name = "Point";
            Delivery_OrderDetailsdataGridView1.Columns[8].Name = "Total(vori)";
            Delivery_OrderDetailsdataGridView1.Columns[9].Name = "DID";
            Delivery_OrderDetailsdataGridView1.Columns[10].Name = "DesignCost";
        }
        private void Payment_gridViewColumnAssign()
        {
            PAYMENT_dataGridView1.ColumnCount = 11;
            PAYMENT_dataGridView1.Columns[0].Width = 25;
            PAYMENT_dataGridView1.Columns[1].Width = 40;
            PAYMENT_dataGridView1.Columns[2].Width = 50;
            PAYMENT_dataGridView1.Columns[3].Width = 50;
            PAYMENT_dataGridView1.Columns[4].Width = 45;
            PAYMENT_dataGridView1.Columns[5].Width = 55;
            PAYMENT_dataGridView1.Columns[6].Width = 50;
            PAYMENT_dataGridView1.Columns[7].Width = 50;
            PAYMENT_dataGridView1.Columns[8].Width = 60;
            PAYMENT_dataGridView1.Columns[9].Width = 50;
            PAYMENT_dataGridView1.Columns[10].Width = 70;

            PAYMENT_dataGridView1.Columns[0].Name = "N0.";
            PAYMENT_dataGridView1.Columns[1].Name = "Item";
            PAYMENT_dataGridView1.Columns[2].Name = "P_Type";
            PAYMENT_dataGridView1.Columns[3].Name = "P_Unit";
            PAYMENT_dataGridView1.Columns[4].Name = "Vori";
            PAYMENT_dataGridView1.Columns[5].Name = "Ani";
            PAYMENT_dataGridView1.Columns[6].Name = "Roti";
            PAYMENT_dataGridView1.Columns[7].Name = "Point";
            PAYMENT_dataGridView1.Columns[8].Name = "Total(vori)";
            PAYMENT_dataGridView1.Columns[9].Name = "DID";
            PAYMENT_dataGridView1.Columns[10].Name = "DesignCost";
        }
        public void GetCustoomerMaxID()
        {
            OrderBLL aOrderBLL = new OrderBLL();
            int MAxID = aOrderBLL.GetMaxIDforCustomerBLL();
            if (MAxID < 0)
            {
                MessageBox.Show("eroor");

            }
            else
            {
                ORDER_orderIDtextBox2.Text = MAxID.ToString();
                TotalDepoWeight_textBox3.Text = 0.ToString();
            }
        }
        private void oRDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = true;
            ORDER_Search_button14.Visible = true;
            ActionStataus__label16.Visible = false;
            Clear_OrderUI_ALL_TextBoxes();
            oRDERToolStripMenuItem.BackColor = Color.Gainsboro;
            oRDERToolStripMenuItem.ForeColor = Color.Black;
            MenuStripDesignOnClick(A);
            HOME_panel16.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            OrderPanel_panel1.Visible = true;
            SEARCH_panel.Visible = false;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            gridViewColumnAssign();
            A = 2;
            GetCustoomerMaxID();

        }
        private void dELIVERYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = true;
            ORDER_Search_button14.Visible = true;
            ActionStataus__label16.Visible = false;
            dELIVERYToolStripMenuItem.BackColor = Color.Gainsboro;
            dELIVERYToolStripMenuItem.ForeColor = Color.Black;
            Clear_OrderUI_ALL_TextBoxes();
            MenuStripDesignOnClick(A);

            DELIVERY_panel2.Visible = true;
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            pAYMENT_panel10.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            SEARCH_panel.Visible = false;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            HOME_panel16.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            A = 3;
        }
        private void pAYMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = true;
            ORDER_Search_button14.Visible = true;
            ActionStataus__label16.Visible = false;
            pAYMENTToolStripMenuItem.BackColor = Color.Gainsboro;
            pAYMENTToolStripMenuItem.ForeColor = Color.Black;
            Clear_OrderUI_ALL_TextBoxes();
            MenuStripDesignOnClick(A);
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            SEARCH_panel.Visible = false;
            pAYMENT_panel10.Visible = true;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            HOME_panel16.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            A = 4;
        }
        private void dELIVERYSCHEDULEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = false;
            ORDER_Search_button14.Visible = false;
            ActionStataus__label16.Visible = false;
            dELIVERYSCHEDULEToolStripMenuItem.BackColor = Color.Gainsboro;
            dELIVERYSCHEDULEToolStripMenuItem.ForeColor = Color.Black;
            Clear_OrderUI_ALL_TextBoxes();
            MenuStripDesignOnClick(A);
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            SEARCH_panel.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = true;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            HOME_panel16.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            A = 5;
        }
        private void sEARCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = false;
            ORDER_Search_button14.Visible = false;
            ActionStataus__label16.Visible = false;
            sEARCHToolStripMenuItem.BackColor = Color.Gainsboro;
            sEARCHToolStripMenuItem.ForeColor = Color.Black;
            Clear_OrderUI_ALL_TextBoxes();
            MenuStripDesignOnClick(A);
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            SEARCH_panel.Visible = true;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            HOME_panel16.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            A = 6;
        }
        private void dESIGNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = false;
            ORDER_Search_button14.Visible = false;
            ActionStataus__label16.Visible = false;
        }
        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBYid_panel1.Visible = false;
            ORDER_Search_button14.Visible = false;
            ActionStataus__label16.Visible = false;
            A = 8;
        }
        int i = 1;
        public void AddDataIn_OrderListDataGridview(string Item, string Product, string P_Unit, string Vori,string Ana,string Roti,string Point,string Total, string Design_ID, string Design_Cost)
        {
            string[] bindDataForEachItem = { i.ToString(), Item, Product, P_Unit,Vori,Ana,Roti,Point,Total, Design_ID, Design_Cost};
            OrderDetailsdataGridView1.Rows.Add(bindDataForEachItem);
            i++;

        }
        public void DELIVERY_AddDataIn_OrderListDataGridview(string Item, string Product, string P_Unit, string Vori, string Ana, string Roti, string Point, string Total, string Design_ID, string Design_Cost)
        {
            string[] bindDataForEachItem = { i.ToString(), Item, Product, P_Unit, Vori, Ana, Roti, Point, Total, Design_ID, Design_Cost };
            Delivery_OrderDetailsdataGridView1.Rows.Add(bindDataForEachItem);
            i++;

        }
        public void PAYMENT_AddDataIn_OrderListDataGridview(string Item, string Product, string P_Unit, string Vori, string Ana, string Roti, string Point, string Total, string Design_ID, string Design_Cost)
        {
            string[] bindDataForEachItem = { i.ToString(), Item, Product, P_Unit, Vori, Ana, Roti, Point, Total, Design_ID, Design_Cost };
            PAYMENT_dataGridView1.Rows.Add(bindDataForEachItem);
            i++;

        }
        public void CountNumberOfRowsIn_OrderDetailsdataGridView1()
        {
            int RowCount = OrderDetailsdataGridView1.Rows.Count;
            ORDER_NumberOfItemstextBox9.Text = RowCount.ToString();
            
        }
        private void OrderDetailsbutton1_Click(object sender, EventArgs e)
        {
            float Vori = (float)0.0;
            float Ani = (float)0.0;
            float Roti = (float)0.0;
            float Points = (float)0.0;
            float.TryParse(OrderProdutWeight_Vori__textBox1.Text, out Vori);
            float.TryParse(OrderProdutWeight_Ani_textBox1.Text,out Ani);
            float.TryParse(OrderProdutWeight_Roti_textBox2.Text,out Roti);
            float.TryParse(OrderProdutWeight_Point_textBox3.Text,out Points);
            string Punit = CheckProductUnitType();
            AddDataIn_OrderListDataGridview(ORDER_ItemTtypecomboBox1.Text, ORDER_ProductType_comboBox1.Text, Punit, Vori.ToString(),Ani.ToString(),Roti.ToString(),Points.ToString(), OrderPanel_OrdersInVori_textBox1.Text, ORDER_DesignIDtextBox6.Text, OrderSpecificDesignCosttextBox1.Text);

            CountNumberOfRowsIn_OrderDetailsdataGridView1();
            ORDER_21K_radioButton2.Checked = false;
            ORDER_21kHOL_radioButton4.Checked = false;
            ORDER_22K_radioButton3.Checked = false;
            ORDER_ProductType_comboBox1.Text = "";
            ORDER_ItemTtypecomboBox1.Text = "";
            ORDER_DesignIDtextBox6.Text = "";
            OrderSpecificDesignCosttextBox1.Text = "";
            OrderPanel_OrdersInVori_textBox1.Text = "";
            OrderProdutWeight_Point_textBox3.Text = "";
            OrderProdutWeight_Roti_textBox2.Text = "";
            OrderProdutWeight_Ani_textBox1.Text = "";
            OrderProdutWeight_Vori__textBox1.Text = "";
            OrderSpecificDesignCosttextBox1.Text = "";
            OrderPanel_OrdersInVori_textBox1.Text = "";

        }
        private void CancelOrderFromOrderListbutton1_Click(object sender, EventArgs e)
        {

            try
            {
                int rowIndex = OrderDetailsdataGridView1.CurrentCell.RowIndex;
                OrderDetailsdataGridView1.Rows.RemoveAt(rowIndex);
                i = 1;
            }
            catch
            {

            }
            CountNumberOfRowsIn_OrderDetailsdataGridView1();
            ORDER_21K_radioButton2.Checked = false;
            ORDER_21kHOL_radioButton4.Checked = false;
            ORDER_22K_radioButton3.Checked = false;
            ORDER_ProductType_comboBox1.Text = "";
            ORDER_ItemTtypecomboBox1.Text = "";
            ORDER_DesignIDtextBox6.Text = "";
            OrderSpecificDesignCosttextBox1.Text = "";
            OrderPanel_OrdersInVori_textBox1.Text = "";
            OrderProdutWeight_Point_textBox3.Text = "";
            OrderProdutWeight_Roti_textBox2.Text = "";
            OrderProdutWeight_Ani_textBox1.Text = "";
            OrderProdutWeight_Vori__textBox1.Text = "";
            OrderSpecificDesignCosttextBox1.Text = "";
            OrderPanel_OrdersInVori_textBox1.Text = "";

        }
        private void ORDER_DesignIDtextBox6_TextChanged(object sender, EventArgs e)
        {
            Design aDesign = new Design();
            try
            {

                aDesign.DID = 0;
                int.TryParse(ORDER_DesignIDtextBox6.Text, out aDesign.DID);
                OrderBLL aOrderBLL = new OrderBLL();
                DataTable dt = aOrderBLL.GetDesigningCharge_BLL(aDesign);
                if (dt != null)
                {
                    OrderSpecificDesignCosttextBox1.Text = dt.Rows[0][0].ToString();
                }
                else
                {

                    OrderSpecificDesignCosttextBox1.Text = "";
                }
            }
            catch
            {

                MessageBox.Show("Please Select Correct  Design");
                OrderSpecificDesignCosttextBox1.Text = "";
            }
        }
        private void OrderCancel_button5_Click(object sender, EventArgs e)
        {
            int TotalNumberOfOrder = int.Parse(ORDER_NumberOfItemstextBox9.Text);
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(ORDER_orderIDtextBox2.Text, out aCustomer.ID);
            aCustomer.name = ORDER_CustomerNametextBox1.Text;
            aCustomer.Address = ORDER_Address_textBox4.Text;
            aCustomer.ContactNo = ORDER_ContactNotextBox3.Text;


            OrderDetails aOrderDetails = new OrderDetails();
            aOrderDetails.CID = 0;
            int.TryParse(ORDER_orderIDtextBox2.Text, out aOrderDetails.CID);
            aOrderDetails.IssueDate = ORDER_IssueDate_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            aOrderDetails.DeliveryDate = ORDER_DeliveryDatedateTimePicker2.Value.ToString("yyyy-MM-dd");
            aOrderDetails.RateOfProduct = 0;
            float.TryParse(ORDER_RateofProduct_textBox5.Text, out aOrderDetails.RateOfProduct);
            aOrderDetails.DepositedProductAmount = 0;
            float.TryParse(TotalDepoWeight_textBox3.Text, out aOrderDetails.DepositedProductAmount);
            aOrderDetails.TotalWeight = 0;
            float.TryParse(ORDER_Total_Weight_textBox7.Text, out aOrderDetails.TotalWeight);

            Payment aPayment = new Payment();
            aPayment.CID = 0;
            int.TryParse(ORDER_orderIDtextBox2.Text, out aPayment.CID);
            aPayment.ProductCharge = 0;
            float.TryParse(ORDER_ProductPrice_textBox10.Text, out aPayment.ProductCharge);
            aPayment.DesigningCharge = 0;
            float.TryParse(ORDER_DesigningCharge_textBox11.Text, out aPayment.DesigningCharge);
            aPayment.TotalBill = 0;
            float.TryParse(ORDER_TotalCost_textBox15.Text, out aPayment.TotalBill);
            aPayment.Advance = 0;
            float.TryParse(ORDER_AdvancetextBox12.Text, out aPayment.Advance);
            aPayment.LastPayment = 0;
            float.TryParse(ORDER_AdvancetextBox12.Text, out aPayment.LastPayment);
            aPayment.Due = 0;
            float.TryParse(ORDER_DuetextBox13.Text, out aPayment.Due);
            aPayment.PaymentStatus = PaymentStatusDetect(ORDER_DuetextBox13.Text);


            OrderBLL aOrderBLL = new OrderBLL();
            bool res = aOrderBLL.CancelOrderBLL(aCustomer, aOrderDetails, aPayment, arr, OrderDetailsdataGridView1.Rows.Count);
            if (res)
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Order Information Cancelled Successfully";
                Clear_OrderUI_ALL_TextBoxes();
            }
            else
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Please Check Order ID";
            }



        }
        private void ORDER_RateofProduct_textBox5_TextChanged(object sender, EventArgs e)
        {
            if (ORDER_RateofProduct_textBox5.Text != "")
            {
                float RateofProduct = 0;
                float.TryParse(ORDER_RateofProduct_textBox5.Text, out RateofProduct);
                float Weight = 0;
                float.TryParse(ORDER_Total_Weight_textBox7.Text, out Weight);
                float ProductPrice = RateofProduct * Weight;
                ORDER_ProductPrice_textBox10.Text = ProductPrice.ToString();
            }
            else
            {
                ORDER_RateofProduct_textBox5.Text = "";
            }
        }
        string[,] arr = new string[10, 10];
        private void Confirm_OrderList_button1_Click(object sender, EventArgs e)
        {
            float TotalWeight = 0;
            float TotalDesigningCharge = 0;
            float TotalPoint = 0;
            float TotalRoti = 0;
            float TotalAna = 0;
            float TotalVori = 0;
            if (int.Parse(ORDER_NumberOfItemstextBox9.Text)==0)
            {
                ORDER_TotalCost_textBox15.Text =0.ToString();
                ORDER_DuetextBox13.Text = 0.ToString();
                ORDER_Total_Weight_textBox7.Text = 0.ToString();
                TotalDepoWeight_textBox3.Text = 0.ToString();
                ORDER_ProductPrice_textBox10.Text = 0.ToString();
                ORDER_DesigningCharge_textBox11.Text = 0.ToString();
                ORDER_AdvancetextBox12.Text = 0.ToString();
            }
            else
            {
                for (i = 0; i < int.Parse(ORDER_NumberOfItemstextBox9.Text); i++)
                {
                    arr[i, 0] = OrderDetailsdataGridView1.Rows[i].Cells[1].Value.ToString();
                    arr[i, 1] = OrderDetailsdataGridView1.Rows[i].Cells[2].Value.ToString();
                    arr[i, 2] = OrderDetailsdataGridView1.Rows[i].Cells[3].Value.ToString();
                    arr[i, 3] = OrderDetailsdataGridView1.Rows[i].Cells[4].Value.ToString();
                    arr[i, 4] = OrderDetailsdataGridView1.Rows[i].Cells[5].Value.ToString();
                    arr[i, 5] = OrderDetailsdataGridView1.Rows[i].Cells[6].Value.ToString();
                    arr[i, 6] = OrderDetailsdataGridView1.Rows[i].Cells[7].Value.ToString();
                    arr[i, 7] = OrderDetailsdataGridView1.Rows[i].Cells[8].Value.ToString();
                    arr[i, 8] = OrderDetailsdataGridView1.Rows[i].Cells[9].Value.ToString();
                    arr[i, 9] = OrderDetailsdataGridView1.Rows[i].Cells[10].Value.ToString();
                    



                    TotalPoint = TotalPoint + float.Parse(arr[i, 6]);
                    TotalRoti=TotalRoti+ float.Parse(arr[i, 5]);
                    TotalAna=TotalAna+ float.Parse(arr[i, 4]);
                    TotalVori=TotalVori+ float.Parse(arr[i, 3]);
                    TotalWeight = TotalWeight + float.Parse(arr[i, 7]);
                    TotalDesigningCharge = TotalDesigningCharge + float.Parse(arr[i, 9]);
                } 
                ORDER_DesigningCharge_textBox11.Text = TotalDesigningCharge.ToString();

                try
                {
                    if (ORDER_TotalCost_textBox15.Text != "" && ORDER_AdvancetextBox12.Text != "")
                    {
                        float TotalCost = float.Parse(ORDER_TotalCost_textBox15.Text);
                        float Advance = float.Parse(ORDER_AdvancetextBox12.Text);
                        float Due = TotalCost - Advance;
                        ORDER_DuetextBox13.Text = Due.ToString();
                    }
                    else
                    {
                        ORDER_DuetextBox13.Text = "";
                    }
                }
                catch
                {

                }
                float[] a = ORDER_weightandDepoAmount_Calculate(TotalPoint.ToString(),TotalRoti.ToString(),TotalAna.ToString(),TotalVori.ToString());
                
                TotalPoint_textBox4.Text = a[0].ToString();
                TotalRoti_textBox3.Text = a[1].ToString();
                TotalAna_textBox2.Text = a[2].ToString();
                TotalVori_textBox1.Text = a[3].ToString();
                ORDER_Total_Weight_textBox7.Text = a[4].ToString();


            }
        }       
        private void ORDER_DepositedAmount_textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void ORDER_ProductPrice_textBox10_TextChanged(object sender, EventArgs e)
        {
            if (ORDER_Total_Weight_textBox7.Text != "" && TotalDepoWeight_textBox3.Text != "" && ORDER_ProductPrice_textBox10.Text != "" && ORDER_DesigningCharge_textBox11.Text != "")
            {
                try
                {
                    float RateofProduct = float.Parse(ORDER_RateofProduct_textBox5.Text);
                    float Weight = float.Parse(ORDER_Total_Weight_textBox7.Text);
                    float ProductPrice = RateofProduct * Weight;
                    float SubmittedAmount = float.Parse(TotalDepoWeight_textBox3.Text) * RateofProduct;
                    ProductPrice = ProductPrice - SubmittedAmount;

                    float DesigningAMount = float.Parse(ORDER_DesigningCharge_textBox11.Text);
                    ProductPrice = ProductPrice + DesigningAMount;
                    ORDER_TotalCost_textBox15.Text = ProductPrice.ToString();
                    ORDER_DuetextBox13.Text = ProductPrice.ToString();
                }
                catch
                {

                }

            }
            else
            {
                ORDER_TotalCost_textBox15.Text = "";
                ORDER_DuetextBox13.Text = "";
            }
        }
        private void ORDER_Total_Weight_textBox7_TextChanged(object sender, EventArgs e)
        {

            float RateofProduct = 0;
            float.TryParse(ORDER_RateofProduct_textBox5.Text, out RateofProduct);
            float Weight = 0;
            float.TryParse(ORDER_Total_Weight_textBox7.Text, out Weight);
            float ProductPrice = RateofProduct * Weight;
            ORDER_ProductPrice_textBox10.Text = ProductPrice.ToString();

            if (ORDER_Total_Weight_textBox7.Text != "" && TotalDepoWeight_textBox3.Text != "")
            {
                float RateofProduct1 = 0;
                float.TryParse(ORDER_RateofProduct_textBox5.Text, out RateofProduct1);
                float Weight1 = float.Parse(ORDER_Total_Weight_textBox7.Text);
                float ProductPrice1 = RateofProduct * Weight;
                float SubmittedAmount1 = 0;
                float.TryParse(TotalDepoWeight_textBox3.Text, out SubmittedAmount1);
                SubmittedAmount1 = SubmittedAmount1 * RateofProduct1;
                ProductPrice1 = ProductPrice1 - SubmittedAmount1;
                ORDER_ProductPrice_textBox10.Text = ProductPrice1.ToString();
            }
            else
            {
                ORDER_ProductPrice_textBox10.Text = "";
            }


        }
        private void ORDER_DesigningCharge_textBox11_TextChanged(object sender, EventArgs e)
        {
            if (ORDER_Total_Weight_textBox7.Text != "" && TotalDepoWeight_textBox3.Text != "" && ORDER_ProductPrice_textBox10.Text != "" && ORDER_DesigningCharge_textBox11.Text != "")
            {
                try
                {
                    float RateofProduct = float.Parse(ORDER_RateofProduct_textBox5.Text);
                    float Weight = float.Parse(ORDER_Total_Weight_textBox7.Text);
                    float ProductPrice = RateofProduct * Weight;
                    float SubmittedAmount = float.Parse(TotalDepoWeight_textBox3.Text) * RateofProduct;
                    ProductPrice = ProductPrice - SubmittedAmount;

                    float DesigningAMount = float.Parse(ORDER_DesigningCharge_textBox11.Text);
                    ProductPrice = ProductPrice + DesigningAMount;
                    ORDER_TotalCost_textBox15.Text = ProductPrice.ToString();
                    ORDER_DuetextBox13.Text = ProductPrice.ToString();
                }
                catch
                {

                }

            }
            else
            {
                ORDER_TotalCost_textBox15.Text = "";
                ORDER_DuetextBox13.Text = "";
            }
        }
        private void ORDER_AdvancetextBox12_TextChanged(object sender, EventArgs e)
        {
            if (ORDER_TotalCost_textBox15.Text != "" && ORDER_AdvancetextBox12.Text != "")
            {
                try
                {
                    float TotalCost = float.Parse(ORDER_TotalCost_textBox15.Text);
                    float Advance = float.Parse(ORDER_AdvancetextBox12.Text);
                    float Due = TotalCost - Advance;
                    ORDER_DuetextBox13.Text = Due.ToString();
                }
                catch
                {

                }
            }
            else
            {
                ORDER_DuetextBox13.Text = ORDER_TotalCost_textBox15.Text;
            }
        }
        private void ORDER_TotalCost_textBox15_TextChanged(object sender, EventArgs e)
        {
            if (ORDER_TotalCost_textBox15.Text != "" && ORDER_AdvancetextBox12.Text != "")
            {
                float TotalCost = float.Parse(ORDER_TotalCost_textBox15.Text);
                float Advance = float.Parse(ORDER_AdvancetextBox12.Text);
                float Due = TotalCost - Advance;
                ORDER_DuetextBox13.Text = Due.ToString();
            }
            else
            {
                ORDER_DuetextBox13.Text = "";
            }
        }       
        private void unitType_comboBox1_SelectedIndexChanged(object sender, EventArgs e)


        {
            

        }
        public string PaymentStatusDetect(string Due)
        {
            string PaymentStatus = "" ;
            if (float.Parse(Due) == 0)
            {
                PaymentStatus = " Clear ";
            }
            else if (float.Parse(Due) > 0 ) 
            {
                PaymentStatus = "Due " + Due + "";
            }
            else
            {
                PaymentStatus = "Refundable " + Due + "";
            }
            return PaymentStatus;

        }
        private void OrderConfirm_button3_Click(object sender, EventArgs e)
        {
            int TotalNumberOfOrder = int.Parse(ORDER_NumberOfItemstextBox9.Text);
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(ORDER_orderIDtextBox2.Text,out aCustomer.ID);
            aCustomer.name = ORDER_CustomerNametextBox1.Text;
            aCustomer.Address = ORDER_Address_textBox4.Text;
            aCustomer.ContactNo = ORDER_ContactNotextBox3.Text;

            try {
                FileStream stream = new FileStream(PathLocationlabel133.Text, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                aCustomer.images = brs.ReadBytes((int)stream.Length);
                OrderDetails aOrderDetails = new OrderDetails();
                aOrderDetails.CID = 0;
                int.TryParse(ORDER_orderIDtextBox2.Text, out aOrderDetails.CID);
                aOrderDetails.IssueDate = ORDER_IssueDate_dateTimePicker1.Value.ToString("yyyy-MM-dd");
                aOrderDetails.DeliveryDate = ORDER_DeliveryDatedateTimePicker2.Value.ToString("yyyy-MM-dd");
                aOrderDetails.RateOfProduct = 0;
                float.TryParse(ORDER_RateofProduct_textBox5.Text, out aOrderDetails.RateOfProduct);



                aOrderDetails.TotalWeight = 0;
                float.TryParse(ORDER_Total_Weight_textBox7.Text, out aOrderDetails.TotalWeight);
                aOrderDetails.OrderStatus = "Ordered";
                aOrderDetails.Total_Vori = 0;
                float.TryParse(TotalVori_textBox1.Text, out aOrderDetails.Total_Vori);
                aOrderDetails.Total_Ana = 0;
                float.TryParse(TotalAna_textBox2.Text, out aOrderDetails.Total_Ana);
                aOrderDetails.Total_Roti = 0;
                float.TryParse(TotalRoti_textBox3.Text, out aOrderDetails.Total_Roti);
                aOrderDetails.Total_Point = 0;
                float.TryParse(TotalPoint_textBox4.Text, out aOrderDetails.Total_Point);
                aOrderDetails.TotalWeight = 0;
                float.TryParse(ORDER_Total_Weight_textBox7.Text, out aOrderDetails.TotalWeight);

                aOrderDetails.Depo_Vori = 0;
                float.TryParse(Order_Depo__Vori_textBox4.Text, out aOrderDetails.Depo_Vori);
                aOrderDetails.Depo_Ana = 0;
                float.TryParse(Order_Depo__Ana_textBox3.Text, out aOrderDetails.Depo_Ana);
                aOrderDetails.Depo_Roti = 0;
                float.TryParse(Order_Depo__Roti_textBox2.Text, out aOrderDetails.Depo_Roti);
                aOrderDetails.Depo_Point = 0;
                float.TryParse(Order_Depo_Point_textBox1.Text, out aOrderDetails.Depo_Point);
                aOrderDetails.DepositedProductAmount = 0;
                float.TryParse(TotalDepoWeight_textBox3.Text, out aOrderDetails.DepositedProductAmount);



                Payment aPayment = new Payment();
                aPayment.CID = 0;
                int.TryParse(ORDER_orderIDtextBox2.Text, out aPayment.CID);
                aPayment.ProductCharge = 0;
                float.TryParse(ORDER_ProductPrice_textBox10.Text, out aPayment.ProductCharge);
                aPayment.DesigningCharge = 0;
                float.TryParse(ORDER_DesigningCharge_textBox11.Text, out aPayment.DesigningCharge);
                aPayment.TotalBill = 0;
                float.TryParse(ORDER_TotalCost_textBox15.Text, out aPayment.TotalBill);
                aPayment.Advance = 0;
                float.TryParse(ORDER_AdvancetextBox12.Text, out aPayment.Advance);
                aPayment.LastPayment = 0;
                float.TryParse(ORDER_AdvancetextBox12.Text, out aPayment.LastPayment);
                aPayment.Due = 0;
                float.TryParse(ORDER_DuetextBox13.Text, out aPayment.Due);
                aPayment.PaymentStatus = PaymentStatusDetect(ORDER_DuetextBox13.Text);


                OrderBLL aOrderBLL = new OrderBLL();
                bool res = aOrderBLL.SaveOrderUIInformationBLL(aCustomer, aOrderDetails, aPayment, arr, OrderDetailsdataGridView1.Rows.Count);
                if (res)
                {
                    ActionStataus__label16.Visible = true;
                    ActionStataus__label16.Text = "Order Information Saved Successfully";
                    if (MessageBox.Show("Get Billing Slip? ", "Cash Memo", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    {
                        ReportUI aReportUI = new ReportUI(A, aCustomer.ID, aPayment.Due);
                        aReportUI.Show();
                    }
                    Clear_OrderUI_ALL_TextBoxes();
                }
                else
                {
                    ActionStataus__label16.Visible = true;
                    ActionStataus__label16.Text = "Please Check Order Information";
                }


            }
            catch
            {
                MessageBox.Show("Please Input Customer Image");
                
            }


            
        }
        private void GridviewValuAddToUpdate(DataTable dTables)
        {
            int RowCount = dTables.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                AddDataIn_OrderListDataGridview(dTables.Rows[i][5].ToString(), dTables.Rows[i][3].ToString(), dTables.Rows[i][4].ToString(), dTables.Rows[i][6].ToString(), dTables.Rows[i][7].ToString(), dTables.Rows[i][8].ToString(), dTables.Rows[i][9].ToString(), dTables.Rows[i][10].ToString(), dTables.Rows[i][2].ToString(), dTables.Rows[i][11].ToString());
                ORDER_NumberOfItemstextBox9.Text = dTables.Rows.Count.ToString();
            }
        }
        private void Delivery_GridviewValuAddToUpdate(DataTable dTables)
        {
            int RowCount = dTables.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                DELIVERY_AddDataIn_OrderListDataGridview(dTables.Rows[i][5].ToString(), dTables.Rows[i][3].ToString(), dTables.Rows[i][4].ToString(), dTables.Rows[i][6].ToString(), dTables.Rows[i][7].ToString(), dTables.Rows[i][8].ToString(), dTables.Rows[i][9].ToString(), dTables.Rows[i][10].ToString(), dTables.Rows[i][2].ToString(), dTables.Rows[i][11].ToString());
                Delivery_NumberOfItemstextBox9.Text = dTables.Rows.Count.ToString();
            }
        }
        private void PAYMENT_GridviewValuAddToUpdate(DataTable dTables)
        {
            int RowCount = dTables.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                PAYMENT_AddDataIn_OrderListDataGridview(dTables.Rows[i][5].ToString(), dTables.Rows[i][3].ToString(), dTables.Rows[i][4].ToString(), dTables.Rows[i][6].ToString(), dTables.Rows[i][7].ToString(), dTables.Rows[i][8].ToString(), dTables.Rows[i][9].ToString(), dTables.Rows[i][10].ToString(), dTables.Rows[i][2].ToString(), dTables.Rows[i][11].ToString());
                PAYMENT_NOofItems_textBox3.Text = dTables.Rows.Count.ToString();
            }
        }
        public void getInformationInOrderUItoUpdate(DataTable dTables)
        {
            try
            {
                ORDER_orderIDtextBox2.Text = dTables.Rows[0][0].ToString();
                ORDER_Address_textBox4.Text = dTables.Rows[0][3].ToString();
                ORDER_CustomerNametextBox1.Text = dTables.Rows[0][1].ToString();
                ORDER_ContactNotextBox3.Text = dTables.Rows[0][2].ToString();
                try
                {
                    byte[] images = (byte[])dTables.Rows[0][4];
                    MemoryStream mStream = new MemoryStream(images);
                    ORDER_Customer_pictureBox3.Image = Image.FromStream(mStream);
                }
                catch
                {

                }
                

                ORDER_IssueDate_dateTimePicker1.Text = dTables.Rows[0][6].ToString();
                ORDER_DeliveryDatedateTimePicker2.Text = dTables.Rows[0][7].ToString();

                ORDER_RateofProduct_textBox5.Text = dTables.Rows[0][8].ToString();

                Order_Depo__Vori_textBox4.Text = dTables.Rows[0][9].ToString();
                Order_Depo__Ana_textBox3.Text = dTables.Rows[0][10].ToString();
                Order_Depo__Roti_textBox2.Text = dTables.Rows[0][11].ToString();
                Order_Depo_Point_textBox1.Text = dTables.Rows[0][12].ToString();
                TotalDepoWeight_textBox3.Text = dTables.Rows[0][13].ToString();
                TotalVori_textBox1.Text = dTables.Rows[0][14].ToString();
                TotalAna_textBox2.Text = dTables.Rows[0][15].ToString();
                TotalRoti_textBox3.Text = dTables.Rows[0][16].ToString();
                TotalPoint_textBox4.Text = dTables.Rows[0][17].ToString();
                ORDER_Total_Weight_textBox7.Text = dTables.Rows[0][18].ToString();

                ORDER_ProductPrice_textBox10.Text = dTables.Rows[0][27].ToString();
                ORDER_DesigningCharge_textBox11.Text = dTables.Rows[0][28].ToString();
                ORDER_TotalCost_textBox15.Text = dTables.Rows[0][29].ToString();
                ORDER_AdvancetextBox12.Text = dTables.Rows[0][30].ToString();
                ORDER_DuetextBox13.Text = dTables.Rows[0][31].ToString();
            }
            catch
            {
                MessageBox.Show("Invalid Search ID");
            }
            
            
        }
        public void getInformationIn_DELIVERY_UItoUpdate(DataTable dTables)
        {
            Delivery_orderIDtextBox2.Text = dTables.Rows[0][0].ToString();
            Delivery_Address_textBox4.Text = dTables.Rows[0][3].ToString();
            Delivery_CustomerNametextBox1.Text = dTables.Rows[0][1].ToString();
            Delivery_ContactNotextBox3.Text = dTables.Rows[0][2].ToString();
            try
            {
                byte[] images = (byte[])dTables.Rows[0][4];
                MemoryStream mStream = new MemoryStream(images);
                DELIVERY_pictureBox4.Image = Image.FromStream(mStream);
            }
            catch
            {

            }
            Delivery_IssueDate_dateTimePicker1.Text = dTables.Rows[0][6].ToString();
            Delivery_DeliveryDatedateTimePicker2.Text = dTables.Rows[0][7].ToString();
            Delivery_RateofProduct_textBox5.Text = dTables.Rows[0][8].ToString();

            Delivery_Depo__Vori_textBox4.Text = dTables.Rows[0][9].ToString();
            Delivery_Depo__Ana_textBox3.Text = dTables.Rows[0][10].ToString();
            Delivery_Depo__Roti_textBox2.Text = dTables.Rows[0][11].ToString();
            Delivery_Depo_Point_textBox1.Text = dTables.Rows[0][12].ToString();
            Delivery_DepositedAmount_textBox8.Text = dTables.Rows[0][13].ToString();
            Delivery_TotalVori_textBox1.Text = dTables.Rows[0][14].ToString();
            Delivery_TotalAna_textBox2.Text = dTables.Rows[0][15].ToString();
            Delivery_TotalRoti_textBox3.Text = dTables.Rows[0][16].ToString();
            Delivery_TotalPoint_textBox4.Text = dTables.Rows[0][17].ToString();
            Delivery_Total_Weight_textBox7.Text = dTables.Rows[0][18].ToString();
            try
            {
                DELIVERY_FinalWeight_Vori_textBox4.Text = dTables.Rows[0][19].ToString();
                DELIVERY_FinalWeight__Ana_textBox5.Text = dTables.Rows[0][20].ToString();
                DELIVERY_FinalWeight_Roti_textBox6.Text = dTables.Rows[0][21].ToString();
                DELIVERY_FinalWeight_Point_textBox7.Text = dTables.Rows[0][21].ToString();
                Delivery_FinalWeight_textBox3.Text = dTables.Rows[0][23].ToString();
                DEL_DIS_textBox3.Text = dTables.Rows[0][32].ToString();
                DELIVERY_Discount_label144.Text = dTables.Rows[0][32].ToString();

            }
            catch
            {

            }
            AdvanceAmountlabel49.Text= dTables.Rows[0][30].ToString();
            Delivery_ProductPrice_textBox10.Text = dTables.Rows[0][27].ToString();
            Delivery_DesigningCharge_textBox11.Text = dTables.Rows[0][28].ToString();
            Delivery_TotalCost_textBox15.Text = dTables.Rows[0][29].ToString();
            CostHelper_label48.Text = dTables.Rows[0][29].ToString();
            Delivery_DuetextBox13.Text = dTables.Rows[0][31].ToString();
            Delivery_NumberOfItemstextBox9.Text = (Delivery_OrderDetailsdataGridView1.Rows.Count-1).ToString();
            Payment_label27.Text = dTables.Rows[0][34].ToString();
            Due_label49.Text = dTables.Rows[0][31].ToString();
            label117.Text = dTables.Rows[0][32].ToString();

            DELIVERY_PaindAmount_textBox3.Text = (float.Parse(dTables.Rows[0][29].ToString()) - float.Parse(dTables.Rows[0][31].ToString())).ToString();
            

        }
        public void getInformationIn_pAYMENT_UItoUpdate(DataTable dTables)
        {
            PAYMENT_orderIDtextBox2textBox15.Text = dTables.Rows[0][0].ToString();
            PAYMENT_Address_textBox12.Text = dTables.Rows[0][3].ToString();
            PAYMENT_CustomerNametextBox17.Text = dTables.Rows[0][1].ToString();
            PAYMENT_ContactNotextBox13.Text = dTables.Rows[0][2].ToString();
            try
            {
                byte[] images = (byte[])dTables.Rows[0][4];
                MemoryStream mStream = new MemoryStream(images);
               PAYMENT_pictureBox5.Image = Image.FromStream(mStream);
            }
            catch
            {

            }
            PAYMENT_IssueDate_dateTimePicker2.Text = dTables.Rows[0][6].ToString();
            PAYMENT_Delivery_dateTimePicker1.Text = dTables.Rows[0][7].ToString();
            payment_RateofProduct_textBox8.Text = dTables.Rows[0][8].ToString();
            PAYMENT_D_Vori_textBox10.Text=dTables.Rows[0][9].ToString();
            PAYMENT_D_Ana_textBox11.Text =dTables.Rows[0][10].ToString();
            PAYMENT_D_Roti_textBox12.Text =dTables.Rows[0][11].ToString();
            PAYMENT_D_Point_textBox13.Text =dTables.Rows[0][12].ToString();
            PAYMENT_D_Total_textBox15.Text =dTables.Rows[0][13].ToString();

            PAYMENT_T_VoritextBox17.Text =dTables.Rows[0][14].ToString();
            PAYMENT_T_Ana_textBox18.Text =dTables.Rows[0][15].ToString();
            PAYMENT_T_Roti_Textbox22.Text =dTables.Rows[0][16].ToString();
            PAYMENT_T_Point_textBox20.Text =dTables.Rows[0][17].ToString();
            PAYMENT_T_Total_textBox21.Text =dTables.Rows[0][18].ToString();
            try
            {
                PAYMENT_F_Vori_ttextBox3.Text =dTables.Rows[0][19].ToString();
                PAYMENT_F_Ana_textBox4.Text=dTables.Rows[0][20].ToString();
                PAYMENT_F_Roti_textBox7.Text = dTables.Rows[0][21].ToString();
                PAYMENT_F_Point_textBox8.Text =dTables.Rows[0][22].ToString();
                PAYMENT_F_Total_textBox9.Text =dTables.Rows[0][23].ToString();
                PAYMENT_Discount_textBox1.Text = dTables.Rows[0][32].ToString();
                

            }
            catch
            {

            }
            Payment_AdvanceAmountlabel49label91.Text = dTables.Rows[0][30].ToString();
            PAYMENT_Delivery_ProductPrice_textBox7.Text = dTables.Rows[0][27].ToString();
            pAYMENT_DesigningCharge_textBox4.Text = dTables.Rows[0][28].ToString();
            PAYMENT_TotalCost_textBox10.Text = dTables.Rows[0][29].ToString();
            payment_CostHelper_label84.Text = dTables.Rows[0][29].ToString();
            PAYMENT_DuetextBox11.Text = dTables.Rows[0][31].ToString();
            PAYMENT_NOofItems_textBox3.Text = (PAYMENT_dataGridView1.Rows.Count - 1).ToString();
            Payment_label84.Text = dTables.Rows[0][31].ToString();
            Due_label90.Text = dTables.Rows[0][24].ToString();
            label117.Text = dTables.Rows[0][32].ToString();
            LastPayment_Helper_label118.Text = dTables.Rows[0][32].ToString();
            PAYMENT_Paid_textBox9.Text = (float.Parse(dTables.Rows[0][29].ToString()) - float.Parse(dTables.Rows[0][31].ToString())).ToString();


        }
        public void LoadInformationInORDER_UI_textboxes()
        {
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(SearchByIDtextBox1.Text, out aCustomer.ID);
            OrderBLL aOrderBLL = new OrderBLL();
            DataTable[] dTables = aOrderBLL.SearchOrderInformationTo_UpdateBLL(aCustomer);
            if (dTables[0] == null)
            {
                MessageBox.Show("Please Your Search ID !");
            }
            else
            {
                gridViewColumnAssign();
                if(dTables[1].Rows.Count != 0 && dTables[0].Rows.Count != 0)
                {
                    GridviewValuAddToUpdate(dTables[1]);
                    getInformationInOrderUItoUpdate(dTables[0]);
                }
                else
                {
                    MessageBox.Show("Invalid ID !!");
                }
                
            }
        }
        public void LoadInformationInDELIVERY_UI_textboxes()
        {
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(SearchByIDtextBox1.Text, out aCustomer.ID);
            DeliveryBLL aDeliveryBLL = new DeliveryBLL();
            DataTable[] dTables = aDeliveryBLL.SearchOrderInformationforDELIVERY_UIto_UpdateBLL(aCustomer);
            if (dTables[0] == null)
            {
                MessageBox.Show("Please Your Search ID !");
            }
            else
            {
                Delivery_gridViewColumnAssign();
                if (dTables[1].Rows.Count != 0 && dTables[0].Rows.Count != 0)
                {
                    Delivery_GridviewValuAddToUpdate(dTables[1]);
                    getInformationIn_DELIVERY_UItoUpdate(dTables[0]);
                }
                else
                {
                    MessageBox.Show("Invalid ID !!");
                }
                
                
            }
        }
        public void LoadInformationIn_PAYMENT_UI_Textboxes()
        {
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(SearchByIDtextBox1.Text, out aCustomer.ID);
            DeliveryBLL aDeliveryBLL = new DeliveryBLL();
            DataTable[] dTables = aDeliveryBLL.SearchOrderInformationforDELIVERY_UIto_UpdateBLL(aCustomer);
            if (dTables[0] == null)
            {
                MessageBox.Show("Please Your Search ID !");
            }
            else
            {
                Payment_gridViewColumnAssign();
                if (dTables[1].Rows.Count!=0 && dTables[0].Rows.Count!=0)
                {
                    PAYMENT_GridviewValuAddToUpdate(dTables[1]);
                    getInformationIn_pAYMENT_UItoUpdate(dTables[0]);
                }
                else
                {
                    MessageBox.Show("Invalid ID !!");
                }

                

            }
        }
        private void ORDER_Search_button14_Click(object sender, EventArgs e)
        {
            if (A==2)
            {
                OrderDetailsdataGridView1.Rows.Clear();
                LoadInformationInORDER_UI_textboxes();
            }
            else if (A == 3)
            {
                Delivery_OrderDetailsdataGridView1.Rows.Clear();
                LoadInformationInDELIVERY_UI_textboxes();
            }
            else if (A == 4)
            {
                PAYMENT_dataGridView1.Rows.Clear();
                LoadInformationIn_PAYMENT_UI_Textboxes();

            }

        }
        private void SearchByIDtextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            SearchByIDtextBox1.Text = "";
        }
        private void OrderDetailsdataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (OrderDetailsdataGridView1.Rows[0].Cells[3].Value.ToString()== "21-K")
            {                
                ORDER_21K_radioButton2.Checked = true;
            }
            if (OrderDetailsdataGridView1.Rows[0].Cells[3].Value.ToString() == "21-K-HOL")
            {                
                ORDER_21kHOL_radioButton4.Checked = true;
            }
            if (OrderDetailsdataGridView1.Rows[0].Cells[3].Value.ToString() == "22-K")
            {
                ORDER_22K_radioButton3.Checked =true;
            }
            ORDER_ProductType_comboBox1.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ORDER_ItemTtypecomboBox1.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            OrderProdutWeight_Vori__textBox1.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            OrderProdutWeight_Ani_textBox1.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            OrderProdutWeight_Roti_textBox2.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            OrderProdutWeight_Point_textBox3.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            OrderPanel_OrdersInVori_textBox1.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[8].Value.ToString();

                       
            ORDER_DesignIDtextBox6.Text = OrderDetailsdataGridView1.SelectedRows[0].Cells[9].Value.ToString();
           

        }
        private void OrderUpdate_button4_Click(object sender, EventArgs e)
        {
            int TotalNumberOfOrder = int.Parse(ORDER_NumberOfItemstextBox9.Text);
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(ORDER_orderIDtextBox2.Text, out aCustomer.ID);
            aCustomer.name = ORDER_CustomerNametextBox1.Text;
            aCustomer.Address = ORDER_Address_textBox4.Text;
            aCustomer.ContactNo = ORDER_ContactNotextBox3.Text;


            OrderDetails aOrderDetails = new OrderDetails();
            aOrderDetails.CID = 0;
            int.TryParse(ORDER_orderIDtextBox2.Text, out aOrderDetails.CID);
            aOrderDetails.IssueDate = ORDER_IssueDate_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            aOrderDetails.DeliveryDate = ORDER_DeliveryDatedateTimePicker2.Value.ToString("yyyy-MM-dd");
            aOrderDetails.RateOfProduct = 0;
            float.TryParse(ORDER_RateofProduct_textBox5.Text, out aOrderDetails.RateOfProduct);

            aOrderDetails.TotalWeight = 0;
            float.TryParse(ORDER_Total_Weight_textBox7.Text, out aOrderDetails.TotalWeight);
            aOrderDetails.OrderStatus = "Ordered";
            aOrderDetails.Total_Vori = 0;
            float.TryParse(TotalVori_textBox1.Text, out aOrderDetails.Total_Vori);
            aOrderDetails.Total_Ana = 0;
            float.TryParse(TotalAna_textBox2.Text, out aOrderDetails.Total_Ana);
            aOrderDetails.Total_Roti = 0;
            float.TryParse(TotalRoti_textBox3.Text, out aOrderDetails.Total_Roti);
            aOrderDetails.Total_Point = 0;
            float.TryParse(TotalPoint_textBox4.Text, out aOrderDetails.Total_Point);
            aOrderDetails.TotalWeight = 0;
            float.TryParse(ORDER_Total_Weight_textBox7.Text, out aOrderDetails.TotalWeight);

            aOrderDetails.Depo_Vori = 0;
            float.TryParse(Order_Depo__Vori_textBox4.Text, out aOrderDetails.Depo_Vori);
            aOrderDetails.Depo_Ana = 0;
            float.TryParse(Order_Depo__Ana_textBox3.Text, out aOrderDetails.Depo_Ana);
            aOrderDetails.Depo_Roti = 0;
            float.TryParse(Order_Depo__Roti_textBox2.Text, out aOrderDetails.Depo_Roti);
            aOrderDetails.Depo_Point = 0;
            float.TryParse(Order_Depo_Point_textBox1.Text, out aOrderDetails.Depo_Point);
            aOrderDetails.DepositedProductAmount = 0;
            float.TryParse(TotalDepoWeight_textBox3.Text, out aOrderDetails.DepositedProductAmount);

            Payment aPayment = new Payment();
            aPayment.CID = 0;
            int.TryParse(ORDER_orderIDtextBox2.Text, out aPayment.CID);
            aPayment.ProductCharge = 0;
            float.TryParse(ORDER_ProductPrice_textBox10.Text, out aPayment.ProductCharge);
            aPayment.DesigningCharge = 0;
            float.TryParse(ORDER_DesigningCharge_textBox11.Text, out aPayment.DesigningCharge);
            aPayment.TotalBill = 0;
            float.TryParse(ORDER_TotalCost_textBox15.Text, out aPayment.TotalBill);
            aPayment.Advance = 0;
            float.TryParse(ORDER_AdvancetextBox12.Text, out aPayment.Advance);
            aPayment.LastPayment = 0;
            float.TryParse(ORDER_AdvancetextBox12.Text, out aPayment.LastPayment);
            aPayment.Due = 0;
            float.TryParse(ORDER_DuetextBox13.Text, out aPayment.Due);
            aPayment.PaymentStatus = PaymentStatusDetect(ORDER_DuetextBox13.Text);


            OrderBLL aOrderBLL = new OrderBLL();
            bool res = aOrderBLL.UpdateOrderInformationBLL(aCustomer, aOrderDetails, aPayment, arr, OrderDetailsdataGridView1.Rows.Count);
            
            if (res)
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Order Information Updated Successfully";
                if (MessageBox.Show("Get Billing Slip? ", "Cash Memo", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    ReportUI aReportUI = new ReportUI(A, aCustomer.ID,aPayment.Due);
                    aReportUI.Show();
                }
                Clear_OrderUI_ALL_TextBoxes();
            }
            else
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Please Check Order Information";
            }

        }
        private void OrderUI_Cancel_button1_Click(object sender, EventArgs e)
        {
            
            Clear_OrderUI_ALL_TextBoxes();
        }
        private void Delivery_Discount_textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void Delivery_FinalWeight_textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Delivery_PaymenttextBox12_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void Delivery_f_button3_Click(object sender, EventArgs e)
        {
           

        }
        private void Delivery_Update_button4_Click(object sender, EventArgs e)
        {
            
        }
        private void Delivery_Cancel_button5_Click(object sender, EventArgs e)
        {

        }
        private void OrderProdutWeight_Vori__textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void OrderProdutWeight_Ani_textBox1_TextChanged(object sender, EventArgs e)
        {
           


        }
        private void OrderProdutWeight_Roti_textBox2_TextChanged(object sender, EventArgs e)
        {
           

        }
        private void OrderProdutWeight_Point_textBox3_TextChanged(object sender, EventArgs e)
        {
          

        }
        private void ORDER_DepositedAmount_textBox8_TextChanged_1(object sender, EventArgs e)
        {
            
        }
        private void Order_Depo_Point_textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }
        private void Order_Depo__Roti_textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }
        private void Order_Depo__Ana_textBox3_TextChanged(object sender, EventArgs e)
        {
            

        }
        private void Order_Depo__Vori_textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
        private float[] ORDER_weightandDepoAmount_Calculate(string Spoint,string Sroti,string Sana,string Svori)
        {
            float Vori = (float)0.0;
            float Ani = (float)0.0;
            float Roti = (float)0.0;
            float Points = (float)0.0;
            float DivideResult = 0;
            float Reminder = (float)0.0;

            float.TryParse(Spoint, out Points);
            float.TryParse(Sroti, out Roti);
            float.TryParse(Sana, out Ani);
            float.TryParse(Svori, out Vori);

            while (Points > 0 && Points >= 10)
            {
                DivideResult = Points / 10;
                DivideResult = (int)DivideResult;
                Roti = Roti + DivideResult;
                Reminder = Points % 10;
                Points = Reminder;
            }
            while (Roti >= 6)
            {
                DivideResult = Roti / 6;
                DivideResult = (int)DivideResult;
                Ani = Ani + DivideResult;
                Reminder = Roti % 6;
                Roti = Reminder;  
            }
            while (Ani >= 16)
            {
                DivideResult = Ani / 16;
                DivideResult = (int)DivideResult;
                Vori = Vori + DivideResult;
                Reminder = Ani % 16;
                Ani = Reminder;
            }
            float TotalWeightInvori = (float)0.0;
            TotalWeightInvori = (Ani / 16) + (Roti / 96) + (Points / 960) + Vori;  
            return new float[] {Points,Roti,Ani,Vori, TotalWeightInvori };
        }
        private void ORDER_WeightBalancer_button4_Click(object sender, EventArgs e)
        {
            float[] a = ORDER_weightandDepoAmount_Calculate(OrderProdutWeight_Point_textBox3.Text, OrderProdutWeight_Roti_textBox2.Text, OrderProdutWeight_Ani_textBox1.Text, OrderProdutWeight_Vori__textBox1.Text);
            OrderProdutWeight_Point_textBox3.Text = a[0].ToString();
            OrderProdutWeight_Roti_textBox2.Text = a[1].ToString();
            OrderProdutWeight_Ani_textBox1.Text = a[2].ToString();
            OrderProdutWeight_Vori__textBox1.Text = a[3].ToString();
            OrderPanel_OrdersInVori_textBox1.Text = a[4].ToString();

        }
        private void DepositedAmountWeightBalancerbutton5_Click(object sender, EventArgs e)
        {
            float[] a = ORDER_weightandDepoAmount_Calculate(Order_Depo_Point_textBox1.Text,Order_Depo__Roti_textBox2.Text, Order_Depo__Ana_textBox3.Text,Order_Depo__Vori_textBox4.Text);
            Order_Depo_Point_textBox1.Text = a[0].ToString();
            Order_Depo__Roti_textBox2.Text = a[1].ToString();
            Order_Depo__Ana_textBox3.Text = a[2].ToString();
            Order_Depo__Vori_textBox4.Text = a[3].ToString();
            TotalDepoWeight_textBox3.Text = a[4].ToString();
        }
        private void Clear_Weightbutton1_Click(object sender, EventArgs e)
        {
            OrderProdutWeight_Point_textBox3.Text = "";
            OrderProdutWeight_Roti_textBox2.Text = "";
            OrderProdutWeight_Ani_textBox1.Text = "";
            OrderProdutWeight_Vori__textBox1.Text = "";
            OrderPanel_OrdersInVori_textBox1.Text = "";
        }
        private void ClearDepoWeightbutton3_Click(object sender, EventArgs e)
        {
            Order_Depo_Point_textBox1.Text = "";
            Order_Depo__Roti_textBox2.Text = "";
            Order_Depo__Ana_textBox3.Text = "";
            Order_Depo__Vori_textBox4.Text = "";
            TotalDepoWeight_textBox3.Text = "";
        }
        private void ORDER_DepositedAmount_textBox8_TextChanged_2(object sender, EventArgs e)
        {
            
        }
        private void TotalDepoWeight_textBox3_TextChanged(object sender, EventArgs e)
        {
            if (ORDER_Total_Weight_textBox7.Text != "" && TotalDepoWeight_textBox3.Text != "")
            {
                float RateofProduct = float.Parse(ORDER_RateofProduct_textBox5.Text);
                float Weight = float.Parse(ORDER_Total_Weight_textBox7.Text);
                float ProductPrice = RateofProduct * Weight;
                float SubmittedAmount = 0;
                float.TryParse(TotalDepoWeight_textBox3.Text, out SubmittedAmount);
                SubmittedAmount = SubmittedAmount * RateofProduct;
                ProductPrice = ProductPrice - SubmittedAmount;
                ORDER_ProductPrice_textBox10.Text = ProductPrice.ToString();
            }
            else
            {
                ORDER_ProductPrice_textBox10.Text = "";
            }

            try
            {
                if (ORDER_TotalCost_textBox15.Text != "" && ORDER_AdvancetextBox12.Text != "")
                {
                    float TotalCost = float.Parse(ORDER_TotalCost_textBox15.Text);
                    float Advance = float.Parse(ORDER_AdvancetextBox12.Text);
                    float Due = TotalCost - Advance;
                    ORDER_DuetextBox13.Text = Due.ToString();
                }
                else
                {
                    ORDER_DuetextBox13.Text = "";
                }
            }
            catch
            {

            }
        }
        private void DELIVERY_FinalWeightBalance_button1_Click(object sender, EventArgs e)
        {
            float[] a = ORDER_weightandDepoAmount_Calculate(DELIVERY_FinalWeight_Point_textBox7.Text, DELIVERY_FinalWeight_Roti_textBox6.Text, DELIVERY_FinalWeight__Ana_textBox5.Text, DELIVERY_FinalWeight_Vori_textBox4.Text);
            DELIVERY_FinalWeight_Point_textBox7.Text = a[0].ToString();
            DELIVERY_FinalWeight_Roti_textBox6.Text = a[1].ToString();
            DELIVERY_FinalWeight__Ana_textBox5.Text = a[2].ToString();
            DELIVERY_FinalWeight_Vori_textBox4.Text = a[3].ToString();
            Delivery_FinalWeight_textBox3.Text = a[4].ToString();
        }
        private void Clear_Delivery_Final_Weight_button3_Click(object sender, EventArgs e)
        {
            Delivery_OrderDetailsdataGridView1.Rows.Clear();
            LoadInformationInDELIVERY_UI_textboxes();
            Delivery_Payment___textBox3.Text = "";
            DELIVERY_FinalWeight_Point_textBox7.Text = "";
            DELIVERY_FinalWeight_Roti_textBox6.Text = "";
            DELIVERY_FinalWeight__Ana_textBox5.Text = "";
            DELIVERY_FinalWeight_Vori_textBox4.Text = "";
            Delivery_FinalWeight_textBox3.Text = "";
        }

        private void Delivery_FinalWeight_textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Delivery_FinalWeight_textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (Delivery_RateofProduct_textBox5.Text != "" && Delivery_FinalWeight_textBox3.Text != "")
            {
                try
                {
                    float a = 0;
                    float DepositedAmountCost = float.Parse(Delivery_DepositedAmount_textBox8.Text)*float.Parse(Delivery_RateofProduct_textBox5.Text);
                    Delivery_ProductPrice_textBox10.Text = ((float.Parse(Delivery_RateofProduct_textBox5.Text) * float.Parse(Delivery_FinalWeight_textBox3.Text))).ToString();
                    Delivery_TotalCost_textBox15.Text = ((float.Parse(Delivery_RateofProduct_textBox5.Text) * float.Parse(Delivery_FinalWeight_textBox3.Text))- DepositedAmountCost + float.Parse(Delivery_DesigningCharge_textBox11.Text)).ToString();
                    CostHelper_label48.Text = Delivery_TotalCost_textBox15.Text;
                    float.TryParse(DEL_DIS_textBox3.Text, out a);
                    Delivery_DuetextBox13.Text = (float.Parse(CostHelper_label48.Text) - float.Parse(DELIVERY_PaindAmount_textBox3.Text) - a).ToString();
                }
                catch
                {

                }
            }
            else
            {
                try
                {
                    float a = 0;
                    float DepositedAmountCost = float.Parse(Delivery_DepositedAmount_textBox8.Text) * float.Parse(Delivery_RateofProduct_textBox5.Text);
                    Delivery_ProductPrice_textBox10.Text = ((float.Parse(Delivery_RateofProduct_textBox5.Text) * 0)).ToString();
                    Delivery_TotalCost_textBox15.Text = ((float.Parse(Delivery_RateofProduct_textBox5.Text) * 0) - DepositedAmountCost + float.Parse(Delivery_DesigningCharge_textBox11.Text)).ToString();
                    CostHelper_label48.Text = Delivery_TotalCost_textBox15.Text;
                    float.TryParse(DEL_DIS_textBox3.Text, out a);
                    Delivery_DuetextBox13.Text = (float.Parse(CostHelper_label48.Text) - float.Parse(DELIVERY_PaindAmount_textBox3.Text) - a).ToString();
                }
                catch
                {

                }

            }
        }

        private void DEL_DIS_textBox3_TextChanged(object sender, EventArgs e)
        {
            float TotalCost = 0;
            float.TryParse(CostHelper_label48.Text, out TotalCost);
            float Discount = 0;
            float.TryParse(DEL_DIS_textBox3.Text, out Discount);
            float payment = 0;
            float.TryParse(Delivery_Payment___textBox3.Text, out payment);
            float paid = 0;
            float.TryParse(DELIVERY_PaindAmount_textBox3.Text, out paid);
            if (Delivery_RateofProduct_textBox5.Text != "" && DELIVERY_PaindAmount_textBox3.Text != "" && DEL_DIS_textBox3.Text != "")
            {
               
                try
                {   
                    Delivery_DuetextBox13.Text = (TotalCost - paid - payment- Discount).ToString();
                }
                catch
                {

                }

            }
            else
            { 
                
                Delivery_DuetextBox13.Text = (TotalCost - paid- payment- Discount).ToString();
            }
        }

        private void Delivery_Payment___textBox3_TextChanged(object sender, EventArgs e)
        {
            float TotalCost = 0;
            float.TryParse(CostHelper_label48.Text, out TotalCost);
            float Discount = 0;           
            float.TryParse(DEL_DIS_textBox3.Text, out Discount);
            if (float.Parse(DELIVERY_Discount_label144.Text) == Discount)
            {
                Discount = 0;
            }
            float payment = 0;
            float.TryParse(Delivery_Payment___textBox3.Text, out payment);
            float paid = 0;
            float.TryParse(DELIVERY_PaindAmount_textBox3.Text, out paid);
            if (Delivery_RateofProduct_textBox5.Text != "" && DELIVERY_PaindAmount_textBox3.Text != "" && DEL_DIS_textBox3.Text != "")
            {

                try
                {
                    Delivery_DuetextBox13.Text = (TotalCost - paid - payment- Discount).ToString();
                }
                catch
                {

                }

            }
            else
            {

                Delivery_DuetextBox13.Text = (TotalCost - paid - payment-Discount ).ToString();
            }
        }

        private void Delivery_Confirm_button3_Click(object sender, EventArgs e)
        {
            
            OrderDetails aOrderDetails = new OrderDetails();
            aOrderDetails.CID = 0;
            int.TryParse(Delivery_orderIDtextBox2.Text, out aOrderDetails.CID);
            aOrderDetails.FinalWeight = 0;
            float.TryParse(Delivery_FinalWeight_textBox3.Text, out aOrderDetails.FinalWeight);
            aOrderDetails.OrderStatus = "Delivered";
            aOrderDetails.Final_Vori = 0;
            float.TryParse(DELIVERY_FinalWeight_Vori_textBox4.Text, out aOrderDetails.Final_Vori);
            aOrderDetails.Final_Ana = 0;
            float.TryParse(DELIVERY_FinalWeight__Ana_textBox5.Text, out aOrderDetails.Final_Ana);
            aOrderDetails.Final_Roti = 0;
            float.TryParse(DELIVERY_FinalWeight_Roti_textBox6.Text, out aOrderDetails.Final_Roti);
            aOrderDetails.Final_Point = 0;
            float.TryParse(DELIVERY_FinalWeight_Point_textBox7.Text, out aOrderDetails.Final_Point);

            Payment aPayment = new Payment();
            aPayment.ProductCharge = 0;
            float.TryParse(Delivery_ProductPrice_textBox10.Text, out aPayment.ProductCharge);
            aPayment.TotalBill = 0;
            float.TryParse(Delivery_TotalCost_textBox15.Text, out aPayment.TotalBill);
            aPayment.LastPayment = 0;
            float.TryParse(Delivery_Payment___textBox3.Text, out aPayment.LastPayment);
            aPayment.Due = 0;
            float.TryParse(Delivery_DuetextBox13.Text, out aPayment.Due);
            aPayment.Discount = 0;
            float.TryParse(DEL_DIS_textBox3.Text,out aPayment.Discount);
            aPayment.PaymentStatus = PaymentStatusDetect(Delivery_DuetextBox13.Text);

            DeliveryBLL aDeliveryBLL = new DeliveryBLL();
            bool res = aDeliveryBLL.SaveDeliveryInformationBLL(aOrderDetails, aPayment);
            if (res)
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Delivery Information Saved Successfully";
                if (MessageBox.Show("Get Billing Slip? ", "Cash Memo", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    ReportUI aReportUI = new ReportUI(A,aOrderDetails.CID,aPayment.Due);
                    aReportUI.Show();
                }
                Clear_OrderUI_ALL_TextBoxes();
            }
            else
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Please Check  Information";
            }
        }

        private void Delivery_Update_button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Delivery_UI_Cancel_button1_Click(object sender, EventArgs e)
        {
            Clear_OrderUI_ALL_TextBoxes();
        }

        private void Delivery_Cancel_button5_Click_1(object sender, EventArgs e)
        {
           
            OrderDetails aOrderDetails = new OrderDetails();
            aOrderDetails.CID = 0;
            int.TryParse(Delivery_orderIDtextBox2.Text,out aOrderDetails.CID);
            aOrderDetails.RateOfProduct = 0;
            aOrderDetails.TotalWeight = 0;
            float.TryParse(Delivery_RateofProduct_textBox5.Text,out aOrderDetails.RateOfProduct);
            float.TryParse(Delivery_Total_Weight_textBox7.Text, out aOrderDetails.TotalWeight);
            float paid = 0;
            float.TryParse(DELIVERY_PaindAmount_textBox3.Text,out paid);
            
            Payment aPayment = new Payment();
            aPayment.DesigningCharge = 0;
            float.TryParse(Delivery_DesigningCharge_textBox11.Text, out aPayment.DesigningCharge);
            aPayment.ProductCharge = aOrderDetails.RateOfProduct * aOrderDetails.TotalWeight;
            aPayment.TotalBill = aPayment.ProductCharge + aPayment.DesigningCharge;
            aPayment.Due = 0; 
            aPayment.Discount = 0; 
            aOrderDetails.OrderStatus = "Ordered";
            DeliveryBLL aDeliveryBLL = new DeliveryBLL();
            bool res=aDeliveryBLL.CancelDeliveryBLL(aPayment, aOrderDetails);
            if (res)
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Delivery Cancelled Successfully";
                Clear_OrderUI_ALL_TextBoxes();
            }
            else
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Please Check  Information";
            }
        }

        private void PAYMENT_Discount_textBox1_TextChanged(object sender, EventArgs e)
        {
            float due = 0;
            float.TryParse(PAYMENT_DuetextBox11.Text,out due);
            float TotalCost = 0;
            float.TryParse(payment_CostHelper_label84.Text, out TotalCost);
            float Discount = 0;
            float.TryParse(PAYMENT_Discount_textBox1.Text, out Discount);
            float payment = 0;
            float.TryParse(PAYMENT_Payment_textBox12.Text, out payment);
            float paid = 0;
            float.TryParse(PAYMENT_Paid_textBox9.Text, out paid);
            if (payment_RateofProduct_textBox8.Text != "" && PAYMENT_Paid_textBox9.Text != "" && PAYMENT_Discount_textBox1.Text != "")
            {
                try
                {  
                    PAYMENT_DuetextBox11.Text = (TotalCost - paid - payment- Discount).ToString();
                }
                catch
                {

                }

            }
            else
            {
                PAYMENT_TotalCost_textBox10.Text = payment_CostHelper_label84.Text;
                PAYMENT_DuetextBox11.Text = (float.Parse(payment_CostHelper_label84.Text) - paid - payment).ToString();
            }
            

        }

        private void PAYMENT_Payment_textBox12_TextChanged(object sender, EventArgs e)
        {
            float discount = 0;
            float payment = 0;
            float paid = 0;
            float.TryParse(PAYMENT_Discount_textBox1.Text, out discount);
            float.TryParse(PAYMENT_Payment_textBox12.Text, out payment);
            float.TryParse(PAYMENT_Paid_textBox9.Text, out paid);
            if (PAYMENT_TotalCost_textBox10.Text != "" && PAYMENT_Payment_textBox12.Text != "")
            {

                try
                {


                    PAYMENT_DuetextBox11.Text = (float.Parse(payment_CostHelper_label84.Text) - payment - paid).ToString();
                }
                catch
                {
                }
            }
            else
            {
                PAYMENT_DuetextBox11.Text = (float.Parse(payment_CostHelper_label84.Text) - payment - paid).ToString();

            }
        }

        private void PAYMENT_Discount_textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            float due = 0;
            float.TryParse(PAYMENT_DuetextBox11.Text, out due);
            float TotalCost = 0;
            float.TryParse(payment_CostHelper_label84.Text, out TotalCost);
            float Discount = 0;
            float.TryParse(label117.Text, out Discount);
            float payment = 0;
            float.TryParse(PAYMENT_Payment_textBox12.Text, out payment);
            float paid = 0;
            float.TryParse(PAYMENT_Paid_textBox9.Text, out paid);
            PAYMENT_Paid_textBox9.Text = (paid- Discount).ToString();
            PAYMENT_DuetextBox11.Text = (due+ Discount).ToString();
            PAYMENT_Discount_textBox1.Text = "";
            label117.Text = 0.ToString();
            float.TryParse(label117.Text, out Discount);
        }

        private void DEL_DIS_textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            float due = 0;
            float.TryParse(Delivery_DuetextBox13.Text, out due);
            float TotalCost = 0;
            float.TryParse(CostHelper_label48.Text, out TotalCost);
            float Discount = 0;
            float.TryParse(label117.Text, out Discount);
            float payment = 0;
            float.TryParse(Delivery_Payment___textBox3.Text, out payment);
            float paid = 0;
            float.TryParse(DELIVERY_PaindAmount_textBox3.Text, out paid);
            DELIVERY_PaindAmount_textBox3.Text = (paid - Discount).ToString();
            Delivery_DuetextBox13.Text = (due + Discount).ToString();
            DEL_DIS_textBox3.Text = "";
            label117.Text = 0.ToString();
            float.TryParse(label117.Text, out Discount);
        }

        private void PAYMENT_Confirm_button4_Click(object sender, EventArgs e)
        {
            Payment aPayment = new Payment();
            aPayment.CID = 0;
           int.TryParse(PAYMENT_orderIDtextBox2textBox15.Text,out aPayment.CID);
            aPayment.Discount = 0;
            float.TryParse(PAYMENT_Discount_textBox1.Text, out aPayment.Discount);
            aPayment.Due = 0;
            float.TryParse(PAYMENT_DuetextBox11.Text, out aPayment.Due);
            aPayment.LastPayment = 0;
            float.TryParse(PAYMENT_Payment_textBox12.Text, out aPayment.LastPayment);
            aPayment.PaymentStatus = PaymentStatusDetect(PAYMENT_DuetextBox11.Text);

            PaymentBLL aPaymentBLL = new PaymentBLL();
            bool res = aPaymentBLL.SavePaymenInformationtBLL(aPayment);
            if (res)
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Payment Saved Successfully";
                Clear_OrderUI_ALL_TextBoxes();
                if (MessageBox.Show("Get Billing Slip? ", "Cash Memo", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    ReportUI aReportUI = new ReportUI(A,aPayment.CID,aPayment.Due);
                    aReportUI.Show();
                }
               
            }
            else
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = "Please Check  Information";
            }
        }

        private void RestorePayment_button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Restore All Payment ? ","Restore Payments",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Payment aPayment = new Payment();
                aPayment.CID = 0;
                int.TryParse(PAYMENT_orderIDtextBox2textBox15.Text,out aPayment.CID);
                aPayment.Due = 0;
                float.TryParse(Payment_label84.Text,out aPayment.Due);
                aPayment.Advance= 0;
                float.TryParse(Payment_AdvanceAmountlabel49label91.Text, out aPayment.Advance);

                PaymentBLL aPaymentBLL = new PaymentBLL();
            int res= aPaymentBLL.CancelPaymentBLL(aPayment);
            if (res==1)
            {
                    ActionStataus__label16.Visible = true;
                    ActionStataus__label16.Text = "Payment Cancelled Successfully";
                Clear_OrderUI_ALL_TextBoxes();
            }
            else if(res==2)
            {
                    ActionStataus__label16.Visible = true;
                    ActionStataus__label16.Text = "No More Payment Can be Cancelled";
            }
            }
            else
            {
                ActionStataus__label16.Visible = true;
                ActionStataus__label16.Text = " Invalid Id or Information !!";
            }
        }

        private void PAYMENT_Clear_button1_Click(object sender, EventArgs e)
        {
            Clear_OrderUI_ALL_TextBoxes();
        }

        private void DELIVERY_SCHEDULE_ViewSchedule_button3_Click(object sender, EventArgs e)
        {
            string scheduleTimeLimit = DELIVERY_SCHEDULE_Schedule_TypeSelector_comboBox1.Text;
            
            string sDate = DELIVERYschedule_sTart_dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string eDate = DELIVERYschedule_eNd_dateTimePicker2.Value.ToString("yyyy-MM-dd");
            DeliveryScheduleBLL aDeliveryScheduleBLL = new DeliveryScheduleBLL();
            DataTable [] dTable = aDeliveryScheduleBLL.ViewDeliveryScheduleBLL(scheduleTimeLimit, sDate, eDate);
            if (dTable!=null)
            {
                DeliveryScheduleViewer_dataGridView1.DataSource = dTable[0];
                dateTimePicker1.Text = dTable[1].Rows[0][0].ToString();
                dateTimePicker2.Text = dTable[2].Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("Please Select Delivery Schedule Type !!!");
            }
        }

        private void DELIVERY_SCHEDULE_Schedule_TypeSelector_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DELIVERY_SCHEDULE_Schedule_TypeSelector_comboBox1.Text == "Specifi‪c Time Period")
            {
                DELIVERY_SCHEDULE_Specific_panel14.Visible = true;
            }
            else
            {
                DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            }
        }
        string issueDATE;
        string deliveryDATE;
        public void SearchAction()
        {
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(SEARCH_CustomerID_textBox3.Text, out aCustomer.ID);
            aCustomer.name = CUSTOMER_Name_textBox4.Text;
            aCustomer.Address = SEARCH_Address_textBox7.Text;
            aCustomer.ContactNo = SEARCH_ContactNo_textBox8.Text;

            OrderDetails aOrderDetails = new OrderDetails();
            aOrderDetails.IssueDate = issueDATE;
            aOrderDetails.DeliveryDate = deliveryDATE;

            SearchBLL aSearchBLL = new SearchBLL();
            DataTable dt = aSearchBLL.Search_CustomerInformationBLL(aCustomer, aOrderDetails);
            if (dt.Rows.Count > 0 && dt!=null)
            {
                SEARCH_Result_dataGridView1.DataSource = dt;
                issueDATE = "";
                deliveryDATE = "";
                SEARCH_CustomerID_textBox3.Text = "";
                CUSTOMER_Name_textBox4.Text = "";
                SEARCH_Address_textBox7.Text = "";
                SEARCH_ContactNo_textBox8.Text = "";

            }
            else
            {
                issueDATE = "";
                deliveryDATE = "";
                SEARCH_CustomerID_textBox3.Text = "";
                CUSTOMER_Name_textBox4.Text = "";
                SEARCH_Address_textBox7.Text = "";
                SEARCH_ContactNo_textBox8.Text = "";
                MessageBox.Show("Please Check Search Keyword");
            }
        }
        private void SEARCH_Search_button1_Click(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void SEARCH_IssueDate_dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            issueDATE = SEARCH_IssueDate_dateTimePicker3.Value.ToString("yyyy-MM-dd");
        }

        private void SEARCH_DeliveryDate_dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            deliveryDATE= SEARCH_DeliveryDate_dateTimePicker4.Value.ToString("yyyy-MM-dd");
        }

        private void SEARCH_ClearSearcPanel_button3_Click(object sender, EventArgs e)
        {
            Clear_OrderUI_ALL_TextBoxes();
        }

        private void DESIGN_LoadDesign_Image_button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DESIGN_LOadDesignPic_pictureBox7.Image = new Bitmap(dialog.FileName);
                PathLocationlabel133.Text= dialog.FileName;

            }
        }

        private void DESIGN_Save_button8_Click(object sender, EventArgs e)
        {
            Design aDesign = new Design();
            aDesign.DID = 0;
            int.TryParse(DESIGN_DesignID_textBox4.Text,out aDesign.DID);
            aDesign.Details = DESIGN_ItemType_comboBox1.Text;
            aDesign.DesignCost = 0;
            float.TryParse(DESIGN_DesignCost_textBox3.Text,out aDesign.DesignCost);

            FileStream stream = new FileStream(PathLocationlabel133.Text, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            aDesign.images = brs.ReadBytes((int)stream.Length);

            DesignBLL aDesignBLL = new DesignBLL();
            DataTable dTable = aDesignBLL.SaveDesignBLL(aDesign);
            if (dTable==null)
            {
                MessageBox.Show("Please Check given Information !!");
            }
            else
            {
                DESIGN_dataGridView1.DataSource = dTable;
                MessageBox.Show("New Design Successfully Saved");
                DESIGN_DesignID_textBox4.Text = "";
                DESIGN_ItemType_comboBox1.Text = "";
                DESIGN_DesignCost_textBox3.Text = "";
            }
        }
        private void GetDesinInformation()
        {
            DataTable dTable = new DataTable();
            DesignBLL aDesignBLL = new DesignBLL();
            dTable = aDesignBLL.GetDesignInformationInGridView();
            DESIGN_dataGridView1.DataSource = dTable;
        }

        private void DESIGN_dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        int DesignID_BeforeUpdate = 0;
        private void DESIGN_dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            DESIGN_DesignID_textBox4.Text = DESIGN_dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DesignID_BeforeUpdate = int.Parse(DESIGN_dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DESIGN_ItemType_comboBox1.Text = DESIGN_dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            DESIGN_DesignCost_textBox3.Text = DESIGN_dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            byte[] images = ((byte[])(DESIGN_dataGridView1.SelectedRows[0].Cells[3].Value));
            MemoryStream mStream = new MemoryStream(images);
            DESIGN_LOadDesignPic_pictureBox7.Image = Image.FromStream(mStream);
        }

        private void DESIGN_Update_button3_Click(object sender, EventArgs e)
        {
            Design aDesign = new Design();
            aDesign.DID = 0;
            int.TryParse(DESIGN_DesignID_textBox4.Text, out aDesign.DID);
            aDesign.Details = DESIGN_ItemType_comboBox1.Text;
            aDesign.DesignCost = 0;
            float.TryParse(DESIGN_DesignCost_textBox3.Text, out aDesign.DesignCost);
            try
            {
                FileStream stream = new FileStream(PathLocationlabel133.Text, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                aDesign.images = brs.ReadBytes((int)stream.Length);
            }
            catch
            {

            }
            DesignBLL aDesignBLL = new DesignBLL();
            DataTable dTable = aDesignBLL.UpdateDesignBLL(aDesign, DesignID_BeforeUpdate);
            if (dTable == null)
            {
                MessageBox.Show("Please Check given Information !!");
            }
            else
            {
                DESIGN_dataGridView1.DataSource = dTable;
                MessageBox.Show("Design Successfully Updated");
                DESIGN_DesignID_textBox4.Text = "";
                DESIGN_ItemType_comboBox1.Text = "";
                DESIGN_DesignCost_textBox3.Text = "";
                DesignID_BeforeUpdate = 0;
            }
        }

        private void DESIGN_Delete_button4_Click(object sender, EventArgs e)
        {
            Design aDesign = new Design();
            aDesign.DID = 0;
            int.TryParse(DESIGN_DesignID_textBox4.Text, out aDesign.DID);
            aDesign.Details = DESIGN_ItemType_comboBox1.Text;
            aDesign.DesignCost = 0;
            float.TryParse(DESIGN_DesignCost_textBox3.Text, out aDesign.DesignCost);
            DesignBLL aDesignBLL = new DesignBLL();
            DataTable dTable = aDesignBLL.DeleteDesign_BLL(aDesign);
            if (dTable == null)
            {
                MessageBox.Show("Please Check given Information !!");
            }
            else
            {
                DESIGN_dataGridView1.DataSource = dTable;
                MessageBox.Show("Design Successfully DEleted!!");
                DESIGN_DesignID_textBox4.Text = "";
                DESIGN_ItemType_comboBox1.Text = "";
                DESIGN_DesignCost_textBox3.Text = "";
                DesignID_BeforeUpdate = 0;
            }
        }

        private void inputDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dESIGNToolStripMenuItem.BackColor = Color.Gainsboro;
            dESIGNToolStripMenuItem.ForeColor = Color.Black;
            MenuStripDesignOnClick(A);
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            SEARCH_panel.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            DESIGN_Upload_panel.Visible = true;

            GetDesinInformation();
            A = 7;
        }

        private void galleryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DesignGallery aDesignGallery = new DesignGallery(A);
            aDesignGallery.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainUnit aMainUnit = new MainUnit();
            DesignGallery aDesignGallery = new DesignGallery(A);
            aDesignGallery.ShowDialog();
            ORDER_DesignIDtextBox6.Text = aDesignGallery.DID_label28.Text;
        }

        private void OrderSlip_button3_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            Payment aPayment = new Payment();
            aPayment.Due = 0;
            float.TryParse(ORDER_DuetextBox13.Text,out aPayment.Due);
            int.TryParse(ORDER_orderIDtextBox2.Text,out aCustomer.ID);
            ReportUI aReportUI = new ReportUI(A, aCustomer.ID, aPayment.Due);
            aReportUI.Show();
        }

        private void DeliverySlip_button3_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            Payment aPayment = new Payment();
            aPayment.Due = 0;
            float.TryParse(Delivery_DuetextBox13.Text, out aPayment.Due);

            int.TryParse(Delivery_orderIDtextBox2.Text, out aCustomer.ID);
            ReportUI aReportUI = new ReportUI(A, aCustomer.ID, aCustomer.ID);
            aReportUI.Show();
        }

        private void PaymentSlip_button3_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.ID = 0;
            int.TryParse(PAYMENT_orderIDtextBox2textBox15.Text, out aCustomer.ID);
            Payment aPayment = new Payment();
            aPayment.Due = 0;
            float.TryParse(PAYMENT_DuetextBox11.Text, out aPayment.Due);
            ReportUI aReportUI = new ReportUI(A, aCustomer.ID, aCustomer.ID);
            aReportUI.Show();
        }

        private void DESIGN_INPUT_Clear_button3_Click(object sender, EventArgs e)
        {
            DESIGN_DesignID_textBox4.Text = "";
            DESIGN_ItemType_comboBox1.Text = "";
            DESIGN_DesignCost_textBox3 .Text= "";
        }

        private void AdminPaswordChange_Confirm_button3_Click(object sender, EventArgs e)
        {
            SystemAccess aSystemAcces = new SystemAccess();
            aSystemAcces.userName = AdminPaswordChange_UserName_ADDMINtextBox4.Text;
            aSystemAcces.Password = AdminPaswordChange_Password_textBox7.Text;
            string ConfirmPAss = AdminPaswordChange_confirmPassword_textBox3.Text;

            SystemAccessBLL aSystemAccessBLL = new SystemAccessBLL();
            bool res = aSystemAccessBLL.SetSystemAccessBLL(aSystemAcces, ConfirmPAss);
            if(res)
            {
                MessageBox.Show("Password Changed Succeesfully!!");
            }
            else
            {
                MessageBox.Show("Check UserName & Password!!");
            }

        }

        private void AdminPaswordChange_confirmPassword_textBox3_TextChanged(object sender, EventArgs e)
        {
            if (AdminPaswordChange_confirmPassword_textBox3.Text == AdminPaswordChange_Password_textBox7.Text)
            {
                AdminPaswordChange_PasswordConfirm_Notifier_panel16.BackColor = Color.SeaGreen;
            }
            else
            {
                AdminPaswordChange_PasswordConfirm_Notifier_panel16.BackColor = Color.Red;
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginUI aLoginUI = new LoginUI(A);
            this.Hide();
            aLoginUI.ShowDialog();
            int res = aLoginUI.UIDefiner;
            this.Show();
            AminPanelWork(res);
        }
        public void AminPanelWork(int AdminUINotifier)
        {
            if (AdminUINotifier==8)
            {
                aDMINToolStripMenuItem.BackColor = Color.Gainsboro;
                aDMINToolStripMenuItem.ForeColor = Color.Black;
                Clear_OrderUI_ALL_TextBoxes();
                MenuStripDesignOnClick(A);
                DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
                OrderPanel_panel1.Visible = false;
                DELIVERY_panel2.Visible = false;
                DELIVERY_SCHEDULE_panel.Visible = false;
                SEARCH_panel.Visible = false;
                pAYMENT_panel10.Visible =false;
                DESIGN_Upload_panel.Visible = false;
                AdminPaswordChange_panel15.Visible =true;
                HOME_panel16.Visible = false;
                ADMIN_PAYMENTLedger_panel16.Visible = false;
                ADMIN_ViewDueStatusr_panel16.Visible = false;
                ADMIN_Daily_Ledger_panel16.Visible = false;
                A =8;

            }
        }

        private void AdminPaswordChange_Clear_button1_Click(object sender, EventArgs e)
        {
            AdminPaswordChange_UserName_ADDMINtextBox4.Text = "";
            AdminPaswordChange_Password_textBox7.Text = "";
            AdminPaswordChange_confirmPassword_textBox3.Text = "";
        }

        private void paymentLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aDMINToolStripMenuItem.BackColor = Color.Gainsboro;
            aDMINToolStripMenuItem.ForeColor = Color.Black;
            Clear_OrderUI_ALL_TextBoxes();
            MenuStripDesignOnClick(A);
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            SEARCH_panel.Visible = false;
            pAYMENT_panel10.Visible = false;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = true;
            HOME_panel16.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = true;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            A = 8;
        }

        private void PAYMENT_Ledger_LedgerType_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PAYMENT_LEDGER_dataGridView1.DataSource =null;

            if (PAYMENT_Ledger_LedgerType_comboBox1.Text== "Specific Time Period")
            {
                PAYMENT_Ledger_Viewer_Date_panel26.Visible = true;
            }        
        }

        private void PAYMENTLEDGER_VIEW_Ledger_button1_Click(object sender, EventArgs e)
        {
            string LedgerPeriodType = PAYMENT_Ledger_LedgerType_comboBox1.Text;
            string StartDate = PAYMENT_Ledger_Start_dateTimePicker5.Value.ToString("yyyy-MM-dd");  
            string EndDate=PAYMENT_Ledger_End_dateTimePicker4.Value.ToString("yyyy-MM-dd");
            PaymentLedgerBLL aPaymentLedgerBLL = new PaymentLedgerBLL();
            DataTable dTable = aPaymentLedgerBLL.ViewPaymentLadgerOfSpecificDate(LedgerPeriodType, StartDate, EndDate);
            if (dTable==null)
            {
                MessageBox.Show("Please Check Information");
            }
            else
            {
                PAYMENT_LEDGER_dataGridView1.DataSource = dTable;
                PAYMENT_Ledger_LedgerType_comboBox1.Text="";
            }

        }

        private void ORDER_CustomerPictureselection_button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ORDER_Customer_pictureBox3.Image = new Bitmap(dialog.FileName);
                PathLocationlabel133.Text = dialog.FileName;

            }
        }

        private void SearchByIDtextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (A == 2)
                {
                    OrderDetailsdataGridView1.Rows.Clear();
                    LoadInformationInORDER_UI_textboxes();
                }
                else if (A == 3)
                {
                    Delivery_OrderDetailsdataGridView1.Rows.Clear();
                    LoadInformationInDELIVERY_UI_textboxes();
                }
                else if (A == 4)
                {
                    PAYMENT_dataGridView1.Rows.Clear();
                    LoadInformationIn_PAYMENT_UI_Textboxes();

                }
            }
            else
               {
            }
           
        }

        private void LogOutbutton1_Click(object sender, EventArgs e)
        {
            LoginUI aLoginUnit = new LoginUI(0);
            this.Hide();
            aLoginUnit.Show();
        }

        private void ADMIN_ViewDueStatusr_button1_Click(object sender, EventArgs e)
        {
            string LedgerPeriodType = ADMIN_ViewDueStatusr_comboBox1.Text;
            string StartDate = ADMIN_ViewDueStatusr_Start_dateTimePicker4.Value.ToString("yyyy-MM-dd");
            string EndDate = ADMIN_ViewDueStatusr_End_dateTimePicker3.Value.ToString("yyyy-MM-dd");
            PaymentLedgerBLL aPaymentLedgerBLL = new PaymentLedgerBLL();
            DataTable dTable = aPaymentLedgerBLL.ViewDueStatusOfSpecificDate(LedgerPeriodType, StartDate, EndDate);
            if (dTable == null)
            {
                MessageBox.Show("Please Check Information");
            }
            else
            {
                ADMIN_ViewDueStatusr_dataGridView1.DataSource = dTable;
                ADMIN_ViewDueStatusr_comboBox1.Text = "";
            }
        }

        private void ADMIN_ViewDueStatusr_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ADMIN_ViewDueStatusr_dataGridView1.DataSource = null;
            DUEstatuspanel26.Visible =false;

            if (ADMIN_ViewDueStatusr_comboBox1.Text == "Due In Specific Time Period")
            {
                DUEstatuspanel26.Visible = true;
            }
        }

        private void viewDueStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            aDMINToolStripMenuItem.BackColor = Color.Gainsboro;
            aDMINToolStripMenuItem.ForeColor = Color.Black;
            Clear_OrderUI_ALL_TextBoxes();
            MenuStripDesignOnClick(A);
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            SEARCH_panel.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            HOME_panel16.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = true;
            ADMIN_Daily_Ledger_panel16.Visible = false;
            A = 8;
        }

        private void ADMIN_ViewDueStatusr_dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ADMIN_ViewDueStatusr_dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            
            ADMIN_ViewDueStatusr_dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            ADMIN_ViewDueStatusr_dataGridView1.EnableHeadersVisualStyles = false;


            DataGridViewColumn row = ADMIN_ViewDueStatusr_dataGridView1.Columns["Due"];
            row.DefaultCellStyle.ForeColor = Color.Red;
           row.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void SEARCH_CustomerID_textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SearchAction();
            }
        }

        private void CUSTOMER_Name_textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAction();
            }
        }

        private void SEARCH_Address_textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void SEARCH_Address_textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAction();
            }
        }

        private void SEARCH_ContactNo_textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAction();
            }
        }

        private void dailyLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            aDMINToolStripMenuItem.BackColor = Color.Gainsboro;
            aDMINToolStripMenuItem.ForeColor = Color.Black;
            Clear_OrderUI_ALL_TextBoxes();
            MenuStripDesignOnClick(A);
            DELIVERY_SCHEDULE_Specific_panel14.Visible = false;
            OrderPanel_panel1.Visible = false;
            DELIVERY_panel2.Visible = false;
            pAYMENT_panel10.Visible = false;
            SEARCH_panel.Visible = false;
            DELIVERY_SCHEDULE_panel.Visible = false;
            DESIGN_Upload_panel.Visible = false;
            AdminPaswordChange_panel15.Visible = false;
            HOME_panel16.Visible = false;
            ADMIN_PAYMENTLedger_panel16.Visible = false;
            ADMIN_ViewDueStatusr_panel16.Visible = false;
            ADMIN_Daily_Ledger_panel16.Visible = true;
            A = 8;

            PaymentLedgerBLL aPaymentLedger = new PaymentLedgerBLL();
            DataTable[] dtable = aPaymentLedger.Information_in_ViewDailyLedgeerBLL();

            ADMIN_dailyLeder_Orders_dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            ADMIN_dailyLeder_Orders_dataGridView1.EnableHeadersVisualStyles = false;

            ADMIN_dailyLeder_OrderDetails_dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            ADMIN_dailyLeder_OrderDetails_dataGridView2.EnableHeadersVisualStyles = false;

            ADMIN_dailyLeder_Transection_dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            ADMIN_dailyLeder_Transection_dataGridView3.EnableHeadersVisualStyles = false;
            int OrderNo=dtable[0].Rows.Count;
            int OrderedProductsNo = dtable[1].Rows.Count;
            int TransectionsNo = dtable[2].Rows.Count;
            

            Total_Orders_label150.Text = OrderNo.ToString();
            Ordered_Products_label150.Text = OrderedProductsNo.ToString();
            Transectionlabel151.Text = TransectionsNo.ToString();
            int i = 0;
            double TotalBilled = 0, TotalBilledDue = 0,Totaladvance=0;
            double a,b,c,CheckNullPayment=0;

            while (i < OrderNo )
            {
                a = double.Parse(dtable[0].Rows[i][3].ToString());
                b= double.Parse(dtable[0].Rows[i][4].ToString());
                c = double.Parse(dtable[0].Rows[i][5].ToString());
                Totaladvance = Totaladvance + c;
                TotalBilledDue = TotalBilledDue + b;
                TotalBilled = TotalBilled + a;
                i++;

            }
                try
            {
                double.TryParse(dtable[3].Rows[0][0].ToString().ToString(), out CheckNullPayment);
                TotalPaymentlabel157.Text = CheckNullPayment.ToString();
                TotalGoldlabel156.Text = dtable[4].Rows[0][0].ToString();
                DepositedGoldlabel160.Text = dtable[4].Rows[0][1].ToString();
                TotalSilverlabel158.Text = dtable[5].Rows[0][0].ToString();
                DepositedSilverlabel163.Text = dtable[5].Rows[0][1].ToString();

                double.TryParse(dtable[3].Rows[0][0].ToString().ToString(), out CheckNullPayment);
                TotalTransection_label155.Text = (Totaladvance + CheckNullPayment).ToString();
                TotalAdvanceCollected_label156.Text = Totaladvance.ToString();
                Total_Billed_Due_label155.Text = TotalBilledDue.ToString();
                Total_Billed_label154.Text = TotalBilled.ToString();
            }
            catch
            {
                TotalPaymentlabel157.Text =0.ToString();
                TotalGoldlabel156.Text = 0.ToString();
                TotalSilverlabel158.Text = 0.ToString();
                TotalSilverlabel158.Text = 0.ToString();
                TotalTransection_label155.Text = 0.ToString();
                TotalAdvanceCollected_label156.Text = 0.ToString();
                Total_Billed_Due_label155.Text = 0.ToString();
                Total_Billed_label154.Text = 0.ToString();
            } 
           
                ADMIN_dailyLeder_Orders_dataGridView1.DataSource = dtable[0];
            ADMIN_dailyLeder_OrderDetails_dataGridView2.DataSource = dtable[1];
            ADMIN_dailyLeder_Transection_dataGridView3.DataSource = dtable[2];
        }
    }
} 
