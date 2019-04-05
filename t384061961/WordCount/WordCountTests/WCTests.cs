using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    [TestClass()]
    public class WCTests
    {
        [TestMethod()]
        public void WCTest()
        {
            string expected = "字符数   ：171" + "\n" ;
            string[] opar = new string[1];
            opar[0] = "-c";
            WC testWc = new WC(opar);
            string actual = testWc.Order(@"D:\Patch\test1.txt");
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BaseCountTest()
        {
            /*
            int expected = 105;
            string[] opar = new string[1];
            opar[0] = "-c";
            WC testWc = new WC(opar, @"D:\Patch\test1.txt");
           
            int iCharcount = testWc.BaseCount(@"D:\Patch\test1.txt");
            Assert.AreEqual(expected, iCharcount);
            */
        }

        [TestMethod()]
        public void SuperCountTest()
        {
            /*
            int expected = 0;
            string[] opar = new string[1];
            opar[0] = "-a";
            WC testWc = new WC(opar, @"D:\Patch\test1.txt");

            int iCharcount = testWc.SuperCount(@"D:\Patch\test1.txt");
            Assert.AreEqual(expected, iCharcount);
            */
        }
        

        [TestMethod()]
        public void OrderTest()
        {
            string expected = "目录 ：D:\\Patch 中没有此格式的文件！！";
            string[] opar = new string[1];
            opar[0] = "-s";
            WC testWc = new WC(opar);
            string actual = testWc.Order("*.doc");
            Assert.AreEqual(expected, actual);
        }
       }
}