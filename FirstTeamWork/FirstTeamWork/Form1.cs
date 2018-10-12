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
using System.Drawing.Drawing2D;
using System.Threading;

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
                case Keys.Right: if (!movingBlock.right()) ; break;//向右移动
                case Keys.Left: if (!movingBlock.left()) ; break; //向左移动
                case Keys.Up: ; break; //旋转
                case Keys.Down: while (movingBlock.down()) ; break; //向下加速
                case Keys.Space:                           //空格：暂停
                    timer1.Enabled = !timer1.Enabled;
                    if (!timer1.Enabled)
                        ;
                    else
                        ;
                    break;
            }
            
        }

        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movingBlock = new FirstTeamWork.WordBlock(startLocation);
            movingBlock.creat(Table.winHandle);
            nextBlock = new WordBlock(new Point(80, 50));
            nextBlock.creat(pictureBox3.Handle);
            startGame = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!startGame)
                return;

            //检测是否还可以下移
            if (!movingBlock.down())
            {
                if (movingBlock.top() == 0)
                {//如果到顶则游戏结束
                    startGame = false;
                    timer1.Stop();
                    return;
                }
                //否则计算分数并继续
                if (startGame ==true)
                {
                    Application.DoEvents();
                    Table.Redraw();
                }
                //产生下一个block
                movingBlock = new WordBlock(startLocation);
                movingBlock.creat(Table.winHandle);
                pictureBox3.Refresh();
                nextBlock = new WordBlock(new Point(80, 50));
                nextBlock.creat(pictureBox3.Handle);
            }
            movingBlock.down();
        }
    }
}
