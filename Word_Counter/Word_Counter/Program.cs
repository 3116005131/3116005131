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
        static void Main(string[] args)
        {
            Console.Write("wc.exe ");
            string s = Console.ReadLine();
            string[] strs = s.Split(' ');
            string path = '@'+strs[1];
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
            Console.ReadLine();
        }
    }
}
