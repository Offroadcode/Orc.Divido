using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Orc.Divido.Calculators;

namespace Orc.Divido.Models.DividoResponses.Partials
{
    public class DividoAddress :IConvertibleToPostData
    {
        public string Town { get; set; }

        public string BuildingName { get; set; }

        public string BuildingNumber { get; set; }

        public string Flat { get; set; }

        public string Street { get; set; }

        public string Postcode { get; set; }

        public Dictionary<string, string> GetPostKeys()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("town", Town);

            values.Add("buildingName", BuildingName);

            values.Add("buildingNumber", BuildingNumber);

            values.Add("flat", Flat);

            values.Add("street", Street);

            values.Add("postcode", Postcode);
            return values;
        }
    }

    public class DividoBillingAddress: DividoAddress, IConvertibleToPostData
    {
        public int MonthsAtAddress { get; set; }

        public new Dictionary<string, string> GetPostKeys()
        {
            var baseKeys = base.GetPostKeys();

            baseKeys.Add("monthsAtAddress", MonthsAtAddress.ToString());

            return baseKeys;
        }
    }
}
