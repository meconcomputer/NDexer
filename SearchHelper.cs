using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ndexer
{
    [Flags]
    public enum SearchFlags
    {
        None = 0,
        SearchOperators = 1,
        SearchCaseSensitive = 2,
        SearchRegex = 4
    }
}
