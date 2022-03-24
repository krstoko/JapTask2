using backend.Core.Common;
using backend.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace backend.CustomExceptionMiddlewere
{
    public class ExceptionMiddlewere
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddlewere(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ServiceResponse<Exception>
            {
                Success = false,
                Message = exception.Message,
            }.ToString());
        }
    }

}
