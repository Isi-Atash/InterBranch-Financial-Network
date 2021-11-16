using ExpressTr.Data;
using ExpressTr.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TbCommon;
using static ExpressTr.Helpers.EnumTypes;

namespace ExpressTr
{
    public partial class FrmAddMT : Form
    {
        readonly PageMode _pageMode;
        ExpressDao exDao = new ExpressDao();
        ClssComMethod clsComm = new ClssComMethod();
        ModulePolicyDao modulePolicyDao = new ModulePolicyDao();
        ExpressServices exServices = new ExpressServices();

        public UsrExpressNoUser _usrNoUser;
        public UsrExpressCurrentAccount _usrAcc;

        int _operId { get; set; } = -1;

        public FrmAddMT(PageMode pageMode, int operId)
        {
            InitializeComponent();
            _pageMode = pageMode;
            _operId = operId;

            this.CenterToScreen();
        }

        private void FrmAddMT_Load(object sender, EventArgs e)
        {
            GetTransfersType();
            LoadPageMode();
            //AddExpressType();
        }

        private void GetTransfersType()
        {
            cmbTransferType.Properties.DataSource = exDao.GetTransferTypes();
            cmbTransferType.Properties.ValueMember = "TYPE_ID";
            cmbTransferType.Properties.DisplayMember = "DESCRIPTION";
            cmbTransferType.Properties.PopulateColumns();
            cmbTransferType.Properties.Columns[0].Visible = false;
            cmbTransferType.Properties.Columns[0].Caption = "Tipin ID";
            cmbTransferType.Properties.Columns[1].Caption = "Köçürmənin növü";
        }

        private void LoadPageMode()
        {
            if (_pageMode == PageMode.Add)
            {
                AddConfirmPage(ConfirmMode.Details);
            }
            else if (_pageMode == PageMode.Edit)
            {
                //
                //
                //
                //
                //
                //
                cmbTransferType.EditValue = 4m;
                //
                //
                //
                //
                //
                //
                AddExpressType();

                AddConfirmPage(ConfirmMode.Details);
            }
            else if (_pageMode == PageMode.Sign)
            {
                clsComm.GetComponentReadEnabledFalse(this);
                sbClose.Enabled = true;

                AddConfirmPage(ConfirmMode.Sign);

            }
            else if (_pageMode == PageMode.View)
            {
                //
                //
                //
                //
                //
                //
                cmbTransferType.EditValue = 5m;
                //
                //
                //
                //
                //
                //

                clsComm.GetComponentReadEnabledFalse(this);
                sbClose.Enabled = true;

                AddConfirmPage(ConfirmMode.Details);
            }
        }

        public void AddConfirmPage(ConfirmMode confirmMode)
        {
            //
            //
            //
            //document type??? 
            //doc_no ?????
            //
            //
            //
            modulePolicyDao.AddSignModule(grpSign, (long)ModuleIds.Express, (long)DocumentTypes.Transfers, confirmMode);
        }

        private void AddExpressType()
        {
            sbOK.Enabled = true;
            if (cmbTransferType.EditValue.ToString() == "4") // No account to Account
            {
                _usrAcc = new UsrExpressCurrentAccount(_pageMode)
                {
                    Dock = DockStyle.Fill
                };

                pnCtrlUsrInfo.Controls.Clear();
                pnCtrlUsrInfo.Controls.Add(_usrAcc);
            }
            else if (cmbTransferType.EditValue.ToString() == "5") //No account to No Account
            {
                _usrNoUser = new UsrExpressNoUser(_pageMode)
                {
                    Dock = DockStyle.Fill
                };

                pnCtrlUsrInfo.Controls.Clear();
                pnCtrlUsrInfo.Controls.Add(_usrNoUser);
            }
        }

        private void cmbTransferType_EditValueChanged(object sender, EventArgs e)
        {
            AddExpressType();
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            this.Tag = "Close";
            Close();
        }

        private bool CheckUserInfoNoAcc()
        {
            if (_usrNoUser.txtSSurname.Text == "")
            {
                MessageBox.Show("Alan şəxsin Soyadı qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrNoUser.txtSName.Text == "")
            {
                MessageBox.Show("Alan şəxsin Adı qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrNoUser.txtSFname.Text == "")
            {
                MessageBox.Show("Alan şəxsin Ata adı qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrNoUser.txtSPhone.Text == "")
            {
                MessageBox.Show("Alan şəxsin telefon nömrəsi qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool CheckUserInfoAcc()
        {
            if (_usrAcc.txtAccCustomer.Text == "")
            {
                MessageBox.Show("Alan şəxs qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrAcc.cmbAccBranch.Text == "")
            {
                MessageBox.Show("Alan şəxsin filialı qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrAcc.cmbAccount.Text == "")
            {
                MessageBox.Show("Alan şəxsin hesabı qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrAcc.txtAmount.Text == "")
            {
                MessageBox.Show("Məbləğ qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrAcc.cmbAccDescription.Text == "")
            {
                MessageBox.Show("Təyinat qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_usrAcc.txtSenderCustId.Text == "")
            {
                MessageBox.Show("Göndərənin müştəri kodu qeyd olunmayıb!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return true;
        }


        public async Task CreateNominalCust()
        {
            dynamic reqJson = new JObject();
            if (cmbTransferType.EditValue.ToString() == "1")
            {

                reqJson.name = _usrNoUser.txtName.Text;
                reqJson.surname = _usrNoUser.txtSurname.Text;
                reqJson.patronymic = _usrNoUser.txtFname.Text;
                reqJson.mobile = _usrNoUser.txtPhone.Text;

                reqJson.resident = _usrNoUser.rbResident.Checked ? 101 : 102;

                reqJson.docTypeId = Convert.ToInt64(_usrNoUser.lkUpDocType.EditValue);
                reqJson.passSerial = _usrNoUser.txtPhySerial.Text;
                reqJson.passNumber = _usrNoUser.txtPhySerialNumber.Text;

                reqJson.pin = _usrNoUser.txtPhyPin.Text;

                reqJson.dateOfIssue = _usrNoUser.dtGivenDate.DateTime.Date;
                reqJson.passPlace = Convert.ToInt64(_usrNoUser.lkUpDocPlace.EditValue);

            }

            string jsonNominal = reqJson.ToString();

            dynamic responseJson = await exServices.ExpressCreateNominalCustomer(jsonNominal);

            if (responseJson == null)
            {
                MessageBox.Show("Xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (responseJson.status.statusCode != 1)
            {
                MessageBox.Show((string)responseJson.respStatus.statusMessage, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                await CreateExpressOperation();
            }
        }

        public async Task CreateExpressOperation()
        {
            dynamic reqJson = new JObject();


            if (cmbTransferType.EditValue.ToString() == "1")
            {

                reqJson.transferType = 5; /// NO ACCOUNT TO NO ACCOUNT

                reqJson.crName = _usrNoUser.txtSName.Text;
                reqJson.crSurname = _usrNoUser.txtSSurname.Text;
                reqJson.crFname = _usrNoUser.txtSFname.Text;
                reqJson.crMobile = _usrNoUser.cmbSphonepref.Text + _usrNoUser.txtSPhone.Text;

                reqJson.dtCcyId = Convert.ToInt32(_usrNoUser.cmbCurrency.EditValue);
                reqJson.dtCurrency = _usrNoUser.cmbCurrency.Text;


                reqJson.amount = Convert.ToDouble(_usrNoUser.txtAmount.Text);
                reqJson.comission = Convert.ToDouble(_usrNoUser.txtCommAmount.Text);

                reqJson.purporse = _usrNoUser.cmbDescription.Text;
            }
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //

            else if (cmbTransferType.EditValue.ToString() == "2")
            {

                reqJson.transferType = 5;

            }


            //string json = reqJson.ToString();

            //dynamic responseJson = await exServices.ExpressCreateOperation(json);
            //if (responseJson == null)
            //    return;

            //if (responseJson.respStatus.statusCode != 1)
            //{
            //    MessageBox.Show((string)responseJson.respStatus.statusMessage, "Express Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            MessageBox.Show("Əməliyyat uğurla yaddaşa yazıldı!");
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            sbOK.Enabled = false;

            if (_pageMode == PageMode.Add)
            {

                if (cmbTransferType.EditValue.ToString() == "1")
                {
                    //Check Creditor's information, if they are entered
                    if (!CheckUserInfoNoAcc())
                    {
                        sbOK.Enabled = true;
                        return;
                    }

                    //
                }
                else if (cmbTransferType.EditValue.ToString() == "2")
                {
                    if (!CheckUserInfoAcc())
                    {

                    }
                }
            }
            else if (_pageMode == PageMode.Edit)
            {

            }
            else if (_pageMode == PageMode.View)
            {
                this.Tag = "Accept";
            }

            sbOK.Enabled = true;
            Close();
        }

        private void sbRefund_Click(object sender, EventArgs e)
        {
            this.Tag = "Refund";
            MessageBox.Show("rEFUND ELEMEK UCUN EMELIYYATI YAZ. yAZZZZZZZZZZZZZZZ...AWQRAZZZZZZ \n ADN AND ADN AND AND \n \nO OK?\n BUNA GORE, STATUSLARI NE QOYACAQIVI DEQIQLESDIR!!!");
        }
    }
}
