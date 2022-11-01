using CrossCutting.Extensions;
using System.Net;

namespace WebApi.Extensions
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
            catch (HttpException httpEx)
            {
                HandleHttpExceptionAsync(httpContext, httpEx);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }

        private static void HandleHttpExceptionAsync(HttpContext context, HttpException httpEx)
        {
            context.Response.StatusCode = (int)httpEx.StatusCode;
            context.Response.WriteAsync(httpEx.Message);
        }
        private static void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.WriteAsync("Oops... Something went wrong! Sorry!");
        }
    }
}
