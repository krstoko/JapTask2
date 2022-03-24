using Microsoft.Extensions.DependencyInjection;

namespace backend.Extensions
{
    public static class SwaggerExtension
    {
        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "JapTask", Version = "v1" });
            });
        }
    }
}
