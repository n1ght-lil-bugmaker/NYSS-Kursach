using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Models;

namespace Tests
{
    [TestClass]
    public class IncorrectSituations
    {
        [TestMethod]
        public void IncorrectKey1()
        {
            var enc = new Encoding();

            Assert.ThrowsException<Exception>(() =>
            {
                enc.Key = "AVWACX";
            });
        }

        [TestMethod]
        public void IncorrectKey2()
        {
            var enc = new Encoding();

            Assert.ThrowsException<Exception>(() =>
            {
                enc.Key = "Cкорпион1";
            });
        }
    }
}
