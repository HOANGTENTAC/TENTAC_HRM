using System.Collections.Generic;

namespace TENTAC_HRM.Common
{
    public class ParamUtil
    {
        public static Dictionary<string, string> ConvertParamToDictionary(string[] args)
        {
            var resultDictionary = new Dictionary<string, string>();

            string key = null;
            // パラメータの配列を廻す
            foreach (var item in args)
            {
                if (item.StartsWith("-"))
                {
                    if (key != null)
                    {
                        resultDictionary.Add(key, string.Empty);
                    }
                    key = item;
                }
                else
                {
                    if (key != null)
                    {
                        resultDictionary.Add(key, item);
                    }
                    key = null;
                }
            }

            if (key != null)
            {
                resultDictionary.Add(key, string.Empty);
            }

            return resultDictionary;
        }

        public static string SetDoublequotation(string parm, string quote = "\"")
        {
            if (parm.IndexOf(" ") >= 0 | parm.IndexOf("　") >= 0)
            {
                return quote + parm + quote;
            }
            else
            {
                return parm;
            }
        }
    }
}
