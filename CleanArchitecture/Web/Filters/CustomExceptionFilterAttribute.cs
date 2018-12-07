using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(((ValidationException)context.Exception).Failures);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                context.Result = new JsonResult(new { errors = new[] { context.Exception.Message }});
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            
        }
    }
}
