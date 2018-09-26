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
        public class TreeNode
        {
            public string data;
            public TreeNode left;
            public TreeNode right;

            public TreeNode()
            {
                left = null;
                right = null;
            }

            public TreeNode(string newdata)
            {
                data = newdata;
                left = null;
                right = null;
            }
        }
        public class BinaryTree
        {
            private TreeNode node = null;
            public  TreeNode getNode()
            {
                return node;
            }
            public void setNode(TreeNode node)
            {
                this.node = node;
            }
            public Boolean checkOperator(string expression)
            {
                if (expression.IndexOf("+")==-1&&expression.IndexOf("-")==-1&&expression.IndexOf("*")==-1&&expression.IndexOf("/")==-1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public TreeNode createTree(string expression)
            {
                //去除表达式首部和尾部多余的括号 当出现了括号不匹配时出现异常 抛出
                if(expression.IndexOf("(") == 0)
                {
                    for (int i = 0; i < expression.Length; i++)
                    {
                        if (expression.StartsWith("(")==true)
                        {
                            if (expression.StartsWith(")")==true)
                            {
                                expression = expression.Substring(1, expression.Length - 1);
                            }
                            else
                            {
                                //抛出异常
                            }
                        }
                    }
                }
                char[] exp = expression.ToCharArray();
                TreeNode newNode = new TreeNode();
                string lefrString=null;
                string rightString=null;
                string stack=null;       //用于存储括号的栈  当表达式检测完毕后 若栈部位空  这说明括号的使用不合法
                if (checkOperator(expression)==true)
                {
                    int index = 0;  //记录最先扫描到的不在括号中的加号或减号   必为表达式运算的最后一次操作
                    int multi_div = 0;
                    for (int i = exp.Length-1; i >=0; i--)
                    {
                        if (exp[i] == ')')
                        {
                            stack = stack + exp[i];
                        }
                        else if (exp[i]=='(')
                        {
                            if (stack.Length>0)
                            {
                                stack = stack.Substring(0, stack.Length - 1);
                            }
                        }
                        else if (exp[i]=='+'&&stack.Length==0||exp[i]=='-'&&stack.Length==0)
                        {
                            index = 1;
                            break;
                        }
                        else if (exp[i]=='/'&&stack.Length==0||exp[i]=='*'&&stack.Length==0)
                        {
                            multi_div = 1;
                        }
                        else
                        {
                            if (exp[i]<48||exp[i]>57)
                            {
                                //抛出异常
                            }
                        }
                    }
                    if (stack.Length != 0)
                    {
                        //抛出异常  括号不匹配
                    }
                    int separator;
                    if (index!=0)
                    {   //说明表达式的最后运算为加法或减法
                        separator = index;
                    }
                    else
                    {
                        separator = multi_div;
                    }
                    newNode.data = Convert.ToString(exp[separator]);
                    int pos = 0;
                    for (; pos < separator; pos++)
                    {
                        lefrString = lefrString + exp[pos];
                    }
                    pos++;
                    for (; pos < separator; pos++)
                    {
                        rightString = rightString + exp[pos];
                    }
                    if (node == null)
                    {
                        node = newNode;
                    }
                    newNode.left = createTree(lefrString);
                    newNode.right = createTree(rightString);
                }
                else
                {
                    newNode.data = expression;
                }
                return newNode;
            }

            public void posOrder(TreeNode currentNode)
            {
                if (currentNode != null)
                {
                    posOrder(currentNode.left);
                    posOrder(currentNode.right);
                    Console.Write(currentNode.data);
                }
            }
        }
        public class FenShu
        {
            private int fenzi;//分子
            private int fenmu;//分母
            public int attFenzi //属性
            {
                get { return fenzi; }
                set { fenzi = value; }
            }
            public int attFenmu
            {
                get { return fenmu; }
                set { fenmu = value; }
            }
            public FenShu() { }
            public FenShu (int molecular,int assignment)
            {
                fenzi = molecular;
                fenmu = assignment;
            }
            public FenShu simplify(FenShu a)
            {
                int small;//记录相当小的数
                int big;//记录相当大的数
                if (a.fenzi >a.fenmu)
                {
                    small = a.fenmu;
                    big = a.fenzi;
                }
                else
                {
                    small = a.fenzi;
                    big = a.fenmu;
                }
                //化简 例如：99/22=>9/2
                int maxCommonFactor = 1;
                for (int i = 2; i <=small/2; i++)
                {
                    if (small%i==0&&big%i==0)
                    {
                        maxCommonFactor = i;
                    }
                }
                a.fenzi /= maxCommonFactor;
                a.fenmu /= maxCommonFactor;
                return a;
            }
                //运算符重载
            public static FenShu operator +(FenShu a,FenShu b)
            {
                a.fenzi = a.fenzi * b.fenmu + b.fenzi * a.fenmu;
                a.fenmu = a.fenmu * b.fenmu;
                a = a.simplify(a);
                return a;
            }
            public static FenShu operator -(FenShu a, FenShu b)
            {
                a.fenzi = a.fenzi * b.fenmu - b.fenzi * a.fenmu;
                a.fenmu = a.fenmu * b.fenmu;
                a = a.simplify(a);
                return a;
            }
            public static FenShu operator *(FenShu a, FenShu b)
            {
                a.fenzi = a.fenzi * b.fenzi;
                a.fenmu = a.fenmu * b.fenmu;
                a = a.simplify(a);
                return a;
            }
            public static FenShu operator /(FenShu a, FenShu b)
            {
                a.fenzi = a.fenzi * b.fenmu;
                a.fenmu = a.fenmu * b.fenzi;
                a = a.simplify(a);
                return a;
            }
            public FenShu StrToFrc(string str)
            {
                FenShu a = new FenShu();
                string[] num = str.Split('/');
                a.fenzi = Convert.ToInt32(num[0]);
                a.fenmu = Convert.ToInt32(num[1]);
                return a;
            }
            public string FrcToStr(FenShu a)
            {
                string str = "";
                if (a.fenzi==0)
                {
                    str = 0 + "";
                }
                else
                {
                    int x = a.fenzi;
                    int y = a.fenmu;
                    int flag = 0;
                    if (x < 0) flag += 1;
                    x = Math.Abs(x);
                    if (y < 0) flag += 1;
                    y = Math.Abs(y);
                    if (flag == 1) str += "-";
                    if (x >= y)
                    {
                        int z = x / y;
                        int q = x % y;
                        if (q == 0)
                        {
                            str += z + "";
                        }
                        else
                        {
                            str += z + "" + "^" + q + "" + "/" + y + "";
                        }
                    }
                    else
                    {
                        str += x + "" + "/" + y + "";
                    }
                }
                return str;
            }
        }
        public class Calculate
        {
            private FenShu answer;
            private List<FenShu> answersList;
            private List<TreeNode> treeList;

            public FenShu getA
        }
        public class Create
        {
            private int range;
            private int difcoe;
            private int problemNum;
            private string problem;
            private List<string> problemList;

            public int attRange
            {
                get { return range; }
                set { range = value; }
            }
            public int attDifcoe
            {
                get { return difcoe; }
                set { difcoe = value; }
            }
            public int attProblemNum
            {
                get { return problemNum; }
                set {problemNum = value; }
            }
            public string  attProblem
            {
                get { return problem; }
                set { problem = value; }
            }
            public List<string> attProblemList
            {
                get { return problemList; }
                set { problemList = value; }
            }
            public string Createnum(int range)
            {
                Random rand = new Random();
                int ran = rand.Next(1, range-1);
                int num = 1, num2 = 1;
                string s = null;
                if (ran < range / 2)
                {
                    num = rand.Next(1, range - 1);
                    s = Convert.ToString(num);
                }
                else
                {
                    num = rand.Next(1, range);
                    num2 = rand.Next(1, range);
                    s = "(" + Convert.ToString(num) + "/" + Convert.ToString(num2) + ")";
                }
                return s;
            }
            public string CreatArith()
            {
                string s = null;
                Random rand = new Random();
                int ran = rand.Next(1, 4);
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
            public string createProblem(int range)
            {
                Random r = new Random();            //随机数生成器
                string s="";                        //string题目
                string tempNum = null;              //string数
                string tempOperator = null;         //string运算符
                int operatorNum = r.Next(2, 4);     //运算符的个数
                int bracket_left = 0;               //左括号
                int bracket_right = 0;              //右括号
                bracket_left = r.Next(1, 4);        //第一个字符是否为左括号 概率为1/4
                if (bracket_left == 1)
                {
                    s += "(";
                    bracket_right++;
                }
                s += "" + r.Next(range);            //（4
                for (int j = 0; j < operatorNum; j++)
                {
                    tempOperator = CreatArith();    //生成运算符
                    if (tempOperator.Equals("/"))
                    {
                        tempNum = "" + (r.Next(range) + 1);
                    }
                    else
                    {
                        tempNum = "" + r.Next(range);
                    }                               //生成计算数并保证分母不为0
                    bracket_left = r.Next(3);       
                    if (bracket_left == 1 && j != operatorNum - 1)
                    {
                        s += tempOperator;
                        s += "(";
                        s += tempNum;
                        bracket_right++;            //（4/（3+（5-6）））
                    }
                    else if (bracket_left == 2 && bracket_right != 0 && j != 0)
                    {
                        s += ")";
                        bracket_right--;
                    }                               //
                    s += tempOperator + tempNum;    //
                }
                if (bracket_right!=0)
                {
                    for (int i = 0; i < bracket_right; bracket_right--)
                    {
                        s += ")";
                    }
                }                                   //
                s = subStr(s);//针对特殊情况（4/3+2*1）
                problem = s;
                return s;
            }
            public string subStr(string str)
            {
                char[] s = str.ToCharArray();
                if (s[0] == '('&&s[str.Length-1]==')')
                {
                    int left_no = 0;
                    for (int i = 1; i < str.Length-1; i++)
                    {
                        if (s[i] == ')')
                        {
                            left_no++;
                        }
                        if (s[i]==')')
                        {
                            if (left_no > 0)
                            {
                                left_no--;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    str = str.Substring(1, str.Length - 1);
                }
                return str;
            }
            public List<string> productProblemList()
            {
                try
                {
                    problemList = new List<string>();//不知道为什么要用列表
                    string path = @"d:\test.txt";
                    FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    BinaryWriter write = new BinaryWriter(fs);
                    for (int i = 0; i < problemNum; i++)
                    {
                        string str1 = createProblem(range);//给范围生成一道题目
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return problemList;
            }

        }
        public class GetExp
        {
            public double e;
            public bool flag = false;
            public double getExpression(TreeNode currNode)
            {
                if(currNode.left==null||currNode.right==null)
                {
                    string str = currNode.data;
                    e = Convert.ToInt32(str.Trim());
                    return e;
                }
                else
                {
                    if (currNode.data.Equals("+"))
                    {
                        e = getExpression(currNode.left) + getExpression(currNode.right);
                    }
                    if (currNode.data.Equals("-"))
                    {
                        e = getExpression(currNode.left) - getExpression(currNode.right);
                    }
                    if (currNode.data.Equals("*"))
                    {
                        e = getExpression(currNode.left) * getExpression(currNode.right);
                    }
                    if (currNode.data.Equals("/"))
                    {
                        if(getExpression(currNode.right )!=0)
                        e = getExpression(currNode.left) / getExpression(currNode.right);
                        else { flag = true; }
                    }

                }
                return e;
            }
        }
        public class Result
        {
            private List<TreeNode> treeList;
            private List<string> problemList;
            private string right;
            private string wrong;

            public string attRight
            {
                get { return right; }
                set { right = value; }
            }
            public string attWrong
            {
                get { return wrong; }
                set { wrong = value; }
            }
            public List<TreeNode> attTreeList
            {
                get { return treeList; }
                set { treeList = value; }
            }
            public Result(List<TreeNode> treeList,List<string> problemList)
            {
                this.treeList = treeList;
                this.problemList = problemList;
                right = null;
                wrong = null;
            }
            public void CompareAnswer(String str)
            {
                try
                {
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        static void Main(string[] args)
        {
            Console.Write("Myapp.exe -");//Myapp.exe -n   10
            int n=Convert.ToInt32(Console.ReadLine());
            Console.Write("Myapp.exe -");//Myapp.exe -r   10
            int r=Convert.ToInt32(Console.ReadLine());
            Create cr = new Create();
            cr.attProblemNum = n;
            cr.attRange = r;
            //完成输入工作得到n,r  准备生成题目
            List<string> problemList = cr.productProblemList();
            //在txt中生成好了题目
            Console.WriteLine("请到D:\test.txt完成题目");
            List<TreeNode> treeList = new List<TreeNode>();
            for (int i = 0; i < problemList.; i++)
            {
                TreeNode lastNode = null;
                BinaryTree tree = new BinaryTree();

                lastNode = tree.createTree(problemList.get(i));
                TreeNode node = tree.getNode();
                treeList.add(node);
            }
        }
    }
}
