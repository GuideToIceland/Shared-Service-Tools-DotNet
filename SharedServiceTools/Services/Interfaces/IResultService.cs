using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public interface IResultService
    {
        Task<TApplicationResult> CreateApplicationResult<TApplicationResult, TApplicationResultData, TDatabaseResult>(
            TDatabaseResult result,
            HttpStatusCode statusCode = HttpStatusCode.OK,
            string errorMessage = "OK")
            where TApplicationResult : BaseServiceResultData<TApplicationResultData>, new();
    }
}
