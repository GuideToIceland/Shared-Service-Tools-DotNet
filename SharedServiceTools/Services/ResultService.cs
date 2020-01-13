using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class ResultService : IResultService
    {
        public ResultService(
            IMappingService mappingService)
        {
            this.MappingService = mappingService;
        }

        protected IMappingService MappingService { get; }

        public async Task<TApplicationResult> CreateApplicationResult<TApplicationResult, TApplicationResultData, TDatabaseResult>(
            TDatabaseResult result,
            HttpStatusCode statusCode = HttpStatusCode.OK,
            string errorMessage = "OK")
            where TApplicationResult : BaseServiceResultData<TApplicationResultData>, new()
        {
            return new TApplicationResult() { Data = this.MappingService.Map<TDatabaseResult, TApplicationResultData>(result), StatusCode = statusCode, Error = errorMessage };
        }
    }
}
