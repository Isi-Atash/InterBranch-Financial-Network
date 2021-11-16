using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressTr.Helpers
{
    class CommonMethos
    {
        public void SetReadonlyControls(Control.ControlCollection controlCollection)
        {
            if (controlCollection == null)
            {
                return;
            }
            foreach (RadioButton r in controlCollection.OfType<RadioButton>())
            {
                r.Enabled = false; //RadioButtons do not have readonly property
            }
            foreach (TextEdit c in controlCollection.OfType<TextEdit>())
            {
                c.ReadOnly = true;
            }
            foreach (TextBox c in controlCollection.OfType<TextBox>())
            {
                c.ReadOnly = true;
            }
            foreach (LookUpEdit c in controlCollection.OfType<LookUpEdit>())
            {
                c.ReadOnly = true;
            }
            foreach (DateEdit c in controlCollection.OfType<DateEdit>())
            {
                c.ReadOnly = true;
            }
            //foreach (TextBoxBase c in controlCollection.OfType<TextBoxBase>())
            //{
            //    c.ReadOnly = true;
            //}
        }
    }
}
