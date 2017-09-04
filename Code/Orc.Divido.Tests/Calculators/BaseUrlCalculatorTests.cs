using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orc.Divido.Calculators;

namespace Orc.Divido.Tests.Calculators
{
    [TestClass]
    public class BaseUrlCalculatorTests
    {
        [TestMethod]
        public void Test_TestingEnvironment()
        {
            var calculated = BaseUrlCalculator.Calculate(Models.enums.DividoEnvironment.Testing);
            Assert.AreEqual("https://testing.sandbox.divido.com", calculated);
        }
        [TestMethod]
        public void Test_SandboxEnvironment()
        {
            var calculated = BaseUrlCalculator.Calculate(Models.enums.DividoEnvironment.Sandbox);
            Assert.AreEqual("https://secure.sandbox.divido.com", calculated);
        }
        [TestMethod]
        public void Test_LiveEnvironment()
        {
            var calculated = BaseUrlCalculator.Calculate(Models.enums.DividoEnvironment.Live);
            Assert.AreEqual("https://secure.divido.com", calculated);
        }
        [TestMethod]
        public void Test_StagingEnvironment()
        {
            var calculated = BaseUrlCalculator.Calculate(Models.enums.DividoEnvironment.Staging);
            Assert.AreEqual("https://staging.sandbox.divido.com", calculated);
        }
        [TestMethod]
        public void Test_DevEnvironment()
        {
            var calculated = BaseUrlCalculator.Calculate(Models.enums.DividoEnvironment.Dev);
            Assert.AreEqual("http://secure.divido.net", calculated);
        }
    }
}
