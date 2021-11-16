using ExpressTr.Data;
using ExpressTr.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using TbCommon;

namespace ExpressTr
{
    public partial class FrmAddCustomer : Form
    {
        ClssOracleMethod SQL = new ClssOracleMethod();
        ExpressServices exServices = new ExpressServices();
        ExpressDao exDao = new ExpressDao();

        public string _custId { get; set; }

        public FrmAddCustomer()
        {
            InitializeComponent();
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            GetDocType(lkUpDocType);
            lkUpDocType.EditValue = Convert.ToDecimal(1);
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

        bool CheckCustomerInfo()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Soyad boş ola bilməz"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Ad boş ola bilməz"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("Ata adı boş ola bilməz"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Mobil nömrəsi boş ola bilməz"); return false;
            }
            if (lkUpDocType.EditValue == null)
            {
                MessageBox.Show("Sənədin növü boş ola bilməz"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhySerial.Text) || string.IsNullOrWhiteSpace(txtPhySerialNumber.Text))
            {
                MessageBox.Show("Seriya № boş ola bilməz"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhyPin.Text))
            {
                MessageBox.Show("Pinkod boş ola bilməz"); return false;
            }

            return true;
        }

        bool CheckCustomerExist()
        {
            string ExistCustId = "";
            if (lkUpDocType.EditValue.ToString() == "1")
            {
                ExistCustId = SQL.ExecuteScalar(string.Format("select cust_id from cust_info_identity_cards where DOC_PINCODE='{0}'", txtPhyPin.Text), ClssOracleMethod.orclCon);
            }
            else if (lkUpDocType.EditValue.ToString() == "7")
            {
                ExistCustId = SQL.ExecuteScalar(string.Format("select cust_id from cust_info_identity_cards where doc_number='{0}'", txtPhySerialNumber.Text), ClssOracleMethod.orclCon);
            }
            else if (lkUpDocType.EditValue.ToString() == "230")
            {
                ExistCustId = SQL.ExecuteScalar(string.Format("select cust_id from cust_info_identity_cards where DOC_PINCODE='{0}'", txtPhyPin.Text), ClssOracleMethod.orclCon);
            }
            else if (lkUpDocType.EditValue.ToString() == "231")
            {
                ExistCustId = SQL.ExecuteScalar(string.Format("select cust_id from cust_info_identity_cards where DOC_PINCODE='{0}'", txtPhyPin.Text), ClssOracleMethod.orclCon);
            }
            else if (lkUpDocType.EditValue.ToString() == "232")
            {
                ExistCustId = SQL.ExecuteScalar(string.Format("select cust_id from cust_info_identity_cards where doc_number='{0}'", txtPhySerialNumber.Text), ClssOracleMethod.orclCon);
            }
            else if (lkUpDocType.EditValue.ToString() == "233")
            {
                ExistCustId = SQL.ExecuteScalar(string.Format("select cust_id from cust_info_identity_cards where DOC_PINCODE='{0}'", txtPhyPin.Text), ClssOracleMethod.orclCon);
            }


            if (!string.IsNullOrWhiteSpace(ExistCustId))
            {
                MessageBox.Show("Daxil edilən müştəri sistemdə mövcuddur.BP № : " + ExistCustId); return false;
            }
            return true;
        }

        public async Task CreateNominalCust()
        {
            dynamic reqJson = new JObject();

            reqJson.name = txtName.Text;
            reqJson.surname = txtSurname.Text;
            reqJson.patronymic = txtFname.Text;
            reqJson.mobile = txtPhone.Text;

            reqJson.resident = rbResident.Checked ? 101 : 102;

            reqJson.docTypeId = Convert.ToInt64(lkUpDocType.EditValue);
            reqJson.passSerial = txtPhySerial.Text;
            reqJson.passNumber = txtPhySerialNumber.Text;

            reqJson.pin = txtPhyPin.Text;

            reqJson.dateOfIssue = dtGivenDate.DateTime.Date;
            reqJson.passPlace = Convert.ToInt64(lkUpDocPlace.EditValue);

            string jsonNominal = reqJson.ToString();

            dynamic responseJson = await exServices.ExpressCreateNominalCustomer(jsonNominal);

            if (responseJson == null)
            {
                MessageBox.Show("Xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (responseJson.status.statusCode != 1)
            {
                MessageBox.Show((string)responseJson.respStatus.statusMessage, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Tag = "Error";
            }
            else if (responseJson.status.statusCode == 1)
            {
                _custId = responseJson.custId;
                this.Tag = "Success";
            }
        }

        private async void btnContractOk_Click(object sender, EventArgs e)
        {
            if (!CheckCustomerInfo())
                return;
            if (!CheckCustomerExist())
                return;

            await CreateNominalCust();

            Close();
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

        void ClearSerialInfo()
        {
            txtPhySerial.Text = "";
            txtPhySerialNumber.Text = "";
            txtPhyPin.Text = "";
            txtPhySerial.Enabled = true;
            txtPhySerialNumber.Enabled = true;
            txtPhyPin.Enabled = true;
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

                //if (lkUpDocType.EditValue.ToString() == "1")
                //{
                //    txtPhySerialNumber.Properties.MaxLength = 8;
                //}
                //else if (lkUpDocType.EditValue.ToString() == "7")
                //{
                //    txtPhySerialNumber.Properties.MaxLength = 6;
                //    txtPhyPin.Enabled = false;
                //    txtPhyPin.Text = "0000000";
                //}
                //else if (lkUpDocType.EditValue.ToString() == "9")
                //{
                //    txtPhySerial.Enabled = false;
                //    txtPhySerialNumber.Enabled = false;
                //    txtPhyPin.Enabled = false;
                //}
                //else if (lkUpDocType.EditValue.ToString() == "230")
                //{
                //    txtPhySerialNumber.Properties.MaxLength = 7;
                //}
                //else if (lkUpDocType.EditValue.ToString() == "231")
                //{
                //    txtPhySerialNumber.Properties.MaxLength = 7;
                //}
                //else if (lkUpDocType.EditValue.ToString() == "232")
                //{
                //    txtPhySerialNumber.Properties.MaxLength = 6;
                //    txtPhyPin.Enabled = false;
                //    txtPhyPin.Text = "0000000";
                //}
                //else if (lkUpDocType.EditValue.ToString() == "233")
                //{
                //    txtPhySerialNumber.Properties.MaxLength = 9;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
