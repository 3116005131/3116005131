using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x3;
            int f3;
            Console.Write("x=");
            x3 = Convert.ToDouble(Console.ReadLine());
            if(x3==0)
            {
                goto label1;
            }
            if (x3>0)
            {
                goto  label2;
            }
            f3 = -1;
            goto label3;

        label1:
            f3 = 0;
            goto label3;
        label2:
            f3 = 1;
        label3:
            Console.WriteLine("f("+x3.ToString()+")="+f3.ToString());


            Console.Write("请输入一组整数(整数间用逗号隔开)");
            string S1 = Console.ReadLine();
            //以逗号为分隔符，将字符串S1中的整数分散到数组sArray中
            string[] sArray = S1.Split('，');//S.Split()-------------string->string[]
            Console.WriteLine("以上一组整数中，所有的奇数如下");
            foreach (string item in sArray)
            {
                int n2 = int.Parse(item);
                if (n2%2==0)
                {
                    continue;
                }
                Console.WriteLine(n2);
            }
            string S;
            Console.Write("判断n是否为素数 n= ");
            int n1 = int.Parse(Console.ReadLine());
            int i1;
            for (i1=(int)System.Math.Sqrt(n1);i1>1;i1--)
            {
                if (n1%i1==0)
                {
                    break;
                }
            }
            if (i1==1)
            {
                S = "整数" + n1.ToString() + "是素数";//n.ToString-----------------int->String
            }
            else
            {
                S = "整数" + n1.ToString() + "不是素数";
            }
            Console.WriteLine(S);
            int lowerNum = 0;   //小写字母个数
            int upperNum = 0;   //大写字母个数
            int numeralNum = 0; //数字个数
            int otherNum = 0;   //其他字符个数
            Console.Write("请输入任意字符串: ");
            string line = Console.ReadLine();
            char[] chars = line.ToCharArray();   //s.ToCharArray()--------string->char[]
            int lineLen = chars.Length;
            for (int I3 = 0; I3 < lineLen; I3++)
            {
                int ascii = (int)chars[I3];      //(int)chars[i]-----------char->int
                if (ascii >= 65 && ascii <= 90)
                {
                    upperNum++;
                }
                else if (ascii >= 97 && ascii <= 122)
                {
                    lowerNum++;
                }
                else if (ascii >= 48 & ascii <= 57)
                    numeralNum++;
                else otherNum++;
            }
            Console.WriteLine("大写字母个数：{0}", upperNum);
            Console.WriteLine("小写字母个数：{0}", lowerNum);
            Console.WriteLine("数字字符个数：{0}", numeralNum);
            Console.WriteLine("其他字符个数：{0}", otherNum);
            Hashtable ht = new Hashtable();
            ht.Add(201001, "张赵刚");
            ht.Add(201002, "李斯");
            ht.Add(201003, "王智高");
            ht.Add(201004, "蒙怡");
            ht.Add(201005, "赵高");
            Console.WriteLine("学号为奇数的学生：");
            Console.WriteLine("----------------------");
            Console.WriteLine("学号       姓名");
            foreach (int studi in ht.Keys)
            {
                if ((studi + 1) % 2 == 0) Console.WriteLine(studi + "     " + ht[studi]);
            }
            int N1 = 100;
            int I2 = 1;
            int SUM = 0;
            do
            {
                SUM += I2;
                I2++;
            } while (I2<=N1);
            Console.WriteLine("1+2+3+...+{0}={1}", N1, SUM);
            double t = 2;
            int I1 = 1;
            double Sum = 0;
            while (t>0.000001)
            {
                t = 1.0 / I1;
                Sum += t;
                I1++;
            }
            Console.WriteLine("1+1/2+1/3+...+1/{0}={1}", I1 - 1, Sum);
            Console.Write("计算等差数列前n项之和，其中");
            Console.Write("n = ");
            int N = int.Parse(Console.ReadLine());//int.Parse(s)----------string->int
            int I = 1;
            int sum = 0;
            while (I<=N)
            {
                sum += 2 * I - 1;
                I++;
            }
            Console.WriteLine("1+3+5+...+{0}={1}", 2*N-1, sum);
            Console.Write("请输入分数：");
            double Score = Convert.ToDouble(Console.ReadLine());
            string Grade;
            if (Score>100||Score<0)
            {
                Console.Write("输入的分数不合法,请核查！");
                Console.ReadLine();
                return;
            }
            switch ((int)(Score/10))
            {
                case 10:
                case 9:
                    Grade = "优秀";
                    break;
                case 8:
                    Grade = "良好";
                    break;
                case 7:
                    Grade = "中等";
                    break;
                case 6:
                    Grade = "及格";
                    break;
                default:
                    Grade = "不及格";
                    break;
            }
            Console.WriteLine("成绩等级为{0}", Grade);
            Console.Write("请输入分数:");
            double score = Convert.ToDouble(Console.ReadLine());
            string grade;
            if (score>100||score<0)
            {
                Console.Write("输入的分数不合法，请核查！");
                Console.ReadLine();
                return;
            }
            if (score >= 90)
            {
                grade = "优秀";
            }
            else if (score >= 80)
            {
                grade = "良好";
            }
            else if (score >= 70)
            {
                grade = "中等";
            }
            else if (score >= 60)
            {
                grade = "及格";
            }
            else grade = "不及格";
            Console.WriteLine("成绩等级为：{0}!", grade);
            double z;
            int n;
            Console.Write("输入一个需要四舍五入的数");
            z = Convert.ToDouble(Console.ReadLine());
            if (z-(int)z>=0.5)
            {
                n = (int)z + 1;
            }
            else
            {
                n = (int)z;
            }
            Console.WriteLine("四舍五入为{0}", n);
            double X, Y;
            Console.Write("请输入第一个整数:");
            X = Convert.ToDouble(Console.ReadLine());
            Console.Write("请输入第二个整数:");
            Y = Convert.ToDouble(Console.ReadLine());
            if (X<Y)
            {
                X = Y;
            }
            Console.WriteLine("大者为" + X.ToString() + " !");
            Console.Write("分段函数计算，输入x的值");
            double x;
            int i;
            x = Convert.ToDouble(Console.ReadLine());
            if (x > 0)
            {
                i = 1;
            }
            else if (x == 0)
            {
                i = 0;
            }
            else i = -1;
            Console.WriteLine("f(" + x.ToString() + ") = " + i.ToString());
            Console.Write("请输入一个华氏度");
            string s = Console.ReadLine();
            float c, f;
            f = float.Parse(s);
            c = 5 * (f - 32) / 9;
            Console.WriteLine("华氏{0}度 = 摄氏{1}度", s, c);
            Console.ReadLine();
        }
    }
}
