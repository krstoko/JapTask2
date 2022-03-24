using Microsoft.AspNetCore.Builder;

namespace backend.Extensions
{
    public static class CorsExtension
    {

        public static void SetupCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        }
    }
}
