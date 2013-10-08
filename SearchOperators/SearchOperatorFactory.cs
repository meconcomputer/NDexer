using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ndexer
{
    public static class SearchOperatorFactory
    {
        static string _description;

        static Dictionary<string, Type> SearchOperatorsDictionary = new Dictionary<string, Type>()
            {
                { "path", typeof(SearchOperatorPath)} 
            };

        public static string Description
        {
            get
            {
                if (_description == null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var d in SearchOperatorsDictionary)
                    {
                        PropertyInfo descriptionProperty = d.Value.GetProperty("Description", BindingFlags.Public | BindingFlags.Static);

                        if (descriptionProperty == null) continue;
                        if (descriptionProperty.GetGetMethod() == null) continue;

                        sb.Append(Environment.NewLine);
                        sb.AppendLine("-----------");
                        sb.AppendLine(descriptionProperty.GetValue(null, null).ToString());

                        _description = sb.ToString();
                    }
                }

                return _description;
            }
        }

        public static ISearchOperator GetSearchOperatorInstance(String iValue)
        {
            bool aIsNegative = false;
            int aValueIndex;
            string aOperator;

            if (iValue.Length < 1) return null;

            if (iValue[0] == '+')
                iValue = iValue.Substring(1);

            if (iValue[0] == '-')
            {
                aIsNegative = true;
                iValue = iValue.Substring(1);
            }

            aValueIndex = iValue.IndexOf(':');
            if (aValueIndex < 0) return null;

            aOperator = iValue.Substring(0, aValueIndex);
            iValue = iValue.Substring(aValueIndex + 1);

            if ( SearchOperatorsDictionary[aOperator] == null || 
                 typeof(ISearchOperator).IsAssignableFrom(SearchOperatorsDictionary[aOperator]) == false ) 
                return null;

            return (ISearchOperator)Activator.CreateInstance(SearchOperatorsDictionary[aOperator], iValue, aIsNegative);
        }
    }
}
