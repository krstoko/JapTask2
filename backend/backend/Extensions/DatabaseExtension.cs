using backend.Data;
using backend.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Extensions
{
    public static class DatabaseExtension
    {
        public static void SetupDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
            });
        }
    }
}
