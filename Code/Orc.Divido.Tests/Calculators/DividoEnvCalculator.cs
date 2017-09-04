using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orc.Divido.Calculators;
using Orc.Divido.Models.enums;

namespace Orc.Divido.Tests.Calculators
{
    [TestClass]
    public class DividoEnvCalculatorTests
    {
        [TestMethod]
        public void Test_SandboxEnvironment()
        {
            
            var result =  DividoEnvCalculator.Calculate("sandbox_aasdasdasdasd.sdafsdaljkhfgsk;jahf");
            Assert.AreEqual(DividoEnvironment.Sandbox, result);
        }
        [TestMethod]
        public void Test_LiveEnvironment()
        {
            var result = DividoEnvCalculator.Calculate("aasdasdasdasd.sdafsdaljkhfgsk;jahf");
            Assert.AreEqual(DividoEnvironment.Live, result);
        }
    }
}