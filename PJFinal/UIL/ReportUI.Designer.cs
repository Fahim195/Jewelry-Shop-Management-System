namespace PJFinal.UIL
{
    partial class ReportUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerBillingSlip_crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CustomerBillingSlip_crystalReportViewer1
            // 
            this.CustomerBillingSlip_crystalReportViewer1.ActiveViewIndex = -1;
            this.CustomerBillingSlip_crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomerBillingSlip_crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CustomerBillingSlip_crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerBillingSlip_crystalReportViewer1.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerBillingSlip_crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.CustomerBillingSlip_crystalReportViewer1.Name = "CustomerBillingSlip_crystalReportViewer1";
            this.CustomerBillingSlip_crystalReportViewer1.Size = new System.Drawing.Size(1345, 669);
            this.CustomerBillingSlip_crystalReportViewer1.TabIndex = 0;
            this.CustomerBillingSlip_crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1345, 669);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1345, 669);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.CustomerBillingSlip_crystalReportViewer1);
            this.Name = "ReportUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing Slip";
            this.Load += new System.EventHandler(this.ReportUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CustomerBillingSlip_crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}