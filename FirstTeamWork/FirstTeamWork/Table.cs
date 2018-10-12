using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FirstTeamWork
{
    class Table
    {
        public const int width = 6;
        public const int height = 9;
        public const int blocksize = 60;
        public static Color BackColor;         //场景的背景色
        public static System.IntPtr winHandle; //场景的handle
        public static Color[] BlockForeColor = { Color.Blue, Color.Beige, Color.DarkKhaki, Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkOrange, Color.DarkRed };
        public static Color[] BlockBackColor = { Color.LightCyan, Color.DarkSeaGreen, Color.Beige, Color.Beige, Color.Beige, Color.Beige, Color.Beige };
        public static WordBlock [,] arriveBlock = new WordBlock[width, height]; //保存已经不能再下落了的方块
        public static int[] arrBitBlock = new int[height];  //位数组：当某个位置有方块时，该行的该位为1
        private const int bitEmpty = 0x0;      //0000 0000 0000 0000 0000
        private const int bitFull = 0xFFFFF;   //1111 1111 1111 1111 1111

        /*检测是否为空*/
        public static bool isEmpty(int x, int y)
        {
            //先检测是否越界
            if (y < 0 || y >= height)
                return false;
            if (x < 0 || x >= width)
                return false;
            //然后检测是否为空
            if ((arrBitBlock[y] & (1 << x)) != 0)
                return false;
            else
                return true;
        }
        /*将方块停住*/
        public static void stopSquare(WordBlock wb, int x, int y)
        {
            arriveBlock[x, y] = wb;
            arrBitBlock[y] = arrBitBlock[y] | (1 << x);
        }
        public static void Redraw()
        {
            for (int y = height - 1; y >= 0; y--)
                if (arrBitBlock[y] != bitEmpty)
                    for (int x = 0; x < width; x++)
                        if ((arrBitBlock[y] & (1 << x)) != 0)
                            arriveBlock[x, y].creat(winHandle);
        }
    }
}
