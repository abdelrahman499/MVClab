using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVClab.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CheckUserFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _requiredValue;
        private readonly string _headerName;

        
        public CheckUserFilterAttribute(string requiredValue = "Student", string headerName = "X-User-Role")
        {
            _requiredValue = requiredValue;
            _headerName = headerName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headers = context.HttpContext.Request.Headers;

           
            if (!headers.TryGetValue(_headerName, out var values) &&
                !headers.TryGetValue("User", out values))
            {
                context.Result = new UnauthorizedResult(); 
                return;
            }

            var headerValue = values.FirstOrDefault() ?? string.Empty;

            if (!string.Equals(headerValue, _requiredValue, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new ForbidResult(); 
                return;
            }

            
        }
    }
}
