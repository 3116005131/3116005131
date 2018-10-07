using Oct5th;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct5th
{
    public enum Esex : int
    {
        Unknow,
        Male,
        Female
    }
    public struct SHuman
    {
        public string Name;
        private int myAge;
        public int Age
        {
            get { return myAge; }
            set
            {
                if (value>=18&&value<=60)
                {
                    myAge = value;
                }
                else
                {
                    Console.WriteLine("有效年龄值应该在18到60岁之间");
                }
            }
        }
    }
    interface InterfaceDemo5
    {
        void Test();
    }
    interface I1
    {
        void Test();
    }
    class C1 : InterfaceDemo5, I1
    {
        void I1.Test()
        {
            Console.WriteLine("I1.Test");
        }

        void InterfaceDemo5.Test()
        {
            Console.WriteLine("Demo5.Test()");
        }
    }
}
