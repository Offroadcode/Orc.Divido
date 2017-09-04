using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orc.Divido.Calculators;
using Orc.Divido.Models.DividoResponses.Partials;

namespace Orc.Divido.Tests.Calculators
{
    [TestClass]
    public class PostDataCalculatorTests
    {
        [TestMethod]
        public void TestOne()
        {
            var customer = new DividoCustomer();
            customer.Country = "GB";
            customer.DateOfBirthDay = 15;
            customer.DateOfBirthMonth = 12;
            customer.DateOfBirthYear = 1989;
            customer.Email = "stephen@offroadcode.com";
            customer.FirstName = "Stephen";
            customer.Gender = "Male";
            customer.Bank = new DividoBankDetails() { AccountNumber = "1234567", SortCode = "55-55-55" };

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            parameters.Add("amount", "1234");
            parameters.Add("reference", "reg-2");

            //customer
            //products
            PostDataCalculator.Merge(ref parameters, customer, "customer");
            parameters = PostDataCalculator.FinalizeKeys(parameters);
            Assert.Fail();
        }
    }
}
