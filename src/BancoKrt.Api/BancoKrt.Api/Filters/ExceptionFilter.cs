using BancoKrt.Domain.Response.Error;
using BancoKrt.Exception.ExceptionBase;
using BancoKrt.Exception.MessageResource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BancoKrt.Api.Filters;

/// <summary>
/// Filter regarding exceptions
/// </summary>
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BancoKrtException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        var bancoKrtException = context.Exception as BancoKrtException;
        var errorResponse = new ErrorResponse(bancoKrtException!.GetErrors());

        context.HttpContext.Response.StatusCode = bancoKrtException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private static void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ErrorResponse(ErrorMessageResource.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}