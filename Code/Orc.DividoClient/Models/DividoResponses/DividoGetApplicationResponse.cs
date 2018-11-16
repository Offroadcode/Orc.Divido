using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Orc.Divido.Models.DividoResponses.Partials;
using Orc.Divido.Models.enums;

namespace Orc.Divido.Models.DividoResponses
{
    [DataContract()]
    public class DividoGetApplicationResponse : _BaseDividoResponse
    {
        [DataMember(Name = "records")]
        public DividoListAllApplicationsRecord Record { get; set; }
    }
}
