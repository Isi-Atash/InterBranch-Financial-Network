namespace ExpressTr
{
    partial class FrmCipher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCipher));
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtCipher = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCipher.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Şifrə";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sbOK);
            this.panelControl2.Controls.Add(this.sbClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 42);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(310, 30);
            this.panelControl2.TabIndex = 6;
            // 
            // sbOK
            // 
            this.sbOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbOK.Image = ((System.Drawing.Image)(resources.GetObject("sbOK.Image")));
            this.sbOK.Location = new System.Drawing.Point(138, 2);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(85, 26);
            this.sbOK.TabIndex = 18;
            this.sbOK.Text = "Təsdiq et";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbClose
            // 
            this.sbClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbClose.Image = ((System.Drawing.Image)(resources.GetObject("sbClose.Image")));
            this.sbClose.Location = new System.Drawing.Point(223, 2);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(85, 26);
            this.sbClose.TabIndex = 19;
            this.sbClose.Text = "Bağla";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // txtCipher
            // 
            this.txtCipher.Location = new System.Drawing.Point(45, 13);
            this.txtCipher.Name = "txtCipher";
            this.txtCipher.Properties.Mask.EditMask = "\\d+";
            this.txtCipher.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCipher.Size = new System.Drawing.Size(245, 20);
            this.txtCipher.TabIndex = 7;
            // 
            // FrmCipher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 72);
            this.Controls.Add(this.txtCipher);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCipher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifrə";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCipher.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraEditors.TextEdit txtCipher;
    }
}