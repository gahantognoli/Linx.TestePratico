using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpResponseException ex)
            {
                httpContext.Response.StatusCode = (int)ex.StatusCode;
            }
        }
    }
}
