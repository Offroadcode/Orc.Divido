using System;
using System.Collections.Generic;
using System.Text;

namespace Orc.Divido.Models
{
    public class DividoApiException : Exception
    {
        public DividoApiException(string message) : base(message)
        {
        }
    }
}
