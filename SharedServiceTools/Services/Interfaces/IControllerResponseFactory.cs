using System;
using Microsoft.AspNetCore.Mvc;

namespace SharedServiceTools
{
    public interface IControllerResponseFactory
    {
        IActionResult CreateSuccessResultResponse<TData>(BaseServiceResultData<TData> result);

        IActionResult CreateUnhandledErrorResponse(Exception exception);

        IActionResult CreateValidationErrorResponse(string errorInfo);
    }
}
