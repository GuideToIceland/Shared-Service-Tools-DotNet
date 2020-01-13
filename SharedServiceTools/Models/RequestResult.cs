using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class RequestResult<TData, TErrorInfo>
    {
        public RequestResult()
        {
        }

        public RequestResult(HttpStatusCode statusCode, TData data)
        {
            this.StatusCode = statusCode;
            this.Data = data;
        }

        public RequestResult(HttpStatusCode statusCode, TData data, string marketplaceId)
        {
            this.StatusCode = statusCode;
            this.Data = data;
            this.MarketplaceId = marketplaceId;
        }

        public RequestResult(HttpStatusCode statusCode, TErrorInfo errorInfo)
        {
            this.StatusCode = statusCode;
            this.ErrorInfo = errorInfo;
        }

        public HttpStatusCode StatusCode { get; set; }

        public TData Data { get; set; }

        public TErrorInfo ErrorInfo { get; set; }

        public string MarketplaceId { get; set; }

        public virtual bool IsValid { get; }
    }
}
