using LambdaConnectorShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public interface IConnectorParsingService
    {
        TResult CreateMappedConnectorResult<TResult, TConnectorResult, TConnectorResultData>(
            HttpStatusCode statusCode,
            string marketplaceId,
            string content)
            where TConnectorResult : RequestResultWithErrorInfo<BaseResponseData<TConnectorResultData>>, new();

        public TConnectorResult CreateConnectorResult<TConnectorResult, TConnectorResultData>(
              HttpStatusCode statusCode,
              string marketplaceId,
              string content)
           where TConnectorResult : RequestResultWithErrorInfo<BaseResponseData<TConnectorResultData>>, new();
    }
}
