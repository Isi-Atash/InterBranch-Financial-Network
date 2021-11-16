using DevExpress.XtraGrid.Views.Grid;
using ExpressTr.Data;
using ExpressTr.Helpers;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TbCommon;
using static ExpressTr.Helpers.EnumTypes;

namespace ExpressTr
{
    public partial class UsrExpressNoUser : UserControl
    {
        ExpressDao exDao = new ExpressDao();
        ClssComMethod clsMethod = new ClssComMethod();
        CommonMethos comMethod = new CommonMethos();

        int _opId { get; set; } = -1;
        PageMode _pageMode;

        public UsrExpressNoUser(PageMode pageMode, int opId = -1)
        {
            InitializeComponent();

            _pageMode = pageMode;
            _opId = opId;
        }

        private void UsrExpressNoUser_Load(object sender, EventArgs e)
        {
            FillLookUpEdit();

            if (_pageMode == PageMode.Add)
            {
                CrControlsWhenMt();
                btnNext.Visible = true;
            }
            else if (_pageMode == PageMode.Edit)
            {
                tpgCrUser.PageVisible = true;
                btnNext.Visible = true;
                FillAllInfo();
            }
            else if (_pageMode == PageMode.Sign)
            {
                tpgCrUser.PageVisible = true;
                btnNext.Visible = true;

                PermissionRecieverCustInfo(false);
            }
            else if (_pageMode == PageMode.View)
            {
                tpgCrUser.PageVisible = true;
                btnNext.Visible = true;

                PermissionRecieverCustInfo(false);
            }

            cmbDescription.EditValue = 5m;

            if (_opId != -1)
            {
                FillAllInfo();
            }
        }

        private void FillAllInfo()
        {
            int dtCustId;
            DataTable dtMtInfo = new DataTable();
            DataTable dtCustInfo = exDao.GetCustInfo(custId:);
        }

        private void FillLookUpEdit()
        {
            GetDocType(lkUpDocType);
            GetDocType(cmbSDocType);

            GetCurrency(cmbCurrency);

            GetBranch(cmbBranch);
            cmbBranch.EditValue = Convert.ToDecimal(ClssUserInfo.Branch_Id);
            cmbBranch.ReadOnly = true;

            GetSBranchNew(cmbSBranch, -10);
            cmbSBranch.EditValue = -1m;

            GetMTDescription(cmbDescription);

            GetSphonepref();
        }

        private void CrControlsWhenMt()
        {
            tpgCrUser.PageVisible = false;
            rbResident.Checked = true;
            cmbSDocType.ReadOnly = false;
            txtSPincode.Enabled = false;
            txtSDocnumber.Enabled = false;
            txtSDocserial.Enabled = false;
            cmbSDocPlace.Enabled = false;
            dtSGivenDate.Enabled = false;
            txtPhySerial.Enabled = false;
            txtPhySerialNumber.Enabled = false;
            txtPhyPin.Enabled = false;
            txtSCustomer.Enabled = false;
            cmbSDocType.Enabled = false;
            lblPermRec_Serial.Visible = false;
            lblPermRec_DocPlace.Visible = false;
            lblPermRec_DocGDate.Visible = false;

            comMethod.SetReadonlyControls(gr_otherinfo.Controls);
        }

        private void SetRecieverDocInfoReadonly()
        {
            txtSPhone.ReadOnly = false;
            cmbSDocType.ReadOnly = false;
            txtSPincode.ReadOnly = false;
            txtSDocserial.ReadOnly = false;
            txtSDocnumber.ReadOnly = false;
            cmbSDocPlace.ReadOnly = false;
            dtSGivenDate.ReadOnly = false;
            dtSExpireDate.ReadOnly = false;
            cmbSBranch.ReadOnly = false;
            rbSResident.Enabled = true;
            rbSNonResident.Enabled = true;
        }

        private void PermissionRecieverCustInfo(bool _value)
        {
            lblPermRec_Tel.Visible = _value;
            lblPermRec_DocType.Visible = _value;
            lblPermRec_Serial.Visible = _value;
            lblPermRec_DocPlace.Visible = _value;
            lblPermRec_DocGDate.Visible = _value;
            lblPermRec_DocExDate.Visible = _value;
        }

        private void cmbCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmCustCommonSearchAll frmCustCommonSearchAll = new FrmCustCommonSearchAll("");
            frmCustCommonSearchAll.ShowDialog();
            GetSelectedCustomer(frmCustCommonSearchAll);
        }

        private void GetSelectedCustomer(FrmCustCommonSearchAll frmCustCommonSearchAll)
        {
            if (frmCustCommonSearchAll.Tag != null && frmCustCommonSearchAll.Tag.ToString() == "select")
            {
                GridView grdView = frmCustCommonSearchAll.grdVwCustomer;
                txtCustomer.Text = grdView.GetFocusedRowCellValue("CUST_ID").ToString();
                cmbCustomer.Text = grdView.GetFocusedRowCellValue("FULL_NAME").ToString();
            }
        }

        private void cmbSCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmCustCommonSearchAll frmCustCommonSearchAll = new FrmCustCommonSearchAll("");
            frmCustCommonSearchAll.ShowDialog();
            GetSelectedSCustomer(frmCustCommonSearchAll);
        }

        private void GetSelectedSCustomer(FrmCustCommonSearchAll frmCustCommonSearchAll)
        {
            if (frmCustCommonSearchAll.Tag != null && frmCustCommonSearchAll.Tag.ToString() == "select")
            {
                GridView grdView = frmCustCommonSearchAll.grdVwCustomer;
                txtSCustomer.Text = grdView.GetFocusedRowCellValue("CUST_ID").ToString();
                cmbSCustomer.Text = grdView.GetFocusedRowCellValue("FULL_NAME").ToString();
            }
        }

        void GetDocPlace(DevExpress.XtraEditors.LookUpEdit cmb, int docType)
        {
            DataTable dt = exDao.GetDocPlace(docType);
            if (dt.Equals(DBNull.Value))
                return;

            cmb.Properties.DataSource = dt;
            cmb.Properties.ValueMember = "ID";
            cmb.Properties.DisplayMember = "PLACE_NAME";
            cmb.Properties.ForceInitialize();
            cmb.Properties.PopulateColumns();
            cmb.Properties.Columns[0].Visible = false;
            cmb.Properties.Columns[0].Caption = "table_ID";
            cmb.Properties.Columns[1].Visible = false;
            cmb.Properties.Columns[1].Caption = "Sənədin ID";
            cmb.Properties.Columns[2].Caption = "Verən organ";
        }

        void GetDocType(DevExpress.XtraEditors.LookUpEdit cmb)
        {
            DataTable dt = exDao.GetDocType();
            if (dt.Equals(DBNull.Value))
                return;

            cmb.Properties.DataSource = dt;
            cmb.Properties.ValueMember = "ID";
            cmb.Properties.DisplayMember = "NAME";
            cmb.Properties.ForceInitialize();
            cmb.Properties.PopulateColumns();
            cmb.Properties.Columns["ID"].Visible = false;
            cmb.Properties.Columns["ID"].Caption = "Sənədin ID";
            cmb.Properties.Columns["NAME"].Caption = "Sənədin adı";
        }

        void GetCurrency(DevExpress.XtraEditors.LookUpEdit cmb)
        {
            DataTable dt = exDao.GetCurrency();
            if (dt.Equals(DBNull.Value))
                return;

            cmb.Properties.DataSource = dt;
            cmb.Properties.ValueMember = "CUR_CODE";
            cmb.Properties.DisplayMember = "SHORT_NAME";
            cmb.Properties.ForceInitialize();
            cmb.Properties.PopulateColumns();

            cmb.Properties.Columns[0].Visible = false;
            cmb.Properties.Columns[0].Caption = "Valyuta kodu";
            cmb.Properties.Columns[1].Caption = "Qısa adı";
            cmb.Properties.Columns[2].Caption = "Valyuta adı";
        }

        public void GetBranch(DevExpress.XtraEditors.LookUpEdit cmb)
        {
            DataTable dt = exDao.GetBranch();
            if (dt.Equals(DBNull.Value))
                return;

            cmb.Properties.DataSource = dt;
            cmb.Properties.DisplayMember = "BRANCH_NAME";
            cmb.Properties.ValueMember = "BRANCH_ID";
            cmb.Properties.ForceInitialize();
            cmb.Properties.PopulateColumns();
            cmb.Properties.Columns[0].Visible = false;
            cmb.Properties.Columns[1].Caption = "Filial";
            cmb.EditValue = null;
        }

        public void GetSBranchNew(DevExpress.XtraEditors.LookUpEdit cmb, int filter)
        {
            DataTable dt = exDao.GetBranch(filter);
            if (dt.Equals(DBNull.Value))
                return;

            DataRow dr = dt.NewRow();
            dr["BRANCH_ID"] = "-1";
            dr["BRANCH_NAME"] = "Bütün filiallar";
            dt.Rows.InsertAt(dr, 0);
            cmb.Properties.DataSource = dt;

            cmb.Properties.DisplayMember = "BRANCH_NAME";
            cmb.Properties.ValueMember = "BRANCH_ID";
            cmb.Properties.ForceInitialize();
            cmb.Properties.PopulateColumns();
            cmb.Properties.Columns[0].Visible = false;
            cmb.Properties.Columns[1].Caption = "Filial";
            cmb.EditValue = null;
        }

        public void GetMTDescription(DevExpress.XtraEditors.LookUpEdit cmb)
        {
            DataTable dt = exDao.GetMtDescription();
            if (dt.Equals(DBNull.Value))
                return;

            cmb.Properties.DataSource = dt;
            cmb.Properties.ValueMember = "ID";
            cmb.Properties.DisplayMember = "NAME";
            cmb.Properties.ForceInitialize();
            cmb.Properties.PopulateColumns();
            cmb.Properties.Columns[0].Visible = false;
            cmb.Properties.Columns[1].Caption = "Təyinat";
            cmb.EditValue = null;
        }

        private void cmbDocType_EditValueChanged(object sender, EventArgs e)
        {
            GetDocPlace(lkUpDocPlace, Convert.ToInt32(lkUpDocType.EditValue));

            ClearSerialInfo();

            if (lkUpDocType.EditValue.ToString() == "1")
            {
                txtPhySerialNumber.Properties.MaxLength = 8;
            }
            else if (lkUpDocType.EditValue.ToString() == "7" || lkUpDocType.EditValue.ToString() == "232")
            {
                txtPhyPin.Enabled = false;
                txtPhySerialNumber.Properties.MaxLength = 7;
            }
            else if (lkUpDocType.EditValue.ToString() == "230" || lkUpDocType.EditValue.ToString() == "231")
            {
                txtPhyPin.Properties.MaxLength = 6;
            }
        }

        private void cmbCurrency_EditValueChanged(object sender, EventArgs e)
        {
            txtAmount.ReadOnly = false;
            txtCommAmount.ReadOnly = false;
            txtSumAmount.ReadOnly = false;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (!txtAmount.Text.Equals(""))
            {
                txtAmountByLetter.Text = exDao.GetAmountByLetter(Convert.ToDecimal(txtAmount.Text), Convert.ToInt32(cmbCurrency.EditValue)).Rows[0][0].ToString();
                txtSumAmount.Text = (decimal.Parse(txtCommAmount.Text == "" ? "0" : txtCommAmount.Text) + decimal.Parse(txtAmount.Text)).ToString();
            }
        }

        private void txtCommAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCommAmount.Text != "")
                txtSumAmount.Text = (decimal.Parse(txtCommAmount.Text == "" ? "0" : txtCommAmount.Text) + decimal.Parse((txtAmount.Text))).ToString();
            else
                txtSumAmount.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CheckTxtCells())
            {
                tpgCrUser.PageVisible = true;
                tabPane1.SelectedPage = tpgCrUser;
            }
        }

        public bool CheckTxtCells()
        {
            if (rbResident.Checked == false && rbNonResident.Checked == false)
            {
                MessageBox.Show("Diqqət, Müştəri rezident və ya qeyri-rezident olması təyin edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (txtSurname.Text.Trim() == "")
            {
                MessageBox.Show("Diqqət, Müştərinin soyadı qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin adı qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (txtFname.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin atasının adı qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin mobil telefonu qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (lkUpDocType.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin sənəd tipi qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (Convert.ToInt32(lkUpDocType.EditValue) == 1)
            {
                if (txtPhyPin.Text == "")
                {
                    MessageBox.Show("Diqqət, Müştərinin pin kodu qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            if (txtPhySerial.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin sənədin seriya qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (txtPhySerialNumber.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin sənədin № qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (dtGivenDate.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin sənədi verilmə tarixi qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            //if (dtExpireDate.Text == "")
            //{
            //    MessageBox.Show("Diqqət, Müştərinin sənədin etibarlılıq tarixi qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            //    return false;
            //}
            if (cmbCurrency.Text == "")
            {
                MessageBox.Show("Diqqət, Köçürmənin valyutası qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Diqqət, Köçürmənin məbləği qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (cmbDescription.Text == "")
            {
                MessageBox.Show("Diqqət, Köçürmənin təyinatı qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (decimal.Parse(clsMethod.GetRegional(txtAmount.Text)) == 0)
            {
                MessageBox.Show("Diqqət, Köçürmənin məbləği 0 ola bilməz!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (lkUpDocType.EditValue != null && string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                int ExistCustCount;
                switch (Convert.ToInt32(lkUpDocType.EditValue))
                {
                    case 1:
                    case 230:
                    case 231:
                    case 233:
                        ExistCustCount = Convert.ToInt32(exDao.CheckCustExists(txtPhyPin.Text).Rows[0][0]);

                        if (ExistCustCount > 0)
                        {
                            MessageBox.Show("Daxil edilən müştəri sistemdə mövcuddur.Sistemdəki məlumatlar göstərildi.");
                            FillSendCustInfo(exDao.GetCustInfo(passPin: txtPhyPin.Text));
                            return false;
                        }
                        goto case 7;
                    case 7:
                    case 232:
                        ExistCustCount = Convert.ToInt32(exDao.CheckCustExists(null, txtPhySerialNumber.Text).Rows[0][0]);

                        if (ExistCustCount > 0)
                        {
                            MessageBox.Show("Daxil edilən müştəri sistemdə mövcuddur.Sistemdəki məlumatlar göstərildi.");
                            FillSendCustInfo(exDao.GetCustInfo(passNum: Convert.ToInt32(txtPhySerialNumber.Text)));

                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }

            decimal amountInAzn = Convert.ToDecimal(txtAmount.Text == "" ? "0" : txtAmount.Text) * Convert.ToDecimal(exDao.GetConversionRate(Convert.ToInt32(cmbBranch.EditValue), Convert.ToInt32(cmbCurrency.EditValue)).Rows[0][0]);

            if (amountInAzn > 20000 && lkUpDocPlace.Text == "")
            {
                MessageBox.Show("Diqqət, Müştərinin sənədi verən organ qeyd edilməyib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        private void FillSendCustInfo(DataTable dt)
        {
            txtCustomer.Text = dt.Rows[0]["CUST_ID"].ToString();
            cmbCustomer.Text = dt.Rows[0]["FULL_NAME"].ToString();
            if (dt.Rows[0]["REZIDENT_ID"].ToString() == "102")
            {
                rbResident.Checked = false;
                rbNonResident.Checked = true;
            }
            else
            {
                rbResident.Checked = true;
                rbNonResident.Checked = false;
            }
            txtSurname.Text = dt.Rows[0]["LASTNAME"].ToString();
            txtName.Text = dt.Rows[0]["NAME"].ToString();
            txtFname.Text = dt.Rows[0]["FATHER_NAME"].ToString();
            txtPhyPin.Text = dt.Rows[0]["DOC_PINCODE"].ToString();
            txtPhySerial.Text = dt.Rows[0]["DOC_SERIAL"].ToString();
            txtPhySerialNumber.Text = dt.Rows[0]["DOC_NUMBER"].ToString();
            lkUpDocPlace.EditValue = Convert.ToDecimal(dt.Rows[0]["GIVING_PLACE_ID"]);
            dtGivenDate.EditValue = Convert.ToDateTime(dt.Rows[0]["DOC_GIVING_DATE"]);
        }

        private void txtDocnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lkUpDocType.EditValue.ToString() == "1" || lkUpDocType.EditValue.ToString() == "7" || lkUpDocType.EditValue.ToString() == "232")
                if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;

            if (lkUpDocType.EditValue.ToString() == "230" || lkUpDocType.EditValue.ToString() == "231" || lkUpDocType.EditValue.ToString() == "233")
                if (!Regex.IsMatch((e.KeyChar).ToString(), "^[a-zA-Z0-9]*$") && !char.IsControl(e.KeyChar))
                    e.Handled = true;
        }

        private void txtCustomer_EditValueChanged(object sender, EventArgs e)
        {
            GetCustomerInfo(txtCustomer.Text);
        }

        private void txtSCustomer_EditValueChanged(object sender, EventArgs e)
        {
            GetSCustomerInfo(txtSCustomer.Text);
        }

        public void GetCustomerInfo(string custId)
        {
            if (custId != "")
            {
                DataTable dt = exDao.GetCustInfo(custId: Convert.ToInt32(custId));
                if (dt.Equals(DBNull.Value))
                    return;

                if (dt.Rows.Count == 0)
                    return;

                if (dt.Rows[0]["REZIDENT_ID"].ToString() == "1")
                    rbResident.Checked = true;
                else if (dt.Rows[0]["REZIDENT_ID"].ToString() == "0")
                    rbNonResident.Checked = true;

                txtSurname.Text = dt.Rows[0]["LASTNAME"].ToString();
                txtName.Text = dt.Rows[0]["NAME"].ToString();
                txtFname.Text = dt.Rows[0]["FATHER_NAME"].ToString();
                lkUpDocType.EditValue = decimal.Parse(dt.Rows[0]["DOC_TYPE_ID"].ToString());
                txtPhyPin.Text = dt.Rows[0]["DOC_PINCODE"].ToString();
                txtPhySerial.Text = dt.Rows[0]["DOC_SERIAL"].ToString();
                txtPhySerialNumber.Text = dt.Rows[0]["DOC_NUMBER"].ToString();
                lkUpDocPlace.Text = dt.Rows[0]["GIVING_PLACE_ID"].ToString();
                dtGivenDate.DateTime = Convert.ToDateTime(dt.Rows[0]["DOC_GIVING_DATE"]);
                txtPhone.Text = dt.Rows[0]["TEL_NO"].ToString();

                comMethod.SetReadonlyControls(grB_SendCustInfo.Controls);
            }
        }

        public void GetSCustomerInfo(string custId)
        {
            if (custId != "")
            {
                DataTable dt = exDao.GetCustInfo(custId: Convert.ToInt32(custId));

                if (dt.Equals(DBNull.Value))
                    return;

                if (dt.Rows.Count == 0)
                    return;

                if (dt.Rows[0]["REZIDENT_ID"].ToString() == "1")
                    rbSResident.Checked = true;
                else if (dt.Rows[0]["REZIDENT_ID"].ToString() == "0")
                    rbSNonResident.Checked = true;

                txtSSurname.Text = dt.Rows[0]["LASTNAME"].ToString();
                txtSName.Text = dt.Rows[0]["NAME"].ToString();
                txtSFname.Text = dt.Rows[0]["FATHER_NAME"].ToString();
                cmbSDocType.EditValue = decimal.Parse(dt.Rows[0]["DOC_TYPE_ID"].ToString());
                txtSPincode.Text = dt.Rows[0]["DOC_PINCODE"].ToString();
                txtSDocserial.Text = dt.Rows[0]["DOC_SERIAL"].ToString();
                txtSDocnumber.Text = dt.Rows[0]["DOC_NUMBER"].ToString();
                cmbSDocPlace.Text = dt.Rows[0]["GIVING_PLACE_ID"].ToString();
                dtSGivenDate.DateTime = Convert.ToDateTime(dt.Rows[0]["DOC_GIVING_DATE"]);
                txtSPhone.Text = dt.Rows[0]["TEL_NO"].ToString();

                comMethod.SetReadonlyControls(grB_SendCustInfo.Controls);
            }
        }

        private void GetSphonepref()
        {
            cmbSphonepref.Properties.DataSource = exDao.GetPhoneCode();
            cmbSphonepref.Properties.ValueMember = "ID";
            cmbSphonepref.Properties.DisplayMember = "OPCT_CODE";
            cmbSphonepref.Properties.ForceInitialize();
            cmbSphonepref.Properties.PopulateColumns();
            cmbSphonepref.Properties.Columns[0].Visible = false;
            cmbSphonepref.Properties.Columns[0].Caption = "tabID";
            cmbSphonepref.Properties.Columns[1].Caption = "Prefiks";
        }

        private void cmbSDocType_EditValueChanged(object sender, EventArgs e)
        {
            GetDocPlace(cmbSDocPlace, Convert.ToInt32(cmbSDocType.EditValue));

            ClearSerialInfo();

            if (lkUpDocType.EditValue.ToString() == "1")
            {
                txtPhySerialNumber.Properties.MaxLength = 8;
            }
            else if (lkUpDocType.EditValue.ToString() == "7" || lkUpDocType.EditValue.ToString() == "232")
            {
                txtPhyPin.Enabled = false;
                txtPhySerialNumber.Properties.MaxLength = 7;
            }
            else if (lkUpDocType.EditValue.ToString() == "230" || lkUpDocType.EditValue.ToString() == "231")
            {
                txtPhyPin.Properties.MaxLength = 6;
            }
        }

        void ClearSerialInfo()
        {
            txtPhySerial.Text = "";
            txtPhySerialNumber.Text = "";
            txtPhyPin.Text = "";
            txtPhySerial.Enabled = true;
            txtPhySerialNumber.Enabled = true;
            txtPhyPin.Enabled = true;
        }
    }
}

