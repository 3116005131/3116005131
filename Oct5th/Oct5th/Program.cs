using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using m = System.Math;//类的别名
using r1 = Oct5th;//命名空间的别名
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic;
using System.Threading;
using System.Collections;
using System.Data.SqlClient;

namespace Oct5th
{
    class Program
    {
        //多线程
        //易失域 volatile关键字
        volatile static public int TicketCount = 10;
        static ArrayList arrNumber = new ArrayList();

        static void Add()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (arrNumber)
                {
                    if (!arrNumber.Contains(i))
                    {
                        arrNumber.Add(i);
                        Console.WriteLine("{0},添加样本数{1}", Thread.CurrentThread.Name, i);
                    }
                }
            }
        }
        static public void SellTicket()
        {
            //多线程
            while (TicketCount > 0)
            {
                TicketCount--;
                Console.WriteLine("{0},卖出了一张票", Thread.CurrentThread.Name);
            }
        }
        //交换两个整数的值
        static void Swap(ref int x,ref int y)
        {
            int swapTemp = x;
            x = y;
            y = swapTemp;
        }
        //挑出字符串中的数字
        static int GetNumber(string strSource,out string result)
        {
            char[] arrChar = strSource.ToCharArray();
            result = "";
            int counter = 0;//记录数字的个数
            for (int i = 0; i < arrChar.Length; i++)
            {
                int charCode = (int)arrChar[i];
                if (charCode>=47&&charCode<=58)
                {
                    result += arrChar[i].ToString();
                    counter++;
                }
            }
            return counter;
        }
        //计算整数之和
        static int Sum(params int[] numbers)
        {
            Console.WriteLine("带了{0}个参数", numbers.Length);
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }


        static void Main(string[] args)
        {
            //类cnCalender的测试代码
            DateTime date = new DateTime(1997, 10, 30);//我的阳历生日
            CCalendar ccd = new CCalendar(date);
            ccd.showCnYear();
            ccd.showCnMonth();
            ccd.showDay();
            Console.WriteLine();
            //引用参数 ref关键字
            int num1 = 1, num2 = 99;
            Console.WriteLine("交换前：num1={0},num2={1}", num1, num2);
            Swap(ref num1, ref num2);
            Console.WriteLine("交换后：num1={0},num2={1}", num1, num2);
            //输出参数 out关键字
            string str1 = "abc0jx897";
            string numberString;
            int numberCount = GetNumber(str1, out numberString);
            Console.WriteLine("字符串{0}中共有{1}个数字", str1, numberCount);
            Console.WriteLine("全部数字是{0}", numberString);
            //参数数组 params关键字
            Console.WriteLine("计算结果是{0}", Sum(2, 3, 5, 7, 11));
            //启动Windows窗体
            Application.Run(new Form1());
            //C S I E
            SHuman tom = new SHuman();
            tom.Name = "Tom";
            tom.Age = 10;
            tom.Age = 32;
            Console.WriteLine("{0}的年龄是{1}", tom.Name, tom.Age);
            C1 obj = new C1();
            (obj as InterfaceDemo5).Test();
            (obj as I1).Test();
            Console.WriteLine("{0}={1}", Esex.Male, (int)Esex.Male);
            //易失域的测试代码
            Thread thread1 = new Thread(SellTicket);
            thread1.Name = "窗口1";
            Thread thread2 = new Thread(SellTicket);
            thread2.Name = "窗口2";
            Thread thread3 = new Thread(SellTicket);
            thread3.Name = "窗口3";
            thread1.Start();
            thread2.Start();
            thread3.Start();
            //lock语句的应用
            Thread thread4 = new Thread(Add);
            thread4.Name = "线程1";
            Thread thread5 = new Thread(Add);
            thread5.Name = "线程2";
            Thread thread6 = new Thread(Add);
            thread6.Name = "线程3";
            thread4.Start();
            thread5.Start();
            thread6.Start();
            //数据库 用using语句释放资源
            /*
            using (SqlConnection cnn=new SqlConnection(dbcnnStr))
            {
                cnn.Open();
            }
            */
            //获取系统目录路径测试
            //Console.WriteLine("Windows 安装目录是{0}", CSys.GetWindowsDirectory());
            Console.WriteLine("char类型占用{0}字节", sizeof(int));
            //可空类型
            decimal? altitude = null;
            Console.WriteLine("海拔：{0}", altitude);
            //迭代器模式测试
            Ctest test = new Ctest();
            test.Add("Tom");
            test.Add("Jerry");
            test.Add("John");
            foreach (object obJ in test)
            {
                Console.WriteLine(obJ.ToString());

            }

            //类CMsg的测试代码
            CMsg msg = new CMsg();
            msg.ShowInf("程序运行结束");
        }
    }
}
