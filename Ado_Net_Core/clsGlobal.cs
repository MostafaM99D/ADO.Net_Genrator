using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ado_Net_UI
{
    public class clsGlobal
    {
        public static bool IsValidString(string str, string Message)
        {
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show($"{Message}", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
