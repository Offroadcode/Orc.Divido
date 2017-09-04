using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orc.Divido.Models.DividoResponses
{
    [DataContract()]
    public class DividoFinalizeCreditRequestResponse : _BaseDividoResponse
    {

        [DataMember(Name = "id")]
        public string ApplicationId { get; set; }
        [DataMember(Name = "token")]
        public string Token { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
