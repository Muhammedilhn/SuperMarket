using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Utilities.Results
{
    public enum ResponseType
    {
        Success = 0,
        Error = 1,
        ValidationError = 2,
        NotFound = 3,
    }
}
