using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace WorldCup.WebAPI.Filters
{
    public class NotImplementexExFilter : IActionFilter, IOrderedFilter
    {
        public int Order => -10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is NotImplementedException notImplementedException)
            {
                context.Result = new ObjectResult(notImplementedException.Message)
                {
                    StatusCode = (int) HttpStatusCode.NotImplemented
                };

                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
