using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace MVClab.Filters
{
    public class HandleExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var viewData = new ViewDataDictionary(
                new EmptyModelMetadataProvider(),
                context.ModelState)
            {
                { "ErrorMessage", exception.Message },
                { "StackTrace", exception.StackTrace }
            };

            var viewResult = new ViewResult
            {
                ViewName = "Error",
                ViewData = viewData
            };

            context.Result = viewResult;
            context.ExceptionHandled = true;
        }
    }
}
