using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orc.Divido.Models.DividoResponses
{
    [DataContract()]

    public class _BaseDividoResponse
    {
        [DataMember(Name = "status")]        
        public string Status { get; set; }

        [DataMember(Name = "error")]
        public string ErrorMessage { get; set; }

        public string RequestUrl { get; set; }
        public string RequestData { get; set; }
    }
}
