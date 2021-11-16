using MlbAdminSettings.Data;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using static ExpressTr.Helpers.EnumTypes;

namespace ExpressTr.Data
{
    class ExpressDao : Dao
    {
        public DataTable GetTransferTypes()
        {
            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_TRANSFER_TYPE");
        }

        public DataTable GetDocType()
        {
            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_DOC_TYPE");
        }

        public DataTable GetCurrency()
        {
            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_CURRENCY");
        }

        public DataTable GetPhoneCode()
        {
            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_PHONE_CODE");
        }

        public DataTable GetExpressTransfers(DateTime startDate, DateTime endDate, ExpressType expressType)
        {

            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_START_DATE", startDate),
                new OracleParameter("P_END_DATE", endDate),
                new OracleParameter("P_STATUS",(int)expressType)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_EXPRESS_TRANSFERS", paramList);
        }

        public DataTable GetBranch(int? branchId = null)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_BRANCH_ID",branchId)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_BRANCH", paramList);
        }

        public DataTable CheckCustExists(string pinCode = "", string docNumber = "")
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_PINCODE",(pinCode)),
                new OracleParameter("P_DOCNUMBER",(docNumber))
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.CHECK_CUST_EXIST", paramList);
        }

        public DataTable GetCustInfo(string passPin = null, int? passNum = null, int? custId = null)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_PASSPIN",(passPin)),
                new OracleParameter("P_PASSNUM",(passNum)),
                new OracleParameter("P_CUST_ID",(custId))
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_CUST_INFO", paramList);
        }

        public DataTable GetConversionRate(int branchId, int curCode)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_BRANCH_ID",(branchId)),
                new OracleParameter("P_CUR_CODE",(curCode))
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_CONVERTION_RATE", paramList);
        }

        public DataTable GetAmountByLetter(decimal amount, int curCode)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_AMOUNT",(amount)),
                new OracleParameter("P_CUR_CODE",(curCode))
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_AMOUNT_BY_LETTER", paramList);
        }

        public DataTable GetDocPlace(int docType)
        {

            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_DOC_TYPE",(docType))
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_DOC_PLACE", paramList);
        }

        public DataTable GetMtDescription()
        {
            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_MT_DESCRIPTION");
        }

        public DataTable GetDtCustInfoExpress(int mtId)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_ID",mtId)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.DT_CUST_INFO_EXPRESS", paramList);
        }

        public DataTable GetCrCustInfoExpress(int mtId)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_ID",mtId)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.CR_CUST_INFO_EXPRESS", paramList);
        }

        public DataTable CheckCipher(string operationCode)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_OPERATION_CODE",operationCode)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.CHECK_CIPHER", paramList);
        }

       


        public DataTable GetAccounts(int custId, int? branchId = null)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_BRANCH_ID",branchId),
                new OracleParameter("P_CUST_ID",custId)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_ACCOUNTS", paramList);
        }


        public DataTable GetAccountsBranch(int custId)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_CUST_ID",custId)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_ACCOUNTS_BRANCH", paramList);
        }

        public DataTable GetAccInfo(long accId)
        {
            List<OracleParameter> paramList = new List<OracleParameter>
            {
                new OracleParameter("P_ACC_ID",accId)
            };

            return ExecuteFunctionReturnRefCursor(@"MLB_TEST.MLB_EXPRESS_OPERATION.GET_ACC_INFO", paramList);
        }
    }
}
