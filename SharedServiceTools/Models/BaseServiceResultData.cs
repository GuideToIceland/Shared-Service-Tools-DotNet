using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class BaseServiceResultData<TData>
    {
        public BaseServiceResultData()
        {
        }

        public BaseServiceResultData(TData data)
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Data = data;
        }

        public BaseServiceResultData(HttpStatusCode statusCode, string error)
        {
            this.StatusCode = statusCode;
            this.Error = error;
        }

        public TData Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Error { get; set; }
    }
}
