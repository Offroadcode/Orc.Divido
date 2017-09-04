using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Orc.Divido.Calculators;

namespace Orc.Divido.Models.DividoResponses.Partials
{
    [DataContract]
    public class DividoProduct : IConvertibleToPostData
    {
        /// <summary>
        ///  Product SKU (Optional, String)
        ///  Example `GIB100`
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// Product name/description (Optional, String)
        /// Example `Gibson Les Paul Studio Raw Guitar`
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product quantity (Optional, String)
        /// Example `1`
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product price in same currency as proposal (Optional, String)
        /// Example `1153.00`
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product VAT percentage(Optional, String)
        /// Example `20`
        /// /// </summary>
        public decimal VatPercentage { get; set; }

        /// <summary>
        /// Product unit (Optional, String)
        /// Example `pcs`
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// Product image (Optional, String)
        /// Example `http://www.webshop.com/images/GIB100.png`
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Product attributes (1=Service fee,2=Shipping fee,3=Payment fee,6=Discount, 10=Price is without VAT, 20=Line item with order VAT sum) (Optional, String)
        /// Example `1,2`
        /// </summary>
        public string Attributes { get; set; }

        public Dictionary<string, string> GetPostKeys()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("sku", Sku);
            values.Add("name", Name);
            values.Add("quantity", Quantity.ToString());
            values.Add("price", Price.ToString());
            values.Add("vat", VatPercentage.ToString());
            values.Add("unit", UnitType);
            values.Add("image", Image);
            values.Add("attributes", Attributes);
            return values;
        }

    }
}
