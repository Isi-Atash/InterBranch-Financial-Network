using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TbCommon;
using Oracle.DataAccess.Client;
using ComStageApplyCancel;
using static ExpressTr.Helpers.EnumTypes;
using ExpressTr.Data;

namespace ExpressTr
{
    public partial class FrmCipher : Form
    {
        CipherMode _cipherMode;
        private int _operId { get; set; }
        private int _dtBranchId { get; set; }

        ExpressDao exDao = new ExpressDao();

        public FrmCipher(CipherMode cipherMode)
        {
            InitializeComponent();

            _cipherMode = cipherMode;
        }

        private bool CheckCipher()
        {
            DataTable dt = exDao.CheckCipher(operationCode: txtCipher.Text);

            if (dt.Equals(DBNull.Value))
            {
                MessageBox.Show("Köçürmə tapılmadı.", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Köçürmə tapılmadı.", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                
                if (dt.Rows[0]["ID"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Köçürmənin ID-si yoxdur!");
                    return false;
                }
                else
                {
                    _operId = Convert.ToInt32(dt.Rows[0]["ID"]);
                }

                if (dt.Rows[0]["DT_BRANCH_ID"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Köçürmənin göndərən filialı yoxdur!");
                    return false;
                }
                else
                {
                    _dtBranchId = Convert.ToInt32(dt.Rows[0]["DT_BRANCH_ID"]);
                }
            }

            return true;
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            this.Tag = "Close";
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (!CheckCipher())
            {
                this.Tag = "Close";
                Close();
            }
            else
            {
                this.Visible = false;

                FrmAddMT frm = new FrmAddMT(PageMode.View, _operId);

                if (_cipherMode == CipherMode.Cipher)
                {
                    frm.sbOK.Enabled = true;
                    frm.sbOK.Text = "Qəbul Et";
                }
                else if (_cipherMode == CipherMode.Refund)
                {
                    if (ClssUserInfo.Branch_Id != _dtBranchId.ToString())
                    {
                        MessageBox.Show("Yalnız öz filialınızdan göndərilən köçürmə geri qaytarıla bilər!");
                        this.Tag = "Close";
                        Close();
                        return;
                    }
                    else
                    {
                        frm.sbOK.Enabled = frm.sbOK.Visible = false;
                        frm.sbRefund.Visible = frm.sbRefund.Enabled = true;
                    }
                }

                frm.ShowDialog();

                if (frm.Tag != null && frm.Tag.ToString() == "Accept")
                    this.Tag = "Accept";

                else if (frm.Tag != null && frm.Tag.ToString() == "Close")
                    this.Tag = "Close";

                Close();
            }
        }
    }
}
