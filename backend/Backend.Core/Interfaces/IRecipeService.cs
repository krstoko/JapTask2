using backend.Core.Common;
using backend.Dtos.Recipe;
using backend.Dtos.Requests;
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services.RecipeService
{
    public interface IRecipeService
    {
        Task<ServiceResponse<List<GetRecipeDto>>> Get(RecipeSearch recipeSearch);
        Task<ServiceResponse<GetRecipeDto>> GetRecipe(int id);
        Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto newRecipe);
    }
}
