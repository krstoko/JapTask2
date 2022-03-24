using backend.Dtos.Category;
using backend.Dtos.RecipeIngredients;
using backend.Models;
using System.Collections.Generic;

namespace backend.Dtos.Recipe
{
    public class GetRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img_Url { get; set; }
        public GetCategoryDto Category { get; set; }
        public double Price { get; set; }
        public List<GetRecipeIngredientsDto> Recipes_Ingredients { get; set; }
    }
}
