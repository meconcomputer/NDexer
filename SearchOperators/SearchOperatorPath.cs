using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndexer
{
    public class SearchOperatorPath : ISearchOperator
    {
        readonly string sqlStatement;

        public static string Description
        {
            get { return @"[+]path:value    Search only in files matched by value (wildcard * can be used)" +
                         Environment.NewLine +
                         @"-path:value    Search in files other than those matched by value (wildcard * can be used)"; 
                }
        }

        public SearchOperatorPath(string iValue, bool aIsNegative)
        {
            sqlStatement = ToSQL(iValue, aIsNegative);
        }

        public string ToSQL(String iValue, bool iNegativeSearch)
        {
            StringBuilder aStringBuilder = new StringBuilder("sourcefiles_path");

            if (iNegativeSearch)
                aStringBuilder.Append(" NOT");

            aStringBuilder.Append(" LIKE '" + SQLHelper.StringToSQL(iValue) + "'");

            return aStringBuilder.ToString();
        }

        public override string ToString()
        {
            return sqlStatement;
        }
    }
}
