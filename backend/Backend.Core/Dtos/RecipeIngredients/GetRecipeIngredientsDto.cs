using backend.Core.Common;
using backend.Dtos.Ingredient;
using backend.Models;

namespace backend.Dtos.RecipeIngredients
{
    public class GetRecipeIngredientsDto
    {
        public int Recipe_Id { get; set; }
        public int Ingredient_Id { get; set; }
        public GetIngredientDto Ingredient { get; set; }
        public int Recipe_Measure_Quantity { get; set; }
        public MeasureUnit Recipe_Measure_Unit { get; set; }
        public double Real_Ingredient_Price { get; set; }
    }
}
