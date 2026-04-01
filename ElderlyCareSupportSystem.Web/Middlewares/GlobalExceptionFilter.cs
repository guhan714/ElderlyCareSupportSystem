using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ElderlyCareSupportSystem.Web.Middlewares;

public sealed class GlobalExceptionFilter : IExceptionFilter
{
    
    public void OnException(ExceptionContext context)
    {
        var result = new ViewResult
        {
            ViewName = "Error",
            ViewData =
            {
                ["ErrorMessage"] = context.Exception.Message
            }
        };

        context.Result = result;
        context.ExceptionHandled = true;
    }
}