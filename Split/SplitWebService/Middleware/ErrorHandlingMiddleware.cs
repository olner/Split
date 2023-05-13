using Split.Engine.Exceptions;
using SplitWebService.Models;
using System.Text.Json;

namespace SplitWebService.Middleware;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            if (e is ServiceException ss)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new ErrorResponse { Message = ss.Message });
                return;
            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new ErrorResponse { Message = $"Service exception call administators" });
        }
    }
}
