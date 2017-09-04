using System;
using System.Collections.Generic;
using System.Text;
using Orc.Divido.Models.DividoResponses.Partials;

namespace Orc.Divido.Calculators
{
    public class PostDataCalculator
    {

        public static void Merge(ref Dictionary<string, string> parameters, List<IConvertibleToPostData> products, string v)
        {

            int i = 1;
            foreach(var item in products)
            {
                Merge(ref parameters, item, v + "," + i);
                    i++;
            }
        }
        public static void Merge(ref Dictionary<string, string> to, IConvertibleToPostData from, string prefix)
        {
            if(from == null)
            {
                return;
            }
            var newItems = from.GetPostKeys();
            foreach(var item in newItems)
            {
                var key = item.Key;
                var value = item.Value;

                var newKey = string.Format("{0},{1}", prefix, key);

                to.Add(newKey, value);
            }
        }

        public static Dictionary<string, string>  FinalizeKeys(Dictionary<string, string> parameters)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();

            foreach(var param in parameters)
            {
                var components = param.Key.Split(',');
                if(components.Length == 1)
                {
                    newData.Add(param.Key, param.Value);
                }
                else
                {
                    string newKey = "";
                    bool isFirst = true;
                    foreach(var item in components)
                    {
                        if (isFirst)
                        {
                            newKey = item;
                            isFirst = false;
                        }
                        else{
                            newKey = newKey + "["+item+"]";
                        }
                    }

                    newData.Add(newKey, param.Value);

                }


                
            }

            return newData;
        }
    }
}
