using Lumiere.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Lumiere.Backend.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                                Exception exception,
                                                CancellationToken cancellationToken)
    {
        switch (exception)
        {
            case NotFoundException notFoundEx:
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                {
                    Type = exception.GetType().Name,
                    Title = "An error occured",
                    Status = StatusCodes.Status404NotFound,
                    Detail = notFoundEx.Message
                }, cancellationToken);
                return true;
            default:
                break;
        }

        return false;
    }
}
