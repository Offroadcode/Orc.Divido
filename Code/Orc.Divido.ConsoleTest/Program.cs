using System;
using System.Collections.Generic;
using Orc.Divido.Models.DividoResponses.Partials;

namespace Orc.Divido.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Orc.Divido.DividoClient client = new DividoClient("sandbox_Api.KEY");
            var finances= client.Finances();
            var deal = client.DealCalcualator(1234.51m, 200, "GB", "F0DED2B83-2CE5-15E7-D129-F29309F7F479");
            var offer = client.CreditRequest(200, "F0DED2B83-2CE5-15E7-D129-F29309F7F479", "GB", "EN", 1234.51m, "TEST-01", "GBP", GetTestCustomer(), GetTestProducts(), true, "https://TEST.co.uk/response", "https://TEST.co.uk/checkout", "https://TEST.co.uk/redirect");
            Console.In.Peek();
        }

        private static List<DividoProduct> GetTestProducts()
        {
            var products = new List<DividoProduct>();
            products.Add(new DividoProduct()
            {
                Name = "TEST PRODUCT",
                Price = 1234.51m,
                Quantity = 1,
                Sku = "SKU-01",
                UnitType = "pcs",
                VatPercentage = 20m
            });

            return products;
        }

        private static DividoCustomer GetTestCustomer()
        {
            return new DividoCustomer()
            {
                Bank = new DividoBankDetails()
                {
                    AccountNumber = "1234567",
                    SortCode = "11-22-33"
                },
                BillingAddress = new DividoBillingAddress()
                {
                    BuildingName = "testBuiding",
                    BuildingNumber = "123",
                    Flat = "A",
                    MonthsAtAddress = 50,
                    Postcode = "AB12 3CD",
                    Street = "Baker street",
                    Town = "Townsville"

                },
                Country = "GB",
                DateOfBirthDay = 15,
                DateOfBirthMonth = 12,
                DateOfBirthYear = 1989,
                Email = "stephen@offroadcode.com",
                FirstName = "TESTER",
                Gender = "MALE",
                LastName = "TESTING",
                MiddleNames = "TEST",
                PhoneNumber = "01234567891",
                ShippingAddress = new DividoAddress()
                {

                    BuildingName = "testBuiding",
                    BuildingNumber = "123",
                    Flat = "A",
                    Postcode = "AB12 3CD",
                    Street = "Baker street",
                    Town = "Townsville"
                }

            };
        }
    }
}