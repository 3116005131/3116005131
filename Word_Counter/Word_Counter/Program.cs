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
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);//其中，参数output 用于设置流对象，通常是由FileStream 类实例化的对象。
            writer.BaseStream.Seek(0, SeekOrigin.Begin);
            writer.Write("中华人民共和国");
            writer.Close();
            fs.Close();
        }
    }
}
