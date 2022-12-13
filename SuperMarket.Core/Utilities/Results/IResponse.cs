using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Utilities.Results
{
    public interface IResponse
    {
        public string Message { get; }
        public ResponseType ResponseType { get; }
        List<CustomValidationError> ValidationErrors { get; set; }
    }
}
