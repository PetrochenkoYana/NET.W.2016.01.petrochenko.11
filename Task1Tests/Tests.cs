using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Task1;

namespace Task1Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            foreach (long element in Fibonacci.GetEnumerator(10))
                Console.WriteLine(element.ToString());
            
        }
    }
}
