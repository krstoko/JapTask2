using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Database.SeedData
{
    public class RecipeData
    {
        public static List<Recipe> GetRecipes()
        {
            var recipes = new List<Recipe>();
            for (int i = 1; i < 50; i++)
            {
                Random random = new Random();
                var randomCategory = random.Next(2, 18);
                recipes.Add(new Recipe { Id = i, Category_Id = randomCategory, Description = "Seeded description", Img_Url = "Seeded image", Name = "Recipe " + i });
            }
            return recipes;
        }
    }
}
