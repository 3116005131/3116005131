using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveSmile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        label1.Top -= speed;
                        break;
                    }
                case Keys.Down:
                    {
                        label1.Top += speed;
                        break;
                    }
                case Keys.Left:
                    {
                        label1.Left -= speed;
                        break;
                    }
                case Keys.Right:
                    {
                        label1.Left += speed;
                        break;
                    }
                case Keys.Space:
                    {
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
