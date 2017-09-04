using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Orc.Divido.Models.DividoResponses.Partials;
using Orc.Divido.Models.enums;

namespace Orc.Divido.Models.DividoResponses
{
    [DataContract()]
    public class DividoCancellationResponse : _BaseDividoResponse
    {
        [DataMember(Name = "result")]
        public DividoResult Result { get; set; }
    }

}
