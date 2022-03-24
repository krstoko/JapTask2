using backend.Data;
using backend.Services.CategoryService;
using backend.Services.RecipeService;
using backend.Services.IngredientService;
using Microsoft.Extensions.DependencyInjection;
using Normative_Calculator.Core.Interfaces;
using Normative_Calculator.Service.Services;

namespace backend.Extensions
{
    public static class ServiceRegistration
    {
        public static void SetupServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientsService, IngredientService>();
            services.AddScoped<IStoredProcedureService, StoreProcedureService>();
        }
    }
}
