using backend.Core.Common;
using backend.Models;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Database.SeedData
{
    public class RecipeIngredientsData
    {
        public static List<RecipesIngredients> GetRecipesIngredients()
        {
            var recipesIngredients = new List<RecipesIngredients>();
            for (int i = 1; i < 100; i++)
            {

                Random random = new Random();
                var randomRecipe = random.Next(1, 50);
                var randomIngredient = random.Next(1, 50);
                var randomQuantiy = random.Next(10, 100);
                recipesIngredients.Add(new RecipesIngredients { Ingredient_Id = randomIngredient, Recipe_Id = randomRecipe, Recipe_Measure_Unit = MeasureUnit.Decigram, Recipe_Measure_Quantity = randomQuantiy });
            }
            for (int i = 1; i < 100; i++)
            {
                Random random = new Random();
                var randomRecipe = random.Next(1, 50);
                var randomIngredient = random.Next(1, 50);
                var randomQuantiy = random.Next(100, 800);

                recipesIngredients.Add(new RecipesIngredients { Ingredient_Id = randomIngredient, Recipe_Id = randomRecipe, Recipe_Measure_Unit = MeasureUnit.Gram, Recipe_Measure_Quantity = randomQuantiy });
            }
            for (int i = 1; i < 100; i++)
            {
                Random random = new Random();
                var randomRecipe = random.Next(1, 50);
                var randomIngredient = random.Next(1, 50);
                var randomQuantiy = random.Next(1, 5);
                recipesIngredients.Add(new RecipesIngredients { Ingredient_Id = randomIngredient, Recipe_Id = randomRecipe, Recipe_Measure_Unit = MeasureUnit.Kilogram, Recipe_Measure_Quantity = randomQuantiy });
            }

            recipesIngredients = recipesIngredients.DistinctBy(x => new { x.Recipe_Id, x.Ingredient_Id }).ToList();
            return recipesIngredients;
        }
    }
}
