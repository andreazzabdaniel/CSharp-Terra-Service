using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using terraservice.Communication;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TerraServiceException)
        {
            HandleProjectException(context);
        }
        else
        {
            HandleUnknownException(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var terraserviceException = context.Exception as TerraServiceException;
        var errorResponse = new ResponseErrorJson(terraserviceException!.GetMessages());

        context.HttpContext.Response.StatusCode = terraserviceException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }
    private void HandleUnknownException(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}