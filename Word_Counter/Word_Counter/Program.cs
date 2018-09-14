using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Counter
{
    class Program
    {
        public class wc
        {
            string path;    //需统计文件的路径
            char[] types = { 'c', 'C', 'w', 'W', 'l', 'L' };    //目前所能统计的类型(字符，单词，行数）
            int n;  //统计结果
            char[] type;      //当前统计的类型
            public void NCount()    //统计方法
            {
                GetMessage();
                Count();
                Show();
            }
            public void GetMessage()    //输入信息
            {
                Console.Write("WC.exe -");
                string Message = Console.ReadLine();
                string[] CategoryInfomation = Message.Split(' ');
                path = CategoryInfomation[1];
                type = CategoryInfomation[0].ToCharArray();
            }   
            public void Count()     //统计数量
            {
                int c=0, w=0, l=0;//字符数，单词数，行数
                int WFlag=0;        //单词标识符
                FileStream fs = null;
                StreamReader reader = null;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(fs);
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    int i = reader.Read();
                    while (i!=-1)
                    {
                        c++;
                        if (i<=90||i>=65||i>=97||i<=122)
                        {
                            if (WFlag == 0)
                            {
                                w++;
                                WFlag = 1;
                            }
                            else WFlag = 0;
                        }
                        char character = (char)i;
                        if (character == '\n')
                        {
                            l++;
                        }
                        i = reader.Read();
                    }
                }
                catch (Exception)        //path输入有误
                {
                    Console.WriteLine("输入的地址有误，找不到该文件");
                }
                finally
                {
                    if(reader!=null)reader.Close();
                    if(fs!=null)fs.Close();
                }
                if (type[0] == 'c' || type[0] == 'C')
                {
                    n = c;
                }
                else if (type[0] == 'w' || type[0] == 'W')
                {
                    n = w;
                }
                else if (type[0] == 'l' || type[0] == 'L')
                {
                    n = l;
                }
            }
            public void Show()      //输出结果
            {
                if (type[0] == 'c' || type[0] == 'C')
                {
                    Console.WriteLine("字符数为{0}", n);
                }
                else if (type[0] == 'w' || type[0] == 'W')
                {
                    Console.WriteLine("单词数为{0}", n);
                }
                else if(type[0] == 'l' || type[0] == 'L')
                {
                    Console.WriteLine("行数为{0}", n);
                }
                else
                {
                    Console.WriteLine("Word count does not support this type of statistics.");     //输入的参数有误，n=0
                }
            }           
        }
        static void Main(string[] args)
        {
            Console.WriteLine("The WorkCount version is 1.1.");
            Console.WriteLine("Only support inyput \" -c<path> , -w<path> , -l<path>\" for example: WC.exe -c c:test.c");
            wc WorkCounter = new wc();
            WorkCounter.NCount();
            Console.ReadLine();
        }
    }
}
