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
            var code = HttpStatusCode.InternalServerError;
            IActionResult result = new EmptyResult();

            if (context.Exception is UnauthorizedException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is ValidationException)
            {
                code = HttpStatusCode.BadRequest;
                result = new JsonResult(((ValidationException)context.Exception).Failures);
            }
            else if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                result = new JsonResult(new { errors = new[] { context.Exception.Message }});
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Forbidden;
            }
            else
            {
                // todo
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = result;
        }
    }
}
