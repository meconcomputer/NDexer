using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndexer
{
    class SQLHelper
    {
        public static String StringToSQL(String aString)
        {
            if (aString.Length < 1) return String.Empty;

            StringBuilder aSourceBuilder = new StringBuilder(aString);

            aSourceBuilder.Replace('*', '%');
            aSourceBuilder.Replace("'", "\\'");

            return aSourceBuilder.ToString();
        }
    }
}
