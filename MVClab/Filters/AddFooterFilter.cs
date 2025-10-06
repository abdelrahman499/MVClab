using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace MVClab.Filters
{
    public class AddFooterFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var executedContext = await next();

            if (executedContext.Result is Microsoft.AspNetCore.Mvc.ViewResult)
            {
                var response = context.HttpContext.Response;

                if (response.ContentType != null && response.ContentType.Contains("text/html"))
                {
                    await response.WriteAsync("<hr/>");
                    await response.WriteAsync($"<footer style='color:gray;font-size:14px;text-align:center;'>");
                    await response.WriteAsync($"Created at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    await response.WriteAsync("</footer>");
                }
            }
        }
    }
}
