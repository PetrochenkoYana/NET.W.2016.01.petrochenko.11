using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Task3;

namespace Task3Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Set<string> firstset=new Set<string>(new []{"abc","ghg","fhr","drt"},4);
            Set<string> secondset = new Set<string>(new[] { "abc", "g", "fhr", "vkbx" },4);
            firstset.Add("try");
            Set<string> resulSet1 = firstset - secondset;
            Set<string> resulSet2 = firstset + secondset;
            Set<string> resulSet3 = firstset * secondset;
            Set<string> resulSet4 = firstset + secondset;
            firstset.UnionWith(secondset);
            firstset.IntersectWith(secondset);
            firstset.Remove("drt");
            foreach (var element in resulSet1)
            {
                Console.WriteLine(element);
            }

        }
     
    }
}
