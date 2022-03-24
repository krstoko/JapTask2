using backend.Core.Common;

namespace backend.Dtos.RecipeIngredients
{
    public class AddRecipeIngredientsDto
    {
        public int Ingredient_Id { get; set; }
        public int Recipe_Measure_Quantity { get; set; }
        public MeasureUnit Recipe_Measure_Unit { get; set; }
    }
}
