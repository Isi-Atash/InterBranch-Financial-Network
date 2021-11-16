namespace ExpressTr
{
    partial class FrmAddCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddCustomer));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnContractOk = new DevExpress.XtraEditors.SimpleButton();
            this.lblSerialNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblDocType = new DevExpress.XtraEditors.LabelControl();
            this.lkUpDocType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPhySerialNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtPhySerial = new DevExpress.XtraEditors.TextEdit();
            this.lblFatherName = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblSurname = new DevExpress.XtraEditors.LabelControl();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtFname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhyPin = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.rbNonResident = new System.Windows.Forms.RadioButton();
            this.rbResident = new System.Windows.Forms.RadioButton();
            this.dtGivenDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkUpDocPlace = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lkUpDocType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhySerialNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhySerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhyPin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGivenDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGivenDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUpDocPlace.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(239, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 29);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "Bağla";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnContractOk
            // 
            this.btnContractOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContractOk.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContractOk.Appearance.Options.UseFont = true;
            this.btnContractOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnContractOk.Image = ((System.Drawing.Image)(resources.GetObject("btnContractOk.Image")));
            this.btnContractOk.Location = new System.Drawing.Point(122, 235);
            this.btnContractOk.Name = "btnContractOk";
            this.btnContractOk.Size = new System.Drawing.Size(111, 29);
            this.btnContractOk.TabIndex = 70;
            this.btnContractOk.Text = "Yaddaşa yaz";
            this.btnContractOk.Click += new System.EventHandler(this.btnContractOk_Click);
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.Location = new System.Drawing.Point(4, 120);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(55, 16);
            this.lblSerialNumber.TabIndex = 140;
            this.lblSerialNumber.Text = "Seriya №";
            // 
            // lblDocType
            // 
            this.lblDocType.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocType.Location = new System.Drawing.Point(4, 97);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(77, 16);
            this.lblDocType.TabIndex = 138;
            this.lblDocType.Text = "Sənədin növü";
            // 
            // lkUpDocType
            // 
            this.lkUpDocType.Location = new System.Drawing.Point(107, 95);
            this.lkUpDocType.Name = "lkUpDocType";
            this.lkUpDocType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkUpDocType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DOC_ID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DOC_NAME", "Sənədin növü")});
            this.lkUpDocType.Properties.NullText = "";
            this.lkUpDocType.Size = new System.Drawing.Size(239, 20);
            this.lkUpDocType.TabIndex = 130;
            this.lkUpDocType.EditValueChanged += new System.EventHandler(this.lkUpDocType_EditValueChanged);
            // 
            // txtPhySerialNumber
            // 
            this.txtPhySerialNumber.Location = new System.Drawing.Point(166, 118);
            this.txtPhySerialNumber.Name = "txtPhySerialNumber";
            this.txtPhySerialNumber.Properties.Mask.BeepOnError = true;
            this.txtPhySerialNumber.Properties.Mask.EditMask = "[a-zA-Z]+";
            this.txtPhySerialNumber.Properties.MaxLength = 8;
            this.txtPhySerialNumber.Size = new System.Drawing.Size(181, 20);
            this.txtPhySerialNumber.TabIndex = 133;
            // 
            // txtPhySerial
            // 
            this.txtPhySerial.Location = new System.Drawing.Point(107, 118);
            this.txtPhySerial.Name = "txtPhySerial";
            this.txtPhySerial.Properties.Mask.EditMask = "[A-Z][A-Z][A-Z]";
            this.txtPhySerial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPhySerial.Properties.MaxLength = 3;
            this.txtPhySerial.Size = new System.Drawing.Size(53, 20);
            this.txtPhySerial.TabIndex = 132;
            // 
            // lblFatherName
            // 
            this.lblFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFatherName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFatherName.Location = new System.Drawing.Point(4, 51);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(40, 16);
            this.lblFatherName.TabIndex = 157;
            this.lblFatherName.Text = "Ata adı";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(4, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(15, 16);
            this.lblName.TabIndex = 156;
            this.lblName.Text = "Ad";
            // 
            // lblSurname
            // 
            this.lblSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSurname.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(4, 5);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(35, 16);
            this.lblSurname.TabIndex = 155;
            this.lblSurname.Text = "Soyad";
            // 
            // txtSurname
            // 
            this.txtSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSurname.Location = new System.Drawing.Point(107, 3);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
            this.txtSurname.Properties.Mask.EditMask = "\\p{Lu}+";
            this.txtSurname.Properties.Mask.IgnoreMaskBlank = false;
            this.txtSurname.Properties.Mask.ShowPlaceHolders = false;
            this.txtSurname.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSurname.Properties.MaxLength = 100;
            this.txtSurname.Size = new System.Drawing.Size(239, 20);
            this.txtSurname.TabIndex = 149;
            this.txtSurname.EditValueChanged += new System.EventHandler(this.txtSurname_EditValueChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(107, 26);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Mask.EditMask = "\\p{Lu}+";
            this.txtName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtName.Properties.MaxLength = 100;
            this.txtName.Size = new System.Drawing.Size(239, 20);
            this.txtName.TabIndex = 150;
            this.txtName.EditValueChanged += new System.EventHandler(this.txtName_EditValueChanged);
            // 
            // txtFname
            // 
            this.txtFname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFname.Location = new System.Drawing.Point(107, 49);
            this.txtFname.Name = "txtFname";
            this.txtFname.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
            this.txtFname.Properties.Mask.EditMask = "\\p{Lu}+";
            this.txtFname.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFname.Properties.MaxLength = 100;
            this.txtFname.Size = new System.Drawing.Size(239, 20);
            this.txtFname.TabIndex = 151;
            this.txtFname.EditValueChanged += new System.EventHandler(this.txtFatherName_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(3, 143);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 16);
            this.labelControl1.TabIndex = 159;
            this.labelControl1.Text = "Pinkod";
            // 
            // txtPhyPin
            // 
            this.txtPhyPin.Location = new System.Drawing.Point(106, 141);
            this.txtPhyPin.Name = "txtPhyPin";
            this.txtPhyPin.Properties.Mask.EditMask = "[0-9A-Z]*";
            this.txtPhyPin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPhyPin.Properties.MaxLength = 7;
            this.txtPhyPin.Size = new System.Drawing.Size(239, 20);
            this.txtPhyPin.TabIndex = 158;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(107, 72);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Mask.EditMask = "\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}";
            this.txtPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPhone.Size = new System.Drawing.Size(239, 20);
            this.txtPhone.TabIndex = 161;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(4, 76);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(41, 13);
            this.labelControl11.TabIndex = 160;
            this.labelControl11.Text = "Mobil Tel";
            // 
            // rbNonResident
            // 
            this.rbNonResident.AutoSize = true;
            this.rbNonResident.Location = new System.Drawing.Point(166, 212);
            this.rbNonResident.Name = "rbNonResident";
            this.rbNonResident.Size = new System.Drawing.Size(89, 17);
            this.rbNonResident.TabIndex = 163;
            this.rbNonResident.Text = "Qeyri-rezident";
            this.rbNonResident.UseVisualStyleBackColor = true;
            // 
            // rbResident
            // 
            this.rbResident.AutoSize = true;
            this.rbResident.Checked = true;
            this.rbResident.Location = new System.Drawing.Point(95, 212);
            this.rbResident.Name = "rbResident";
            this.rbResident.Size = new System.Drawing.Size(67, 17);
            this.rbResident.TabIndex = 162;
            this.rbResident.TabStop = true;
            this.rbResident.Text = "Rezident";
            this.rbResident.UseVisualStyleBackColor = true;
            // 
            // dtGivenDate
            // 
            this.dtGivenDate.EditValue = null;
            this.dtGivenDate.Location = new System.Drawing.Point(106, 187);
            this.dtGivenDate.Name = "dtGivenDate";
            this.dtGivenDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGivenDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGivenDate.Size = new System.Drawing.Size(239, 20);
            this.dtGivenDate.TabIndex = 164;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(4, 189);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 16);
            this.labelControl2.TabIndex = 165;
            this.labelControl2.Text = "Verildiyi tarix";
            // 
            // lkUpDocPlace
            // 
            this.lkUpDocPlace.Location = new System.Drawing.Point(106, 164);
            this.lkUpDocPlace.Name = "lkUpDocPlace";
            this.lkUpDocPlace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkUpDocPlace.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lkUpDocPlace.Properties.DropDownRows = 10;
            this.lkUpDocPlace.Properties.NullText = "";
            this.lkUpDocPlace.Size = new System.Drawing.Size(239, 20);
            this.lkUpDocPlace.TabIndex = 166;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl7.Location = new System.Drawing.Point(3, 166);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(71, 16);
            this.labelControl7.TabIndex = 167;
            this.labelControl7.Text = "Verən organ";
            // 
            // FrmAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 269);
            this.Controls.Add(this.lkUpDocPlace);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dtGivenDate);
            this.Controls.Add(this.rbNonResident);
            this.Controls.Add(this.rbResident);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPhyPin);
            this.Controls.Add(this.lblFatherName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.lblSerialNumber);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.lkUpDocType);
            this.Controls.Add(this.txtPhySerialNumber);
            this.Controls.Add(this.txtPhySerial);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContractOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üçüncü şəxsin əlavə olunması";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAddCustomer_FormClosing);
            this.Load += new System.EventHandler(this.FrmAddCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkUpDocType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhySerialNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhySerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhyPin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGivenDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGivenDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkUpDocPlace.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton btnContractOk;
        private DevExpress.XtraEditors.LabelControl lblSerialNumber;
        private DevExpress.XtraEditors.LabelControl lblDocType;
        private DevExpress.XtraEditors.LabelControl lblFatherName;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblSurname;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        internal System.Windows.Forms.RadioButton rbNonResident;
        internal System.Windows.Forms.RadioButton rbResident;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.LookUpEdit lkUpDocPlace;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        internal DevExpress.XtraEditors.DateEdit dtGivenDate;
        internal DevExpress.XtraEditors.LookUpEdit lkUpDocType;
        internal DevExpress.XtraEditors.TextEdit txtPhySerialNumber;
        internal DevExpress.XtraEditors.TextEdit txtPhySerial;
        internal DevExpress.XtraEditors.TextEdit txtSurname;
        internal DevExpress.XtraEditors.TextEdit txtName;
        internal DevExpress.XtraEditors.TextEdit txtFname;
        internal DevExpress.XtraEditors.TextEdit txtPhyPin;
    }
}