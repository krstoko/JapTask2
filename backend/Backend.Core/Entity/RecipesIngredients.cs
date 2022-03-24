using backend.Core.Common;

namespace backend.Models
{
    public class RecipesIngredients
    {
        public Recipe Recipe { get; set; }
        public int Recipe_Id { get; set; }

        public Ingredient Ingredient { get; set; }
        public int Ingredient_Id { get; set; }

        public int Recipe_Measure_Quantity { get; set; }
        public MeasureUnit Recipe_Measure_Unit { get; set; }
    }
}
