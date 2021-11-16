using System.Collections.Generic;
using TbCommon;

namespace ExpressTr.Settings
{
    public class Security
    {
        readonly ClssComMethod clssComMethod = new ClssComMethod();

        public bool CheckPolicy(string policyKeyword)
        {
            return clssComMethod.checkGrantShowError(policyKeyword);
        }
    }
}
