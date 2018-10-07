using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oct5th
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CCalendar cale = new Oct5th.CCalendar(dateTimePicker1.Value);
            textBox1.Text = cale.GetYearName();
            textBox2.Text = cale.GetMonthName();
            textBox3.Text = cale.GetDayName();
        }
    }
}
