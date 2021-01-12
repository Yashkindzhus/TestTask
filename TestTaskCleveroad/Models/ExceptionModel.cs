using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskCleveroad.Models
{
    public class ExceptionModel: Exception
    {
        public int Status { get; set; } = 404;
        public object Value { get; set; }
    }

    public class ExceptionModelFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ExceptionModel exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = exception.Status,
                };
                context.ExceptionHandled = true;
            }
        }
    }

    public class ExceptionMessage:RootObject
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
