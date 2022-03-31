using backend.Core.Common;
using backend.Infrastructure.DataContext;
using backend.Models;

namespace NormativeCalculator.Test
{
    public class SeedInMemoryDataBase
    {

        public static void SeedingDataBase(DataContext context)
        {
            context.Categories.AddRange
               (
                new Category { Id = 1, Name = "Category1", Img_Url = "Test" },
                new Category { Id = 2, Name = "Category2", Img_Url = "Test2" }
               );

            context.Ingredients.AddRange
                (
                 new Ingredient { Id = 1, Name = "Ingredient1", Measure_Unit = MeasureUnit.Kilogram, Purchase_Price = 2, Purchase_Measure_Quantity = 1, Lowest_Measure_Unit_Price = 2 / 1000 },
                 new Ingredient { Id = 2, Name = "Ingredient2", Measure_Unit = MeasureUnit.Kilogram, Purchase_Price = 3, Purchase_Measure_Quantity = 1, Lowest_Measure_Unit_Price = 3 / 1000 }
                );
            context.Recipes.AddRange
                (
                 new Recipe { Id = 1, Name = "Recipe1", Category_Id = 1, Img_Url = "Test", Description = "Test" },
                 new Recipe { Id = 2, Name = "Recipe2", Category_Id = 2, Img_Url = "Test", Description = "Test" }
                );

            context.RecipeIngredients.AddRange
                (
                 new RecipesIngredients { Recipe_Id = 1, Ingredient_Id = 1, Recipe_Measure_Quantity = 150, Recipe_Measure_Unit = MeasureUnit.Gram },
                 new RecipesIngredients { Recipe_Id = 1, Ingredient_Id = 2, Recipe_Measure_Quantity = 100, Recipe_Measure_Unit = MeasureUnit.Gram }
                );
            context.SaveChanges();
        }
    }
}
