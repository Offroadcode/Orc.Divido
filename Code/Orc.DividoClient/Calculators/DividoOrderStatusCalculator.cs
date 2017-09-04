using System;
using System.Collections.Generic;
using System.Text;
using Orc.Divido.Models.enums;

namespace Orc.Divido.Calculators
{
    public static class DividoOrderStatusCalculator
    {
        public static string ToDividoStatusString(DividoOrderStatus? status)
        {
            if(status == null)
            {
                return null;
            }
            return status.ToString().Replace("_", "-");
        }

        public static DividoOrderStatus FromDividoOrderStatus(string status)
        {
            status = status.Replace("-", "_");
            return (DividoOrderStatus)Enum.Parse(typeof(DividoOrderStatus), status);
        }
    }
}
