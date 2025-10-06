using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVClab.Models;

namespace MVClab.Filters
{
    public class CheckLocationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("department", out var value) && value is Department dept)
            {
                if (dept.Location != "EG" && dept.Location != "USA")
                {
                    context.Result = new BadRequestObjectResult("Location must be EG or USA only.");
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
