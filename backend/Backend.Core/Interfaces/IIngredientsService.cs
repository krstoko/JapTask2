using backend.Core.Common;
using backend.Dtos.Ingredient;
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services.IngredientService
{
    public interface IIngredientsService
    {
        Task<ServiceResponse<List<GetIngredientDto>>> Get();
    }
}
