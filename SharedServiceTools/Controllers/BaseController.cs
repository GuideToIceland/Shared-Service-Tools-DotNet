using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SharedServiceTools.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(
            ILogger<BaseController> logger,
            IControllerResponseFactory responseFactoryService,
            IValidatorService validatorService)
        {
            this.Logger = logger;
            this.ControllerResponseFactory = responseFactoryService;
            this.ValidatorService = validatorService;
        }

        protected ILogger<BaseController> Logger { get; }

        protected IControllerResponseFactory ControllerResponseFactory { get; }

        protected IValidatorService ValidatorService { get; }

        protected async Task<IActionResult> ExecuteApplicationServiceMethod<TApplicationResult, TData>(
            string commandName,
            Func<Task<TApplicationResult>> commandExecute)
            where TApplicationResult : BaseServiceResultData<TData>
        {
            IActionResult response = null;
            try
            {
                this.Logger.LogInformation($"Start executing {commandName}");

                if (commandExecute == null)
                {
                    throw new ArgumentNullException(nameof(commandExecute));
                }

                TApplicationResult result = await commandExecute();

                response = this.ControllerResponseFactory.CreateSuccessResultResponse(result);
            }
            catch (Exception ex)
            {
                response = this.ControllerResponseFactory.CreateUnhandledErrorResponse(ex);
            }

            return response;
        }

        protected async Task<IActionResult> ExecuteApplicationServiceMethod<TApplicationParams, TApplicationResult, TData>(
            TApplicationParams paramsData,
            string commandName,
            Func<TApplicationParams, Task<TApplicationResult>> commandExecute)
            where TApplicationResult : BaseServiceResultData<TData>
        {
            IActionResult response = null;
            this.Logger.LogInformation($"Start executing {commandName}");

            try
            {
                var validationResult = this.ValidatorService.Validate(paramsData);

                if (validationResult.IsValid)
                {
                    if (commandExecute == null)
                    {
                        throw new ArgumentNullException(nameof(commandExecute));
                    }

                    TApplicationResult result = await commandExecute(paramsData);

                    response = this.ControllerResponseFactory.CreateSuccessResultResponse(result);
                }
                else
                {
                    response = this.ControllerResponseFactory.CreateValidationErrorResponse(validationResult.Error.Message);
                    this.Logger.LogWarning($"Executing of {commandName} is finished with handled error: {validationResult.Error.Message}");
                }
            }
            catch (Exception ex)
            {
                response = this.ControllerResponseFactory.CreateUnhandledErrorResponse(ex);
            }

            return response;
        }
    }
}
