using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Orc.Divido.Calculators;

namespace Orc.Divido.Models.DividoResponses.Partials
{
    public class DividoCustomer :IConvertibleToPostData
    {
        public string FirstName { get; set; }

        public string MiddleNames { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int DateOfBirthYear { get; set; }

        public int DateOfBirthMonth { get; set; }

        public int DateOfBirthDay { get; set; }

        public DividoBankDetails Bank { get; set; }

        public DividoAddress ShippingAddress { get; set; }

        public DividoBillingAddress BillingAddress { get; set; }

        Dictionary<string, string> IConvertibleToPostData.GetPostKeys()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("firstName", FirstName);
            values.Add("middleNames", MiddleNames);
            values.Add("lastName", LastName);
            values.Add("country", Country);
            values.Add("gender", Gender);
            values.Add("email", Email);
            values.Add("phoneNumber", PhoneNumber);
            values.Add("dateOfBirthYear", DateOfBirthYear.ToString());
            values.Add("dateOfBirthMonth", DateOfBirthMonth.ToString());
            values.Add("dateOfBirthDay", DateOfBirthDay.ToString());

            PostDataCalculator.Merge(ref values, Bank, "bank");
            PostDataCalculator.Merge(ref values, ShippingAddress, "shippingAddress");
            PostDataCalculator.Merge(ref values, BillingAddress, "address");

            return values;
        }
        
    }

    public class DividoBankDetails : IConvertibleToPostData
    {
        public string SortCode { get; set; }

        public string AccountNumber { get; set; }

        public Dictionary<string, string> GetPostKeys()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("sortCode", SortCode);
            values.Add("accountNumber", AccountNumber);

            return values;
        }
    }
}
