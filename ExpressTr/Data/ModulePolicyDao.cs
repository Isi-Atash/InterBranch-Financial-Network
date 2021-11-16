using ComStageApplyCancel;
using DevExpress.XtraEditors;
using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Forms;
using TbCommon;
using static ExpressTr.Helpers.EnumTypes;

namespace ExpressTr.Data
{
    public class ModulePolicyDao
    {
        readonly ClssComMethod clssComMethod = new ClssComMethod();

        public void SetModulAndUserId(long moduleId)
        {
            OracleCommand oracleCmd = new OracleCommand()
            {
                Connection = ClssOracleMethod.orclCon,
                CommandText = "security_package.SET_MODUL_ID_CONT",
                CommandType = CommandType.StoredProcedure,
            };

            oracleCmd.Parameters.Add("p_VAR_NAME", OracleDbType.Varchar2).Value = "MODUL_ID";
            oracleCmd.Parameters.Add("p_VAR_VALUE", OracleDbType.Decimal).Value = moduleId;

            oracleCmd.ExecuteNonQuery();

            OracleCommand oracleCmd_USER = new OracleCommand()
            {
                Connection = ClssOracleMethod.orclCon,
                CommandText = "security_package.SET_USER_ID_CONT",
                CommandType = CommandType.StoredProcedure
            };

            oracleCmd_USER.Parameters.Add("p_VAR_NAME", OracleDbType.Varchar2).Value = "USER_ID";
            oracleCmd_USER.Parameters.Add("p_VAR_VALUE", OracleDbType.Varchar2).Value = ClssUserInfo.User_Id;

            oracleCmd_USER.ExecuteNonQuery();
        }

        public void AddSignModule(GroupControl grpSign, long moduleId, long docId, ConfirmMode confirmMode)
        {
            FrmUserStageApplyCancel frmUserStageApplyCancel = new FrmUserStageApplyCancel(moduleId.ToString(), docId.ToString())
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None
            };

            grpSign.Controls.Clear();
            grpSign.Controls.Add(frmUserStageApplyCancel);
            frmUserStageApplyCancel.Show();
            if (confirmMode != ConfirmMode.Sign)
            {
                clssComMethod.GetComponentReadEnabledFalse(frmUserStageApplyCancel);
            }
        }
    }
}
