using LambdaConnectorShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class ConnectorParsingService : IConnectorParsingService
    {
        public ConnectorParsingService(
            IMappingService mappingService)
        {
            this.MappingService = mappingService;
        }

        protected IMappingService MappingService { get; }

        public TResult CreateMappedConnectorResult<TResult, TConnectorResult, TConnectorResultData>(
            HttpStatusCode statusCode,
            string marketplaceId,
            string content)
            where TConnectorResult : RequestResultWithErrorInfo<BaseResponseData<TConnectorResultData>>, new()
        {
            if (this.ValidateResponse(content))
            {
                return this.MappingService.Map<TConnectorResult, TResult>(new TConnectorResult { Data = new BaseResponseData<TConnectorResultData>(this.ParseResult<TConnectorResultData>(content), marketplaceId), StatusCode = statusCode });
            }

            return this.MappingService.Map<TConnectorResult, TResult>(new TConnectorResult { ErrorInfo = this.ParseErrorResponse(content), StatusCode = statusCode });
        }

        public TConnectorResult CreateConnectorResult<TConnectorResult, TConnectorResultData>(
            HttpStatusCode statusCode,
            string marketplaceId,
            string content)
         where TConnectorResult : RequestResultWithErrorInfo<BaseResponseData<TConnectorResultData>>, new()
        {
            if (this.ValidateResponse(content))
            {
                return new TConnectorResult { Data = new BaseResponseData<TConnectorResultData>(this.ParseResult<TConnectorResultData>(content), marketplaceId), StatusCode = statusCode };
            }

            return new TConnectorResult { ErrorInfo = this.ParseErrorResponse(content), StatusCode = statusCode };
        }

        private bool ValidateResponse(string content)
        {
            dynamic res = JsonConvert.DeserializeObject(content);
            return res != null && res.Errors == null;
        }

        private T ParseResult<T>(string content)
        {
            dynamic res = JsonConvert.DeserializeObject(content);
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(res.Data));
        }

        private ErrorInfo ParseErrorResponse(string content)
        {
            return JsonConvert.DeserializeObject<ErrorInfo>(content);
        }
    }
}
