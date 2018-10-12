using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FirstTeamWork
{
    public partial class Form1 : Form
    {
        private WordBlock movingBlock;
        private WordBlock nextBlock;
        private Point startLocation = new Point(Table.blocksize * 3, 0);
        private bool startGame = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:if(movingBlock.right())
            }
        }
    }
}
