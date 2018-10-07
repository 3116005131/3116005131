using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Oct._6th
{
    //委托
    public delegate void DInputError();
    public partial class NumberTextBox : UserControl
    {
        //声明事件
        public event DInputError InputError;
        //构造函数
        public NumberTextBox()
        {
            InitializeComponent();
        }
        //内容不是数字时出发InputError事件

        private void NumberTextBox_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            decimal num;
            if (!decimal.TryParse(textBox1.Text, out num))
            {
                InputError.Invoke();
            }

        }
    }
}
