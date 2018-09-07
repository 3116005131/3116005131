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
            string path = @"d:\text.dat";
            FileStream fs = null;
            BinaryReader reader = null;
            try
            {
                fs = new FileStream(path, FileMode.Open);
                reader = new BinaryReader(fs);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                string s = reader.ReadString();
                while (true)
                {
                    Console.WriteLine(s);
                    s = reader.ReadString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (fs != null) fs.Close();
            }
            Console.ReadLine();
        }
    }
}
