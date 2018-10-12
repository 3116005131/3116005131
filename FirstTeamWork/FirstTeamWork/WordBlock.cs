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
        public char Word;
        public void creat() { }
        public void eliminate() { }
        public bool down() { return true; }
        public bool left() { return true; }
        public bool right() { return true; }
        public int top() { return location.Y; }

    }
}
