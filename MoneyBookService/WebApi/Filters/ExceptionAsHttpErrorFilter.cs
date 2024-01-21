using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoneyBookService.WebApi.Filters
{
    // based on example in https://docs.asp.net/en/latest/mvc/controllers/filters.html#exception-filters
    // ExceptionFilterAttribute prevents to execute ActionFilterAttribute, so AddHeaderAttribute doesn't execute
    // Becuase of that, Instead of ExceptionAsHttpErrorFilter we should use ValidateExceptionAttribute
    // But we include ExceptionAsHttpErrorFilter to filters list as "last frontier" in a case of fail all filters
    public class ExceptionAsHttpErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ValidateExceptionAttribute.OnExceptionInternal(context, context.Exception, out var contextExceptionHandled, out var exceptionResult);
            if (contextExceptionHandled)
            {
                context.ExceptionHandled = true;
                context.Result = exceptionResult;
            }
            else
            {
                base.OnException(context);
            }
        }
    }

    public class ValidateExceptionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted( ActionExecutedContext context )
        {
            if ( context.Exception is not null )
            {
                OnExceptionInternal( context, context.Exception, out var contextExceptionHandled, out var exceptionResult);
                if ( contextExceptionHandled )
                {
                    context.Exception = null;
                    context.Result = exceptionResult;
                }
            }
            base.OnActionExecuted( context );
        }

        internal static void OnExceptionInternal( FilterContext context, Exception currentException, out bool contextExceptionHandled, out IActionResult exceptionResult )
        {
            contextExceptionHandled = false;
            exceptionResult = null;

            if ( currentException is AggregateException { InnerExceptions: not null } exception && exception.InnerExceptions.Any() )
            {
                // first exception only
                OnExceptionInternal( context, exception.InnerExceptions.First(), out contextExceptionHandled, out exceptionResult );
            }
            else
            {
                var e = currentException;
                var result = new JsonResult(new
                {
                    code = "InternalError",
                    error = e.Message,
                    stackTrace = e.StackTrace.ToString(),
                    exceptionType = e.GetType().ToString()
                });
                result.StatusCode = 500;
                exceptionResult = result;
                contextExceptionHandled = true;
            }

        }
    }
}
