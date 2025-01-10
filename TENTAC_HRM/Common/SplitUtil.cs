using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TENTAC_HRM.Common
{
    public static class SplitUtil
    {
        public static string[] SplitStringWithSeparator(string targetStr, char separator)
        {
            var values = targetStr.Split(separator);
            var valueList = new List<string>();
            valueList.AddRange(values);

            for (int i = 0; i < valueList.Count; ++i)
            {
                if (valueList[i] != string.Empty && valueList[i].TrimStart()[0] == '"')
                {
                    while (valueList[i].TrimEnd()[valueList[i].TrimEnd().Length - 1] != '"')
                    {
                        valueList[i] = valueList[i] + separator + valueList[i + 1];
                        valueList.RemoveAt(i + 1);
                    }
                }
            }

            var resultList = new List<string>();

            foreach (var value in valueList)
            {
                if (value.StartsWith("\"") && value.EndsWith("\""))
                {
                    resultList.Add(value.TrimStart('"').TrimEnd('"'));
                }
                else
                {
                    resultList.Add(value);
                }
            }
            return resultList.ToArray();
        }
    }
}
