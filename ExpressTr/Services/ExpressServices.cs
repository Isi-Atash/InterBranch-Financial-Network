using MlbAdminSettings.Services;
using MlbAdminSettings.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressTr.Services
{
    class ExpressServices : Service
    {
        public async Task<dynamic> ExpressPayRefund(string json)
        {
            string url = string.Concat(AppSettings.MLBUrl, "mlb/ekspress/reverseExpressOperation");

            return await SendPostRequestGetResponseJson(url, json, AppSettings.BasicAuthMLB);
        }

        //public async Task<dynamic> KoronaPayRefund(string json)
        //{
        //    string url = string.Concat(AppSettings.MLBUrl, "mlb/abs/refund");

        //    return await SendPostRequestGetResponseJson(url, json, AppSettings.BasicAuthMLB);
        //}

        public async Task<dynamic> ExpressPayConfirm(string json)
        {
            string url = string.Concat(AppSettings.MLBUrl, "mlb/ekspress/acceptExpressOperation");

            return await SendPostRequestGetResponseJson(url, json, AppSettings.BasicAuthMLB);
        }

        public async Task<dynamic> ExpressSms(string json)
        {
            string url = string.Concat(AppSettings.MLBUrl, "mlb/util/sendSms");

            return await SendPostRequestGetResponseJson(url, json, AppSettings.BasicAuthMLB);
        }

        public async Task<dynamic> ExpressCreateOperation(string json)
        {
            string url = string.Concat(AppSettings.MLBUrl, "mlb/abs/createExpressOperation");

            return await SendPostRequestGetResponseJson(url, json, AppSettings.BasicAuthMLB);
        }

        public async Task<dynamic> ExpressCreateNominalCustomer(string json)
        {
            string url = string.Concat(AppSettings.MLBUrl, "mlb/util/createNominalCustomer");

            return await SendPostRequestGetResponseJson(url, json, AppSettings.BasicAuthMLB);
        }




    }
}
