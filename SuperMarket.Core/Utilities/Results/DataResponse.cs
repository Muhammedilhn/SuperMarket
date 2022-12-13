using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Utilities.Results
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public DataResponse(ResponseType responseType,T data) 
        {
            ResponseType = responseType;
            Data = data;
        }
        public DataResponse(ResponseType responseType, string message)
        {
            ResponseType = responseType;
            Message = message;
        }
        public DataResponse(ResponseType responseType, T data, List<CustomValidationError> errors) 
        {
            ResponseType = responseType;
            ValidationErrors = errors;
            Data = data;
        }
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }

        public ResponseType ResponseType { get; set; }

        public string Message { get; set; }
    }
}
