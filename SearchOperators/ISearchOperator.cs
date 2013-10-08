using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndexer
{
    public interface ISearchOperator
    {
        string ToSQL(string iValue, bool iNegativeSearch);
    }

    public static class SearchOperatorExtensionMethods
    {
        public static string ToSQL(this ISearchOperator[] searchOps)
        {
            var aStringBuilder = new StringBuilder();
            Array.ForEach(searchOps, op => aStringBuilder.Append(op == null ? @"" : (op + @" AND ")));

            if (aStringBuilder.Length > 0)
                aStringBuilder.Append(@" 1 = 1 ");
            return aStringBuilder.ToString();
        }
    }
}
