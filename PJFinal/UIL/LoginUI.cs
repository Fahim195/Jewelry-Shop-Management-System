using PJFinal.BLL;
using PJFinal.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJFinal.UIL
{
    public partial class LoginUI : Form
    {
        int temp = 0;
        DataTable dt = null;
        public LoginUI(int A)
        {
            InitializeComponent();
            temp = A;
        }
        public int UIDefiner = 0;
        private void LoginUI_Enter_button1_Click(object sender, EventArgs e)
        {
            SystemAccess aSystemAcces = new SystemAccess();

            if (dt.Rows[0][0].ToString() != LoginUI_UserNametextBox2.Text || dt.Rows[0][1].ToString() != LoginUI_Password_textBox1.Text)
            {
                rongUserAccess_Notification_label135.Text = "Wrong 'UserName' OR 'Password' ";
            }
            else
            {
                if (temp == 8)
                {
                    UIDefiner = temp;
                    this.Close();
                }
                else
                {
                    MainUnit aMainUnit = new MainUnit();
                    aMainUnit.Show();
                    this.Hide();

                }
            }
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {
            
            string userName = System.Environment.UserName;
            try
            {
                if (File.ReadAllText(@"C:\Users\" + userName + @"\Documents\DataSource.txt") != "")
                {
                    srvrs_addresspanel20.Visible = false;
                    SystemAccessBLL aSyatemAccessBLL = new SystemAccessBLL();
                    dt = aSyatemAccessBLL.CheckSystemAccessBLL();
                    this.ActiveControl = LoginUI_UserNametextBox2;
                    
                }
            }
            catch
            {
               
                srvrs_addresspanel20.Visible = true;
                this.ActiveControl = SQLServer_adreress_textBox1;

            }

        }

        private void LoginUI_UserNametextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SystemAccess aSystemAcces = new SystemAccess();

                if (dt.Rows[0][0].ToString() != LoginUI_UserNametextBox2.Text || dt.Rows[0][1].ToString() != LoginUI_Password_textBox1.Text)
                {
                    rongUserAccess_Notification_label135.Text = "Wrong 'UserName' OR 'Password' ";
                }
                else
                {
                    if (temp == 8)
                    {
                        UIDefiner = temp;
                        this.Close();
                    }
                    else
                    {
                        MainUnit aMainUnit = new MainUnit();
                        aMainUnit.Show();
                        this.Hide();

                    }
                }
            }
            else
            {

            }
        }

        private void AttachDatabaseAddressbutton9_Click(object sender, EventArgs e)
        {
            string userName = System.Environment.UserName;
            if (SQLServer_adreress_textBox1.ToString().Contains(@"\SQLEXPRESS"))
            {
                File.WriteAllText(@"C:\Users\" + userName + @"\Documents\DataSource.txt", SQLServer_adreress_textBox1.Text);
                MessageBox.Show("Database Server Address successfully saved");
                SystemAccessBLL aSyatemAccessBLL = new SystemAccessBLL();
                dt = aSyatemAccessBLL.CheckSystemAccessBLL();
                srvrs_addresspanel20.Visible = false;
                Loginpanel2.Visible = true;
                panel1.Visible = true;

            }
            else
            {
                SQLServer_adreress_textBox1.Text = "";
                MessageBox.Show("Insert Correcr SQL Server Address");
            }

        }

        private void LoginUI_Clear_button2_Click(object sender, EventArgs e)
        {
            LoginUI_UserNametextBox2.Text = "";
            LoginUI_Password_textBox1.Text = "";
        }

        private void SQLServer_adreress_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string userName = System.Environment.UserName;
                if (SQLServer_adreress_textBox1.ToString().Contains(@"\SQLEXPRESS"))
                {
                    File.WriteAllText(@"C:\Users\" + userName + @"\Documents\DataSource.txt", SQLServer_adreress_textBox1.Text);
                    MessageBox.Show("Database Server Address successfully saved");
                    SystemAccessBLL aSyatemAccessBLL = new SystemAccessBLL();
                    dt = aSyatemAccessBLL.CheckSystemAccessBLL();
                    srvrs_addresspanel20.Visible = false;
                   
                }
                else
                {
                    SQLServer_adreress_textBox1.Text = "";
                    MessageBox.Show("Insert Correcr SQL Server Address");
                }
            }
        }
    }
}
