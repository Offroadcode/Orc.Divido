using System.Collections.Generic;

namespace Orc.Divido.Calculators
{
    public interface IConvertibleToPostData
    {
        Dictionary<string, string> GetPostKeys();
    }
}