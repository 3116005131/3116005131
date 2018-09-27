using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myapp
{
    class Program
    {
        public class Create
        { 
            public int range;
            public int problemNum;
            public string CreatArith(int seed)
            {
                DateTime rnb = new DateTime();
                string s = null;
                Random rand = new Random(seed-rnb.Millisecond);
                int ran = rand.Next(1, 5);
                switch (ran)
                {
                    case 1:
                        s = "+";
                        break;
                    case 2:
                        s = "-";
                        break;
                    case 3:
                        s = "*";
                        break;
                    case 4:
                        s = "/";
                        break;
                    default:
                        break;
                }
                return s;
            }
            public string createProblem(int range,int seed)//完美生成一道题目string s
            {
                Random r = new Random(seed);            //随机数生成器
                string s = "";                      //string题目
                string tempOperator = null;         //string运算符
                int operatorNum = r.Next(1, 4);     //运算符的个数(1-3个)
                int bracket_left = 0;               //左括号
                int bracket_right = 0;              //右括号   
                bracket_left = r.Next(1, 4);
                if(bracket_left==1&&operatorNum!=1)
                {
                    s += "(";
                    bracket_right++;
                }
                s += r.Next(1, range);
                for (int j = 0; j < operatorNum; j++)
                {
                    tempOperator = CreatArith(seed+j);
                    bracket_left = r.Next(1,4);
                    if (bracket_left == 1 && j != operatorNum - 1)             //加左括号（括号后至少有两个操作符）
                    {
                        s += tempOperator;
                        s += "(";
                        s += r.Next(1, range);
                        bracket_right++;
                    }
                    else if (bracket_left == 2 && bracket_right != 0)//加右括号
                    {
                        s += tempOperator;
                        s += r.Next(1, range);
                        s += ")";
                        bracket_right--;
                    }
                    else
                        s +=tempOperator+r.Next(1, range);                      //不加括号
                }
                if (bracket_right != 0)                                        //右括号匹配
                {
                    for (int i = 0; i < bracket_right; bracket_right--)
                    {
                        s += ")";
                    }
                }                                   
                s = subStr(s);              //去除表达式两侧的括号如（4/3+2*1）
                return s;
            }
            public string subStr(string str)       //完美除去题目string s首尾为（）的特殊情况
            {
                char[] s = str.ToCharArray();
                if (s[0] == '(' && s[str.Length - 1] == ')')
                {
                    for (int i = 1; i < str.Length - 1; i++)
                    {
                        if (s[i] == '(')
                        {
                            break;
                        }
                        if (s[i] == ')')
                        {
                            return str;
                        }
                    }
                    str = str.Substring(1, str.Length - 2);
                }
                return str;
            }
            public void productProblems()
            {
                DateTime time = new DateTime();
                Random rad = new Random(time.Millisecond);
                string path = @"d:\exercisefile.txt";
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                for (int i = 0; i < problemNum; i++)
                {
                    
                    int seed = rad.Next(1, 10000);
                    string str1 = createProblem(range,seed+i*10);//给范围生成一道题目
                    Console.WriteLine("  "+str1+"=");
                    string exercise = Convert.ToString(i + 1) + "、" + str1 + " = \r\n";
                    writer.Write(exercise);          
                }
                 writer.Close();
            }

        //}


        //public class GetExp
        //{
        //    public double e;
        //    public bool flag = false;
        //    public double getExpression(TreeNode currNode)
        //    {
        //        if (currNode.left == null || currNode.right == null)
        //        {
        //            string str = currNode.data;
        //            e = Convert.ToInt32(str.Trim());
        //            return e;
        //        }
        //        else
        //        {
        //            if (currNode.data.Equals("+"))
        //            {
        //                e = getExpression(currNode.left) + getExpression(currNode.right);
        //            }
        //            if (currNode.data.Equals("-"))
        //            {
        //                e = getExpression(currNode.left) - getExpression(currNode.right);
        //            }
        //            if (currNode.data.Equals("*"))
        //            {
        //                e = getExpression(currNode.left) * getExpression(currNode.right);
        //            }
        //            if (currNode.data.Equals("/"))
        //            {
        //                if (getExpression(currNode.right) != 0)
        //                    e = getExpression(currNode.left) / getExpression(currNode.right);
        //                else { flag = true; }
        //            }

        //        }
        //        return e;
        //    }
        //}


        //public class Result
        //{
        //    private List<TreeNode> treeList;
        //    private List<string> problemList;
        //    private string right;
        //    private string wrong;

        //    public string attRight
        //    {
        //        get { return right; }
        //        set { right = value; }
        //    }
        //    public string attWrong
        //    {
        //        get { return wrong; }
        //        set { wrong = value; }
        //    }
        //    public List<TreeNode> attTreeList
        //    {
        //        get { return treeList; }
        //        set { treeList = value; }
        //    }
        //    public Result(List<TreeNode> treeList, List<string> problemList)
        //    {
        //        this.treeList = treeList;
        //        this.problemList = problemList;
        //        right = null;
        //        wrong = null;
        //    }
        //    public void CompareAnswer(String str)
        //    {
        //        try
        //        {

        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }


    }
        static void Main(string[] args)
        {
            Create cr = new Create();
            Console.Write("Myapp.exe -n ");//Myapp.exe -n   10
            cr.problemNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Myapp.exe -r ");//Myapp.exe -r   10
            cr.range = Convert.ToInt32(Console.ReadLine());
                    cr.productProblems();           //在txt中生成好了题目,并暂存了所有问题string[]
            Console.WriteLine("请到D:\test.txt完成题目");
            Console.Read();
        }
    }
}
