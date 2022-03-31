using backend.Core.Common;
using backend.Dtos.Recipe;
using backend.Dtos.RecipeIngredients;
using backend.Models;
using Backend.Mapper;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Normative_Calculator.Service.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        [TestCase(0.0015, 1.5, 2, MeasureUnit.Kilogram, ExpectedResult = 3)]
        [TestCase(0.0035, 3.5, 1, MeasureUnit.Kilogram, ExpectedResult = 3.5)]
        [TestCase(0.0025, 2.5, 3, MeasureUnit.Kilogram, ExpectedResult = 7.5)]
        public double CalculateIngredientCost(double lowestUnitPrice, double purchasePrice, int recipeMeasureQuantity, MeasureUnit recipeMeasureUnit)
        {
            var ingredient = new Ingredient
            {
                Id = 1,
                Name = "PrviTest",
                Lowest_Measure_Unit_Price = lowestUnitPrice,
                Measure_Unit = MeasureUnit.Kilogram,
                Purchase_Measure_Quantity = 1,
                Purchase_Price = purchasePrice
            };
            var recipe = new Recipe()
            {
                Id = 1,
                Description = "Test",
                Name = "Test",
                Category_Id = 1
            };

            var recipeIngredients = new RecipesIngredients()
            {
                Recipe = recipe,
                Ingredient = ingredient,
                Recipe_Measure_Unit = recipeMeasureUnit,
                Recipe_Measure_Quantity = recipeMeasureQuantity
            };

            var realPrice = CalculatePrice.calculatingPrice(recipeIngredients);
            return realPrice;
        }

        [Test]
        [TestCase(1.5, 1.2, ExpectedResult = 2.7)]
        [TestCase(2, 1, ExpectedResult = 3)]
        [TestCase(0.5, 0.6, ExpectedResult = 1.1)]
        public double CalculateRecipePriceTesting(double ingredientPrice1, double ingredientPrice2)
        {
            var recipe = new GetRecipeDto()
            {
                Name = "Test",
                Description = "Test",
                Id = 1,
                Recipes_Ingredients = new List<GetRecipeIngredientsDto>()
                {
                     new GetRecipeIngredientsDto
                     {
                            RealIngredientPrice = ingredientPrice1
                     },
                     new GetRecipeIngredientsDto
                     {
                            RealIngredientPrice = ingredientPrice2
                     }
                }
            };

            var recipePrice = recipe.Recipes_Ingredients.Sum(x => x.RealIngredientPrice);
            return recipePrice;
        }
    }



}
