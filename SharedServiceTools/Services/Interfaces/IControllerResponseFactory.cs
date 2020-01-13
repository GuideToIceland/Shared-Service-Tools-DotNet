using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public interface IControllerResponseFactory
    {
        IActionResult CreateSuccessResultResponse<TData>(BaseServiceResultData<TData> result);

        IActionResult CreateUnhandledErrorResponse(Exception exception);

        IActionResult CreateValidationErrorResponse(string errorInfo);
    }
}
