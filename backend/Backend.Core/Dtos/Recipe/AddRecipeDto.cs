using backend.Dtos.RecipeIngredients;
using System.Collections.Generic;

namespace backend.Dtos.Recipe
{
    public class AddRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img_Url { get; set; }
        public int Category_Id { get; set; }
        public List<AddRecipeIngredientsDto> Recipe_Ingredients { get; set; }
    }
}
