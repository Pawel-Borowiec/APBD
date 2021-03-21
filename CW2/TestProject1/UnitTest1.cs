using CW2;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            string fakePath = @"dane.csv";
            Assert.False(File.Exists(fakePath));

        }

        [Fact]
        public void checkListElements()
        {
            //arrange
            List<Student> list = new List<Student>();
            list.Add(new Student());
            Student temp = new Student();
            temp.Index = "s18986";
            temp.fName = "Adam";
            list.Add(temp);

   

        }
    }
}
