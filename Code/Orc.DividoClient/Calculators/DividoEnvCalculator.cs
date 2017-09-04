
using System;
using System.Collections.Generic;
using System.Text;
using Orc.Divido.Models.enums;

namespace Orc.Divido.Calculators
{
    public static class DividoEnvCalculator
    {
        public static DividoEnvironment Calculate(string apiKey)
        {
            if (apiKey.StartsWith("testing"))
            {
                return DividoEnvironment.Testing;
            }
            else if (apiKey.StartsWith("staging"))
            {
                return DividoEnvironment.Staging;
            }
            else if (apiKey.StartsWith("dev"))
            {
                return DividoEnvironment.Dev;
            }
            else if (apiKey.StartsWith("sandbox"))
            {
                return DividoEnvironment.Sandbox;
            }
            return DividoEnvironment.Live;
        }
    }
}
