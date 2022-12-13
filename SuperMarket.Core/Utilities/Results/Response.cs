using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Utilities.Results
{
    public class Response : IResponse
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, string message)
        {
            ResponseType = responseType;
            Message = message;
        }
        public Response(ResponseType responseType, List<CustomValidationError> errors)
        {
            ResponseType = responseType;
            ValidationErrors = errors;
        }

        public string Message { get; set; }

        public ResponseType ResponseType { get; set; }

        public List<CustomValidationError> ValidationErrors{ get; set; }
    }
}
