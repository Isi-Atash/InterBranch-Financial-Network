using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TbCommon;
using DevExpress.XtraGrid.Views.Grid;
using ExpressTr.Data;
using Newtonsoft.Json.Linq;
using ExpressTr.Services;
using static ExpressTr.Helpers.EnumTypes;

namespace ExpressTr
{
    public partial class UsrExpressCurrentAccount : UserControl
    {
        ExpressDao exDao = new ExpressDao();
        ExpressServices exServices = new ExpressServices();

        int _opId { get; set; } = -1;

        PageMode _pageMode;

        public UsrExpressCurrentAccount(PageMode pageMode, int opId = -1)
        {
            InitializeComponent();

            _pageMode = pageMode;
            _opId = opId;
        }

        private void UsrExpressCurrentAccount_Load(object sender, EventArgs e)
        {
            FillLookUpEdit();

            if (_pageMode == PageMode.Add)
            {

            }
            else if (_pageMode == PageMode.Edit || _pageMode == PageMode.Sign || _pageMode == PageMode.View)
            {
                if (_opId != -1)
                {
                    FillAllInfo();
                }
            }

        }

        private void FillAllInfo()
        {

        }

        private void FillLookUpEdit()
        {
            //GetBranch(cmbAccBranch);
            GetAccCurrency();
            GetMTDescription(cmbAccDescription);
        }

        private void cmbAccCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtAccCustomer.Text = "";
            cmbAccCustomer.Text = "";
            FrmCustCommonSearch frmCustCommonSearch = new FrmCustCommonSearch("");
            frmCustCommonSearch.ShowDialog();
            GetSelectedCustomer_Acc(frmCustCommonSearch);
        }

        private void GetSelectedCustomer_Acc(FrmCustCommonSearch frmCustCommonSearch)
        {
            if (frmCustCommonSearch.Tag != null && frmCustCommonSearch.Tag.ToString() == "select")
            {
                GridView grdView = frmCustCommonSearch.grdVwCustomer;
                txtAccCustomer.Text = grdView.GetFocusedRowCellValue("CUST_ID").ToString();
                cmbAccCustomer.Text = grdView.GetFocusedRowCellValue("FULL_NAME").ToString();

                cmbAccount.EditValue = null;
                txtAmount.Text = "";
                cmbAccCurrency.EditValue = null;
                cmbAccDescription.Text = "";
            }
        }

        private void txtAccCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbAccBranch.ReadOnly == true)
                cmbAccBranch.ReadOnly = false;
            GetBranch(cmbAccBranch);
        }

        private void GetBranch(DevExpress.XtraEditors.LookUpEdit cmb)
        {
            if (txtAccCustomer.Text == "")
                return;

            DataTable dt = exDao.GetAccountsBranch(Convert.ToInt32(txtAccCustomer.Text));
            if (dt == null)
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

        private void GetAccount()
        {
            DataTable dt = exDao.GetAccounts(Convert.ToInt32(txtAccCustomer.Text), Convert.ToInt32(cmbAccBranch.EditValue));
            if (dt == null)
                return;

            cmbAccount.Properties.DataSource = dt;
            cmbAccount.Properties.DisplayMember = "ACC_NO";
            cmbAccount.Properties.ValueMember = "ACC_ID";
            cmbAccount.Properties.PopulateColumns();
            cmbAccount.Properties.Columns[0].Visible = false;
            cmbAccount.Properties.Columns[1].Caption = "Hesab";
            cmbAccount.Properties.Columns[2].Visible = false;
            cmbAccount.EditValue = null;
        }

        private void cmbAccBranch_EditValueChanged(object sender, EventArgs e)
        {
            GetAccount();
        }

        private void cmbAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbAccount.EditValue != null)
            {
                DataTable dt = exDao.GetAccInfo(Convert.ToInt64(cmbAccount.EditValue));
                if (dt == null)
                    return;

                cmbAccCurrency.EditValue = dt.Rows[0]["CUR_CODE"];
            }
        }

        private void GetAccCurrency()
        {
            cmbAccCurrency.Properties.DataSource = exDao.GetCurrency();
            cmbAccCurrency.Properties.ValueMember = "CUR_CODE";
            cmbAccCurrency.Properties.DisplayMember = "SHORT_NAME";
            cmbAccCurrency.Properties.ForceInitialize();
            cmbAccCurrency.Properties.PopulateColumns();
            cmbAccCurrency.Properties.Columns[0].Visible = false;
            cmbAccCurrency.Properties.Columns[0].Caption = "Valyuta kodu";
            cmbAccCurrency.Properties.Columns[1].Caption = "Qısa adı";
            cmbAccCurrency.Properties.Columns[2].Caption = "Valyuta adı";
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

        public async Task ExpressNominalCust()
        {
            dynamic reqJsonNominal = new JObject();

            reqJsonNominal.resident = rbResident.Checked ? 1 : 0;

            reqJsonNominal.name = txtName.Text;
            reqJsonNominal.surname = txtSurname.Text;
            reqJsonNominal.patronymic = txtFname.Text;
            reqJsonNominal.mobile = txtPhone.Text;

            reqJsonNominal.docTypeId = Convert.ToInt64(lkUpDocType.EditValue);
            reqJsonNominal.passSerial = txtPhySerial.Text;
            reqJsonNominal.passNumber = txtPhySerialNumber.Text;
            reqJsonNominal.pin = txtPhyPin.Text;

            reqJsonNominal.passPlace = lkUpDocPlace.Text;
            reqJsonNominal.dateOfIssue = dtGivenDate.DateTime.Date;


            string jsonNominal = reqJsonNominal.ToString();

            dynamic responseJsonNominal = await exServices.ExpressCreateNominalCustomer(jsonNominal);
            if (responseJsonNominal == null)
                return;

            if (responseJsonNominal.status.statusCode != 1)
            {
                MessageBox.Show((string)responseJsonNominal.respStatus.statusMessage, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Tag = "Error";
            }
            else
            {
                MessageBox.Show("Müştəri əlavə olundu!");
                this.Tag = "Success";
            }
        }

        private async void CreateNominalCust()
        {
            DialogResult dialogResult = MessageBox.Show("Yaddaşa yazılsın?", "Təsdiqləmək", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                await ExpressNominalCust();
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

        void ClearSerialInfo()
        {
            txtPhySerial.Text = "";
            txtPhySerialNumber.Text = "";
            txtPhyPin.Text = "";
            txtPhySerial.Enabled = true;
            txtPhySerialNumber.Enabled = true;
            txtPhyPin.Enabled = true;
        }

        private void lkUpDocType_EditValueChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string ReplaceWhiteSpaces(string str)
        {
            return str.Trim().Replace(" ", string.Empty);
        }

        private void txtSurname_EditValueChanged(object sender, EventArgs e)
        {
            txtSurname.Text = ReplaceWhiteSpaces(txtSurname.Text);
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            txtName.Text = ReplaceWhiteSpaces(txtName.Text);
        }

        private void txtFatherName_EditValueChanged(object sender, EventArgs e)
        {
            txtFname.Text = ReplaceWhiteSpaces(txtFname.Text);
        }

        private void rdGr_Sender_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSenderCustId.Text = "";
            bteSenderCustName.Text = "";

            if (rdGr_Sender.EditValue.ToString() == "0")
            {
                txtSenderCustId.Text = txtAccCustomer.Text;
                bteSenderCustName.Text = cmbAccCustomer.Text;
            }
            if (rdGr_Sender.SelectedIndex.ToString() == "0")
            {
                rgOtherCustomerType.Visible = false;
            }
            if (rdGr_Sender.SelectedIndex.ToString() == "1")
            {
                rgOtherCustomerType.Visible = true;
            }
        }

        private void rgOtherCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bteSenderCustName.Text = "";
            txtSenderCustId.Text = "";
        }

        private void bteSenderCustName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Convert.ToInt16(rdGr_Sender.EditValue) == 0)
            {
                FrmCustCommonSearchAll frmCustCommonSearchAll = new FrmCustCommonSearchAll("0");
                frmCustCommonSearchAll.ShowDialog();
                GetSelectedCustomer_Sender(frmCustCommonSearchAll);
            }
            if (Convert.ToInt16(rdGr_Sender.EditValue) == 1)
            {
                if (rgOtherCustomerType.SelectedIndex.ToString() == "0")
                {
                    FrmCustCommonSearchAll frmCustCommonSearchAll = new FrmCustCommonSearchAll("0");
                    frmCustCommonSearchAll.ShowDialog();
                    GetSelectedCustomer_Sender(frmCustCommonSearchAll);
                }
                if (rgOtherCustomerType.SelectedIndex.ToString() == "1")
                {
                    FrmAddCustomer frmAddCustomer = new FrmAddCustomer();
                    frmAddCustomer.ShowDialog();
                    MessageBox.Show(frmAddCustomer.txtName.Text);
                    if (frmAddCustomer.Tag != null && frmAddCustomer.Tag.ToString() == "Success")
                    {
                        txtSenderCustId.Text = frmAddCustomer._custId;
                        bteSenderCustName.Text = $"{frmAddCustomer.txtSurname.Text} {frmAddCustomer.txtName.Text} {frmAddCustomer.txtFname.Text}";
                    }
                }
            }
        }

        private void GetSelectedCustomer_Sender(FrmCustCommonSearchAll frmCustCommonSearch)
        {
            if (frmCustCommonSearch.Tag != null && frmCustCommonSearch.Tag.ToString() == "select")
            {
                GridView grdView = frmCustCommonSearch.grdVwCustomer;
                txtSenderCustId.Text = grdView.GetFocusedRowCellValue("CUST_ID").ToString();
                bteSenderCustName.Text = grdView.GetFocusedRowCellValue("FULL_NAME").ToString();
            }
        }
    }
}
