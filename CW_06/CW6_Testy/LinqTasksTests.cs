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
        [TestMethod()]
        public void Task11Test()
        {
            var output = LinqTasks.Task11().ToList();
            Assert.IsTrue(output.Count == 2);
            Assert.AreEqual(output[0].ToString(),"{ name = Research, numOfEmployes = 3 }");
            Assert.AreEqual(output[1].ToString(), "{ name = Human Resources, numOfEmployes = 6 }");
            Console.WriteLine(output[0].ToString());
        }
        [TestMethod()]
        public void Task12Test()
        {
            List<Emp> emps = LinqTasks.Emps.ToList();
            List<Emp> output = LinqTasks.Task12().ToList();
            Assert.IsTrue(output.Count == 2);
            Assert.AreEqual(output[0], emps[0]);
            Assert.AreEqual(output[1], emps[1]);
        }
        [TestMethod()]
        public void Task13Test()
        {
            Assert.IsTrue(10 == LinqTasks.Task13(new int[] { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1 }));
            Assert.IsTrue(20 == LinqTasks.Task13(new int[] { 1, 4, 1, 20, 4, 5, 20, 5, 1, 20, 1 }));
            Assert.IsTrue(6 == LinqTasks.Task13(new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6 }));
        }
        [TestMethod()]
        public void Task14Test()
        {
            List<Dept> output = LinqTasks.Task14().ToList();
            Assert.IsTrue(1 == output.Count());
            Assert.AreEqual("IT", output[0].Dname);
            Assert.AreEqual("Los Angeles", output[0].Loc);
        }
    }
}