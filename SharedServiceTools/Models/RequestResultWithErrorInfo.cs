using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools.Models
{
    public class RequestResultWithErrorInfo<TData> : RequestResult<TData, ErrorInfo>
    {
        public RequestResultWithErrorInfo()
        {
        }

        public RequestResultWithErrorInfo(HttpStatusCode statusCode, TData data)
            : base(statusCode, data)
        {
        }

        public RequestResultWithErrorInfo(HttpStatusCode statusCode, ErrorInfo errorInfo)
            : base(statusCode, errorInfo)
        {
        }

        public override bool IsValid => this.StatusCode == HttpStatusCode.OK && (this.ErrorInfo == null || this.ErrorInfo.Errors == null || !this.ErrorInfo.Errors.Any());
    }
}
