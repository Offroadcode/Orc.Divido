using System;
using System.Collections.Generic;
using System.Text;
using Orc.Divido.Models.DividoResponses;
using Orc.Divido.Requestor;

namespace Orc.Divido
{
    public interface IDividoRequestor
    {
        T Get<T>(string endpoint,  Dictionary<string, string> parameters) where T : _BaseDividoResponse, new();
        T Post<T>(string endpoint, Dictionary<string, string> parameters) where T : _BaseDividoResponse, new();
    }
}
