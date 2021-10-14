using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WormsWorld
{
    [TestClass]
    public class NameGeneratorTest
    {
        private NameGenerator nameGenerator = new ();

        [TestMethod]
        public void UniqNamesTest()
        {
            int num = 10;
            HashSet<string> names = new HashSet<string>();
            for (BigInteger i = 0; i < num; i++)
                names.Add(nameGenerator.GetNewName());
            Assert.AreEqual(num, names.Count);
        }
    }
}