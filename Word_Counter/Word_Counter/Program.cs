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
        public class WC
        {
            private string sFilename;    // 文件名
            private string[] sParameter; // 参数数组  
            private int iCharcount;      // 字符数
            private int iWordcount;      // 单词数
            private int iLinecount;      // 行  数
            private int iNullLinecount;  // 空行数
            private int iCodeLinecount;  // 代码行数
            private int iNoteLinecount;  // 注释行数

            // 初始化
            public WC()
            {
                this.iCharcount = 0;
                this.iWordcount = 0;
                this.iLinecount = 0;
                this.iNullLinecount = 0;
                this.iCodeLinecount = 0;
                this.iNoteLinecount = 0;
            }
            // 控制信息
            public string Operator(string[] sParameter, string sFilename)
            {
                this.sParameter = sParameter;
                this.sFilename = sFilename;

                string retrun_str = "";

                foreach (string s in sParameter)
                {
                    if (s == "-s")
                    {
                        try
                        {
                            string[] arrPaths = sFilename.Split('\\');
                            int pathsLength = arrPaths.Length;
                            string path = "";

                            // 获取输入路径
                            for (int i = 0; i < pathsLength - 1; i++)
                            {
                                arrPaths[i] = arrPaths[i] + '\\';

                                path += arrPaths[i];
                            }

                            // 获取通配符
                            string filename = arrPaths[pathsLength - 1];

                            //  获取符合条件的文件名
                            string[] files = Directory.GetFiles(path, filename);

                            foreach (string file in files)
                            {
                                //Console.WriteLine("文件名：{0}", file);
                                SuperCount(file);
                                BaseCount(file);
                                retrun_str = Display();
                            }
                            break;
                        }
                        catch (IOException )
                        {
                            //Console.WriteLine(ex.Message);
                            return "";
                        }
                    }
                    // 高级选项
                    else if (s == "-a")
                    {
                        //Console.WriteLine("文件名：{0}", sFilename);
                        SuperCount(sFilename);
                        BaseCount(sFilename);
                        retrun_str = Display();
                        break;
                    }
                    //  基本功能
                    else if (s == "-c" || s == "-w" || s == "-l")
                    {
                        //Console.WriteLine("文件名：{0}", sFilename);
                        BaseCount(sFilename);
                        retrun_str = Display();
                        break;
                    }
                    else
                    {
                        //Console.WriteLine("参数 {0} 不存在", s);
                        break;
                    }
                }
                Console.WriteLine("{0}", retrun_str);
                return retrun_str;
            }

            // 统计基本信息：字符数 单词数 行数
            private void BaseCount(string filename)
            {
                try
                {
                    // 打开文件
                    FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                    StreamReader sr = new StreamReader(file);
                    int nChar;
                    int charcount = 0;
                    int wordcount = 0;
                    int linecount = 0;
                    //定义一个字符数组
                    char[] symbol = { ' ', ',', '.', '?', '!', ':', ';', '\'', '\"', '\t', '{', '}', '(', ')', '+' ,'-',
                  '*', '='};
                    while ((nChar = sr.Read()) != -1)
                    {
                        charcount++;     // 统计字符数

                        foreach (char c in symbol)
                        {
                            if (nChar == (int)c)
                            {
                                wordcount++; // 统计单词数
                            }
                        }
                        if (nChar == '\n')
                        {
                            linecount++; // 统计行数
                        }
                    }
                    iCharcount = charcount;
                    iWordcount = wordcount + 1;
                    iLinecount = linecount + 1;
                    sr.Close();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            // 统计高级信息：空行数 代码行数 注释行数
            private void SuperCount(string filename)
            {
                try
                {
                    // 打开文件
                    FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                    StreamReader sr = new StreamReader(file);
                    String line;
                    int nulllinecount = 0;
                    int codelinecount = 0;
                    int notelinecount = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim(' ');
                        line = line.Trim('\t');
                        //   空行
                        if (line == "" || line.Length <= 1)
                        {
                            nulllinecount++;
                        }
                        //   注释行
                        else if (line.Substring(0, 2) == "//" || line.Substring(1, 2) == "//")
                        {
                            notelinecount++;
                        }
                        // 代码行
                        else
                        {
                            codelinecount++;
                        }
                    }
                    iNullLinecount = nulllinecount;
                    iCodeLinecount = codelinecount;
                    iNoteLinecount = notelinecount;
                    sr.Close();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            // 打印信息
            private string Display()
            {
                string return_str = "";

                foreach (string s in sParameter)
                {
                    if (s == "-c")
                    {
                        //Console.WriteLine("字 符 数：{0}", iCharcount);
                        return_str += "字符数：" + iCharcount.ToString();
                    }
                    else if (s == "-w")
                    {
                        //Console.WriteLine("单 词 数：{0}", iWordcount);
                        return_str += "单词数：" + iWordcount.ToString();
                    }
                    else if (s == "-l")
                    {
                        //Console.WriteLine("总 行 数：{0}", iLinecount);
                        return_str += "总行数：" + iLinecount.ToString();
                    }
                    else if (s == "-a")
                    {
                        //Console.WriteLine("空 行 数：{0}", iNullLinecount);
                        //Console.WriteLine("代码行数：{0}", iCodeLinecount);
                        //Console.WriteLine("注释行数：{0}", iNoteLinecount);
                        return_str += "空行数：" + iNullLinecount.ToString();
                        return_str += "代码行数：" + iCodeLinecount.ToString();
                        return_str += "注释行数：" + iNoteLinecount.ToString();
                    }
                }
                //Console.WriteLine();
                return return_str;
            }
            private string DisplayAll()
            {
                string return_str = "";
                foreach (string s in sParameter)
                {
                    //Console.WriteLine("字 符 数：{0}", iCharcount);
                    //Console.WriteLine("单 词 数：{0}", iWordcount);
                    //Console.WriteLine("总 行 数：{0}", iLinecount);
                    //Console.WriteLine("空 行 数：{0}", iNullLinecount);
                    //Console.WriteLine("代码行数：{0}", iCodeLinecount);
                    //Console.WriteLine("注释行数：{0}", iNoteLinecount);
                    return_str += "字符数：" + iCharcount.ToString();
                    return_str += "单词数：" + iWordcount.ToString();
                    return_str += "总行数：" + iLinecount.ToString();
                    return_str += "空行数：" + iNullLinecount.ToString();
                    return_str += "代码行数：" + iCodeLinecount.ToString();
                    return_str += "注释行数：" + iNoteLinecount.ToString();
                }
                //Console.WriteLine();
                return return_str;
            }
        }
        static void Main(string[] args)
        {
            /*Console.Write("wc.exe ");
            string s = Console.ReadLine();
            string[] strs = s.Split(' ');
            string path = strs[1];
            Console.WriteLine(path);
            int c = 0;
            int w = 0;
            int l = 0;
            char[] point = { ' ', '\t', '\n', '.', ',', '?', ':', ';', '_' };
            FileStream fs = null;
            StreamReader reader = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fs);
                int i = reader.Read();
                while (i != -1)
                {
                    c++;
                    char character = (char)i;
                    if (character=='\n')
                    {
                        l++;
                    }
                    foreach (char p in point)
                    {
                        if (p==character)
                        {
                            w++;
                        }
                    }
                    i = reader.Read();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                reader.Close();
                fs.Close();
            }
            string str = strs[0];
            if (str[1] == 'c')
            {
                Console.WriteLine("字符数为{0}", c);
            }
            else if (str[1] == 'w')
            {
                Console.WriteLine("单词数为{0}", w);
            }
            else
                Console.WriteLine("行数为{0}", l);
            Console.ReadLine();*/

        }
    }
}
