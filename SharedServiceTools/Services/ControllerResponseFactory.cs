using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class ControllerResponseFactory : IControllerResponseFactory
    {
        public IActionResult CreateSuccessResultResponse<TData>(BaseServiceResultData<TData> result)
        {
            return new JsonResult(result.Data)
            {
                StatusCode = (int)result.StatusCode,
                ContentType = "application/json"
            };
        }

        public IActionResult CreateUnhandledErrorResponse(Exception exception)
        {
            return new ContentResult()
            {
                Content = exception.ToString(),
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ContentType = "text/plain"
            };
        }

        public IActionResult CreateValidationErrorResponse(string errorInfo)
        {
            return new JsonResult(errorInfo)
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                ContentType = "application/json"
            };
        }
    }
}
