using PJFinal.BLL;
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
    public partial class DesignGallery : Form
    {
        DataTable dTable = null;
        int TotalDEsigns = 0;
        List<int> designPages =new List<int> ();
        int designSerialSTART = 0;
        int designSerialEnd = 0;
        int i = 0;
        int j = 0;
        int k = 0;
        PictureBox[] imagePointer = new PictureBox[24];
        Label[] LabelPointer = new Label[24];
        int CurrentpAgeNo = 1;
        public void Initialize_LABEL_InArray()
        {
            LabelPointer[0] = label1;
            LabelPointer[1] = label2;
            LabelPointer[2] = label3;
            LabelPointer[3] = label4;
            LabelPointer[4] = label5;
            LabelPointer[5] = label6;
            LabelPointer[6] = label7;
            LabelPointer[7] = label8;

            LabelPointer[8] = label9;
            LabelPointer[9] = label10;
            LabelPointer[10] = label11;
            LabelPointer[11] = label12;
            LabelPointer[12] = label13;
            LabelPointer[13] = label14;
            LabelPointer[14] = label15;
            LabelPointer[15] = label16;

            LabelPointer[16] = label17;
            LabelPointer[17] = label18;
            LabelPointer[18] = label19;
            LabelPointer[19] = label20;
            LabelPointer[20] = label21;
            LabelPointer[21] = label22;
            LabelPointer[22] = label23;
            LabelPointer[23] = label24;


        }
        public void InitializePictureboxInArray()
        {
            imagePointer[0] = pictureBox1;
            imagePointer[1] = pictureBox2;
            imagePointer[2] = pictureBox3;
            imagePointer[3] = pictureBox4;
            imagePointer[4] = pictureBox5;
            imagePointer[5] = pictureBox6;
            imagePointer[6] = pictureBox7;
            imagePointer[7] = pictureBox8;
            imagePointer[8] = pictureBox9;
            imagePointer[9] = pictureBox10;
            imagePointer[10] = pictureBox11;
            imagePointer[11] = pictureBox12;
            imagePointer[12] = pictureBox13;
            imagePointer[13] = pictureBox14;
            imagePointer[14] = pictureBox15;
            imagePointer[15] = pictureBox16;
            imagePointer[16] = pictureBox17;
            imagePointer[17] = pictureBox18;
            imagePointer[18] = pictureBox19;
            imagePointer[19] = pictureBox20;
            imagePointer[20] = pictureBox21;
            imagePointer[21] = pictureBox22;
            imagePointer[22] = pictureBox23;
            imagePointer[23] = pictureBox24;
            
        }
       
        public DesignGallery(int A)
        {
            
            InitializeComponent();
            DESIGN_Gallery_button1.Enabled = false;
            if (A==2)
            {
                DESIGN_Gallery_button1.Enabled = true;
            }
            InitializePictureboxInArray();
            Initialize_LABEL_InArray();
            DesignBLL aDesignBLL = new DesignBLL();
            dTable = aDesignBLL.GetDesignIn_GalleryBLLL();
            TotalDEsigns = dTable.Rows.Count;
            while (j< TotalDEsigns)
            {
                designPages.Add(j);               
                j = j + 24;
            }
            
            designPages.Add(TotalDEsigns);
            i = 0;
            LoadDesignsInPicturebox(designPages.ElementAt(i),designPages.ElementAt(i + 1));
            TotalPageNo_Label.Text =(designPages.Count-1).ToString();
            CurrentPageNo_Label.Text = CurrentpAgeNo.ToString();

        }
        public void ErsePicBox()
        {
            j = 0;
            while (j<24)
            {  
                imagePointer[j].Image =null;
                LabelPointer[j].Text = "";
                j = j + 1;   
            }
        }       
        public void LoadDesignsInPicturebox(int strt,int end)
        {
            try
            {
                int designSerialSTART = strt;
                int designSerialEnd = end;
                j = 0;
                while (designSerialSTART < designSerialEnd)
                {
                    byte[] images = ((byte[])(dTable.Rows[i][3]));
                    
                    MemoryStream mStream = new MemoryStream(images);
                    imagePointer[j].Image = Image.FromStream(mStream);
                    LabelPointer[j].Text = dTable.Rows[i][0].ToString();
                    designSerialSTART = designSerialSTART + 1;
                    j = j + 1;
                    i = i + 1;
                }
                TotalPageNo_Label.Text = (designPages.Count - 1).ToString();
                CurrentPageNo_Label.Text = CurrentpAgeNo.ToString();
            }
            catch
            {

            }
            
            
        }       
        private void DesignGallery_Load(object sender, EventArgs e)
        {

        }
        
        private void DESIGN_Gallery_Next_button3_Click(object sender, EventArgs e)
        {
            ErsePicBox();
                k = k + 1;
                try
                {
                CurrentpAgeNo = CurrentpAgeNo + 1;
                LoadDesignsInPicturebox(designPages.ElementAt(k), designPages.ElementAt(k + 1));
                
                }
                catch
                {
                    k = 0;
                    i = 0;
                CurrentpAgeNo = 1;
                LoadDesignsInPicturebox(designPages.ElementAt(k), designPages.ElementAt(k + 1));
                
            }
                
          


        }

        private void DESIGN_Gallery_Previous_button2_Click(object sender, EventArgs e)
        {
            ErsePicBox();
            CurrentpAgeNo = CurrentpAgeNo - 1;
            if (k<=0)
            {
                k = 1;
                CurrentpAgeNo = 1;
            }
            if (CurrentpAgeNo < 0)
            {
                CurrentpAgeNo = 1;
            }

           
                i = 0;
            
            LoadDesignsInPicturebox(designPages.ElementAt(k - 1), designPages.ElementAt(k));
                k = k - 1;
            
            
        }
        public void ViewDetailsofDESIGNS(int DID)
        {
            DataRow[] filteredRows = dTable.Select("DID="+DID+"");
            DID_label28.Text = DID.ToString();
            DesignCost_label30.Text = filteredRows[0][1].ToString();
            lCategory_abel29.Text= filteredRows[0][2].ToString();
            byte[] images = ((byte[])(filteredRows[0][3]));

            MemoryStream mStream = new MemoryStream(images);
            Detailed_pictureBox25.Image = Image.FromStream(mStream);



        }
        private void DESIGN_Gallery_button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int DesignID = 0;
        private void PicBox_button1_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label1.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button2_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label2.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button3_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label3.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button4_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label4.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button5_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label5.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button6_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label6.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button7_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label7.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button8_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label8.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button9_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label9.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button10_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label10.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button11_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label11.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button12_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label12.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button13_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label13.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button14_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label14.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button15_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label15.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button16_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label16.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button17_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label17.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button18_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label18.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button19_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label9.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button20_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label20.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button21_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label21.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button22_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label22.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button23_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label23.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void PicBox_button24_Click(object sender, EventArgs e)
        {
            DesignID = int.Parse(label24.Text);
            ViewDetailsofDESIGNS(DesignID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel50_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
