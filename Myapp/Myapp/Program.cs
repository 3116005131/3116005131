using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myapp
{
    class Program
    {
        public class TreeNode
        {
            string data;
            TreeNode left;
            TreeNode right;

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
                string lefrString;
                string rightString;
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
                }
                return newNode;
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
