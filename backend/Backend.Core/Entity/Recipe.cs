using backend.Entity;
using System.Collections.Generic;

namespace backend.Models
{
    public class Recipe : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img_Url { get; set; }

        public int Category_Id { get; set; }
        public Category Category { get; set; }

        public List<RecipesIngredients> Recipes_Ingredients { get; set; }
    }
}
