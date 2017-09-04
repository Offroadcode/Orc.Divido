using System;
using System.Collections.Generic;
using System.Text;

namespace Orc.Divido.Calculators
{
   public static class BaseUrlCalculator
    {
        public static string Calculate(Models.enums.DividoEnvironment environment)
        {

            switch (environment)
            {
                case Models.enums.DividoEnvironment.Testing:
                    return "https://testing.sandbox.divido.com";
                case Models.enums.DividoEnvironment.Sandbox:
                    return "https://secure.sandbox.divido.com";
                case Models.enums.DividoEnvironment.Live:
                    return "https://secure.divido.com";
                case Models.enums.DividoEnvironment.Staging:
                    return "https://staging.sandbox.divido.com";
                case Models.enums.DividoEnvironment.Dev:
                    return "http://secure.divido.net";
                
                default:
                    throw new ArgumentException("environment: I do not know the correct environment for the specified 'DividoEnvironment'");
            }
        }
    }
}