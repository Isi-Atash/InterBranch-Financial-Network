namespace ExpressTr
{
    partial class FrmAddMT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddMT));
            this.grp_info = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnCtrlUsrInfo = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTransferType = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.grpSign = new DevExpress.XtraEditors.GroupControl();
            this.sbRefund = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grp_info)).BeginInit();
            this.grp_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnCtrlUsrInfo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransferType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSign)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_info
            // 
            this.grp_info.Controls.Add(this.panelControl1);
            this.grp_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_info.Location = new System.Drawing.Point(0, 0);
            this.grp_info.Name = "grp_info";
            this.grp_info.Size = new System.Drawing.Size(562, 554);
            this.grp_info.TabIndex = 7;
            this.grp_info.Text = "Köçürmə";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pnCtrlUsrInfo);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(558, 532);
            this.panelControl1.TabIndex = 1;
            // 
            // pnCtrlUsrInfo
            // 
            this.pnCtrlUsrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCtrlUsrInfo.Location = new System.Drawing.Point(2, 45);
            this.pnCtrlUsrInfo.Name = "pnCtrlUsrInfo";
            this.pnCtrlUsrInfo.Size = new System.Drawing.Size(554, 443);
            this.pnCtrlUsrInfo.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbTransferType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 43);
            this.panel1.TabIndex = 0;
            // 
            // cmbTransferType
            // 
            this.cmbTransferType.Location = new System.Drawing.Point(104, 10);
            this.cmbTransferType.Name = "cmbTransferType";
            this.cmbTransferType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbTransferType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTransferType.Properties.NullText = "";
            this.cmbTransferType.Size = new System.Drawing.Size(199, 20);
            this.cmbTransferType.TabIndex = 10;
            this.cmbTransferType.EditValueChanged += new System.EventHandler(this.cmbTransferType_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Köçürmənin növü";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sbRefund);
            this.panelControl2.Controls.Add(this.sbOK);
            this.panelControl2.Controls.Add(this.sbClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 488);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(554, 42);
            this.panelControl2.TabIndex = 5;
            // 
            // sbOK
            // 
            this.sbOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbOK.Enabled = false;
            this.sbOK.Image = ((System.Drawing.Image)(resources.GetObject("sbOK.Image")));
            this.sbOK.Location = new System.Drawing.Point(360, 2);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(107, 38);
            this.sbOK.TabIndex = 18;
            this.sbOK.Tag = "ok";
            this.sbOK.Text = "Yaddaşa yaz";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbClose
            // 
            this.sbClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbClose.Image = ((System.Drawing.Image)(resources.GetObject("sbClose.Image")));
            this.sbClose.Location = new System.Drawing.Point(467, 2);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(85, 38);
            this.sbClose.TabIndex = 19;
            this.sbClose.Text = "Bağla";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // grpSign
            // 
            this.grpSign.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpSign.Location = new System.Drawing.Point(562, 0);
            this.grpSign.Name = "grpSign";
            this.grpSign.Size = new System.Drawing.Size(366, 554);
            this.grpSign.TabIndex = 6;
            this.grpSign.Text = "İmzalama";
            // 
            // sbRefund
            // 
            this.sbRefund.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbRefund.Enabled = false;
            this.sbRefund.Image = ((System.Drawing.Image)(resources.GetObject("sbRefund.Image")));
            this.sbRefund.Location = new System.Drawing.Point(254, 2);
            this.sbRefund.Name = "sbRefund";
            this.sbRefund.Size = new System.Drawing.Size(106, 38);
            this.sbRefund.TabIndex = 20;
            this.sbRefund.Text = "Geri Göndər";
            this.sbRefund.Visible = false;
            this.sbRefund.Click += new System.EventHandler(this.sbRefund_Click);
            // 
            // FrmAddMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 554);
            this.Controls.Add(this.grp_info);
            this.Controls.Add(this.grpSign);
            this.Name = "FrmAddMT";
            this.Text = "FrmAddMT";
            this.Load += new System.EventHandler(this.FrmAddMT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grp_info)).EndInit();
            this.grp_info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnCtrlUsrInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransferType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSign)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grp_info;
        private DevExpress.XtraEditors.GroupControl grpSign;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl pnCtrlUsrInfo;
        private System.Windows.Forms.Panel panel1;
        internal DevExpress.XtraEditors.LookUpEdit cmbTransferType;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        internal DevExpress.XtraEditors.SimpleButton sbOK;
        internal DevExpress.XtraEditors.SimpleButton sbRefund;
    }
}