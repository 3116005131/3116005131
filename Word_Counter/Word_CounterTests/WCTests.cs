using Microsoft.VisualStudio.TestTools.UnitTesting;
using Word_Counter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Counter.Program.Tests
{
    [TestClass()]
    public class WCTests
    {
        [TestMethod()]
        public void WCTest()
        {
            // arrange
            string expected = "字符数：138";
            WC testwc = new WC();

            // act
            string[] opar = new string[1];
            opar[0] = "-c";

            string actual = testwc.Operator(opar, @"D:\text.txt");

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}