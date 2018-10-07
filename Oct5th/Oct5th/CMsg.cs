using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oct5th
{
    class CMsg
    {
        public void ShowInf(string inf)
        {
            MessageBox.Show(inf, "Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }//弹出窗口
}
