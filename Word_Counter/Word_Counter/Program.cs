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
            string path = @"D:\textEng.txt";
            StreamReader reader;
            reader = new StreamReader(path, System.Text.Encoding.Default);
            reader.BaseStream.Seek(10, SeekOrigin.Begin);
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine("{0}", line);
                line = reader.ReadLine();
            }
            reader.Close();
            Console.ReadLine();
        }
    }
}
