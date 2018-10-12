using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTeamWork
{
    class WordBlock
    {
        public Point location;
        public Size size;
        public Color foreColor=Color.Black;
        public Color backColor=Color.Red;
        public WordBlock(Point thisLocation)
        {
            Random rand = new Random();
            int i = rand.Next(7);
            foreColor = Table .BlockForeColor[i];
            backColor = Table.BlockBackColor[i];
            size.Height = 60;
            size.Width = 60;
            location = thisLocation;
        }
        private const int blockSize = Table.blocksize;
        public void creat(System.IntPtr winHandle)
        {
            Graphics g = Graphics.FromHwnd(winHandle);
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(location,size);
            gp.AddRectangle(rec);
            Color[] surroundColor = new Color[] { backColor };
            PathGradientBrush pb = new PathGradientBrush(gp);
            pb.CenterColor = foreColor;
            pb.SurroundColors = surroundColor;
            g.FillPath(pb, gp);
        }
        public void eliminate(System.IntPtr winHandle)
        {
            Graphics g = Graphics.FromHwnd(winHandle);
            Rectangle rec = new Rectangle(location, size);
            g.FillRectangle(new SolidBrush(Table.BackColor), rec);
        }
        public bool down()
        {
            if (Table.isEmpty(location.X / blockSize, location.Y / blockSize + 1))
            {
                eliminate(Table.winHandle);
                location.Y += blockSize;
                creat(Table.winHandle);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool left()
        {
            if (Table.isEmpty(location.X / blockSize-1, location.Y))
            {
                eliminate(Table.winHandle);
                location.X -= blockSize;
                creat(Table.winHandle);
                return true;
            }
            else
            {
                Table.stopSquare(this, location.X / blockSize, location.Y / blockSize);
                return false;
            }
        }
        public bool right()
        {
            if (Table.isEmpty(location.X / blockSize+1, location.Y))
            {
                eliminate(Table.winHandle);
                location.X += blockSize;
                creat(Table.winHandle);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int top() { return location.Y; }

    }
}
