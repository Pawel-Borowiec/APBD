using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqTutorials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTutorials.Models;

namespace LinqTutorials.Tests
{
    [TestClass()]
    public class LinqTasksTests
    {
        [TestMethod()]
        public void Task1Test()
        {
            Assert.IsTrue(LinqTasks.Task1().Contains(LinqTasks.Emps.ToList()[0]));
            Assert.IsTrue(LinqTasks.Task1().Contains(LinqTasks.Emps.ToList()[4]));
        }
        [TestMethod()]
        public void Task2Test()
        {
            Assert.IsTrue(LinqTasks.Task2().Contains(LinqTasks.Emps.ToList()[1]));
            Assert.IsTrue(LinqTasks.Task2().Contains(LinqTasks.Emps.ToList()[2]));
            Assert.IsTrue(LinqTasks.Task2().Contains(LinqTasks.Emps.ToList()[3]));
        }

        [TestMethod()]
        public void Task3Test()
        {
            Assert.AreEqual(12000,LinqTasks.Task3());
        }

        [TestMethod()]
        public void Task4Test()
        {
            Assert.IsTrue(LinqTasks.Task4().Contains(LinqTasks.Emps.ToList()[8]));
        }

        [TestMethod()]
        public void Task8Test()
        {
            Assert.IsTrue(LinqTasks.Task8());
        }


        [TestMethod()]
        public void Task9Test()
        {

            Assert.AreEqual(LinqTasks.Emps.ToList()[1],LinqTasks.Task9());
        }
    }
}