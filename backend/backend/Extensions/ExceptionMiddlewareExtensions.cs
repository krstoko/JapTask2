using backend.CustomExceptionMiddlewere;
using Microsoft.AspNetCore.Builder;

namespace backend.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddlewere>();
        }
    }
}
