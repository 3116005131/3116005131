using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTeamWork
{
    class Table
    {
        public const int width = 6;
        public const int height = 9;
        public const int blocksize = 60;
        public static WordBlock[,] bottomBlock = new WordBlock[width, height];
        public static int[] arrWordBlock = new int[height];
        public static bool checkArrIsEmpty() { return true; }
        public static void blockArrive(WordBlock wb,int x,int y) { }
    }
}
