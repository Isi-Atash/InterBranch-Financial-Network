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
    public partial class ExpressMain : Form
    {
        ExpressDao exDao = new ExpressDao();
        ClssComMethod clsComm = new ClssComMethod();
        ExpressServices exServices = new ExpressServices();
        private int _operId { get; set; } = -1;

        public static readonly DateTime operationsStartDate = new DateTime(2020, 1, 1);

        public ExpressMain()
        {
            InitializeComponent();
        }

        private void ExpressMain_Load(object sender, EventArgs e)
        {
            FillDefault();
            DateTimeLimit();
        }

        private void FillDefault()
        {
            FillExpressOut();
            FillExpressIn();
            FillExpressReturned();
        }

        private void DateTimeLimit()
        {
            dtInStart.Properties.MinValue = dtOutStart.Properties.MinValue = dtReturnedStart.Properties.MinValue
                = dtInEnd.Properties.MinValue = dtOutEnd.Properties.MinValue = dtReturnedEnd.Properties.MinValue = operationsStartDate;

            dtInStart.Properties.MaxValue = dtOutStart.Properties.MaxValue = dtReturnedStart.Properties.MaxValue
               = dtInEnd.Properties.MaxValue = dtOutEnd.Properties.MaxValue = dtReturnedEnd.Properties.MaxValue = DateTime.Today;

            dtInStart.EditValue = dtOutStart.EditValue = dtReturnedStart.EditValue
                = dtInEnd.EditValue = dtOutEnd.EditValue = dtReturnedEnd.EditValue = DateTime.Today;
        }


        private void grdVwExpressOut_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _operId = Convert.ToInt32(grdVwExpressOut.GetFocusedRowCellValue("OP_ID"));
        }

        private void grdVwExpressReturned_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _operId = Convert.ToInt32(grdVwExpressReturned.GetFocusedRowCellValue("OP_ID"));
        }

        private void grdVwExpressIn_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _operId = Convert.ToInt32(grdVwExpressIn.GetFocusedRowCellValue("OP_ID"));
        }


        private void ShowFrmAddMt(PageMode pageMode)
        {
            FrmAddMT frm = new FrmAddMT(pageMode, _operId);
            frm.ShowDialog();
        }

        private void ShowCipher(CipherMode cipher)
        {
            FrmCipher frm = new FrmCipher(cipher);
            frm.ShowDialog();
            if (frm.Tag!=null && frm.Tag.ToString()=="Close")
            {

            }
            else
            {
                FillDefault();
            }
        }

        private void tlBarNew_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ShowFrmAddMt(PageMode.Add);
        }

        private void tlBarLookOut_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ShowFrmAddMt(PageMode.View);
        }

        private void tlBarSignOut_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ShowFrmAddMt(PageMode.Sign);
        }

        private void tlBarEditOut_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ShowFrmAddMt(PageMode.Edit);
        }


        private void tlBarExcelOut_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            clsComm.ShowExcel(grdVwExpressOut, string.Join("_", "Express göndərilən köçürmələr", dtOutStart.DateTime.ToShortDateString(), dtOutEnd.DateTime.ToShortDateString()));
        }

        private void tlBarExcelReturned_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            clsComm.ShowExcel(grdVwExpressReturned, string.Join("_", "Express geriqayarılan sənədlər", dtReturnedStart.DateTime.ToShortDateString(), dtReturnedEnd.DateTime.ToShortDateString()));
        }

        private void tlBarExcelIn_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            clsComm.ShowExcel(grdVwExpressIn, string.Join("_", "Express daxil olan köçürmələr", dtInStart.DateTime.ToShortDateString(), dtInEnd.DateTime.ToShortDateString()));
        }


        private void FillExpressOut()
        {
            grdCtrlExpressOut.DataSource = exDao.GetExpressTransfers(dtOutStart.DateTime.Date, dtOutEnd.DateTime.Date, ExpressType.Out);
            grdVwExpressOut.BestFitColumns();
        }

        private void FillExpressReturned()
        {
            grdCtrlExpressIn.DataSource = exDao.GetExpressTransfers(dtReturnedStart.DateTime.Date, dtReturnedEnd.DateTime.Date, ExpressType.Returned);
            grdVwExpressReturned.BestFitColumns();
        }

        private void FillExpressIn()
        {
            grdCtrlExpressIn.DataSource = exDao.GetExpressTransfers(dtInStart.DateTime.Date, dtInEnd.DateTime.Date, ExpressType.In);
            grdVwExpressIn.BestFitColumns();
        }


        private void tlBarRefreshOut_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FillExpressOut();
        }

        private void tlBarRefreshReturned_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FillExpressReturned();
        }

        private void tlBarRefreshIn_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FillExpressIn();
        }

        private void tlBarСipher_in_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ShowCipher(CipherMode.Cipher);
        }

        private void tlBarReject_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            //ShowCipher(CipherMode.Refund);
        }

        private void tlBarSendSms_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            SendSmsBody();
        }

        private async Task SendSms(long crMobile, string fullname, decimal amount, string currency, long code)
        {
            dynamic reqJson = new JObject();
            reqJson.smsTo = crMobile;
            reqJson.smstext = $"Sizə, {fullname} tərəfindən {amount} {currency} məbləğində vəsait göndərilmişdir. {code} kodu və şəxsiyyət vəsiqəniz ilə Bankın istənilən filialına yaxınlaşıb vəsaitinizi əldə edə bilərsiniz.";

            string json = reqJson.ToString();

            dynamic responseJson = await exServices.ExpressSms(json);
            if (responseJson == null)
                return;

            if (responseJson.status.statusCode != 1)
            {
                MessageBox.Show((string)responseJson.status.statusMessage, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("SMS uğurla göndərildi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void SendSmsBody()
        {
            if ((grdVwExpressOut.RowCount <= 0))
                return;

            int status = Convert.ToInt32(grdVwExpressOut.GetFocusedRowCellValue("STATUS_ID"));
            string status_az = grdVwExpressOut.GetFocusedRowCellValue("STATUS_NAME").ToString();

            if (status != 7)
            {
                string message = "";
                switch (status)
                {
                    case 0:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        message = "Xətalı Əməliyyat";
                        break;
                    default:
                        message = $@"Əməliyyat {status_az}!";
                        break;
                }

                return;
            }

            long crMobile;

            if (grdVwExpressOut.GetFocusedRowCellValue("CR_MOBILE") == DBNull.Value)
            {
                MessageBox.Show("Alan müştərinin telefon nömrəsi yoxdur!");
                return;
            }
            else
                crMobile = Convert.ToInt64(grdVwExpressOut.GetFocusedRowCellValue("CR_MOBILE"));

            string fullname;
            if (grdVwExpressOut.GetFocusedRowCellValue("DT_CUST_NAME") == DBNull.Value)
            {
                MessageBox.Show("Göndərən müştərinin adı yoxdur!");
                return;
            }
            else
                fullname = grdVwExpressOut.GetFocusedRowCellValue("DT_CUST_NAME").ToString();


            decimal amount;
            if (grdVwExpressOut.GetFocusedRowCellValue("DT_AMOUNT") == DBNull.Value)
            {
                MessageBox.Show("Əməliyyat məbləği yoxdur!");
                return;
            }
            else
                amount = Convert.ToDecimal(grdVwExpressOut.GetFocusedRowCellValue("DT_AMOUNT"));

            string currency;
            if (grdVwExpressOut.GetFocusedRowCellValue("DT_CCY") == DBNull.Value)
            {
                MessageBox.Show("Əməliyyat valutası yoxdur!");
                return;
            }
            else
                currency = grdVwExpressOut.GetFocusedRowCellValue("DT_CCY").ToString();

            long operationCode;
            if (grdVwExpressOut.GetFocusedRowCellValue("OPERATION_CODE") == DBNull.Value)
            {
                MessageBox.Show("Əməliyyat kodu yoxdur!");
                return;
            }
            else
                operationCode = Convert.ToInt64(grdVwExpressOut.GetFocusedRowCellValue("OPERATION_CODE"));

            DialogResult dialogResult = MessageBox.Show("SMS göndər?", "SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                await SendSms(crMobile, fullname, amount, currency, operationCode);
        }

        private void tlBarRefund_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ShowCipher(CipherMode.Refund);
        }
    }
}
