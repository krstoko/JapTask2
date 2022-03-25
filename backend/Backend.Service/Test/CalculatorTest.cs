using backend.Core.Common;
using backend.Dtos.Recipe;
using backend.Dtos.RecipeIngredients;
using backend.Models;
using Backend.Mapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Service.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        //ingredient cost
        [Test]
        public void CalculateIngredientCost()
        {
            var ingredient = new Ingredient
            {
                Id = 1,
                Name = "PrviTest",
                Lowest_Measure_Unit_Price = 0.0015,
                Measure_Unit = MeasureUnit.Kilogram,
                Purchase_Measure_Quantity = 1,
                Purchase_Price = 1.5
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
                Recipe_Measure_Unit = MeasureUnit.Kilogram,
                Recipe_Measure_Quantity = 2
            };
            var realPrice = CalculatePrice.calculatingPrice(recipeIngredients);
            Assert.AreEqual(3, realPrice);
        }

        [Test]
        public void CalculateIngredientCostCaseTwo()
        {
            var ingredient = new Ingredient
            {
                Id = 1,
                Name = "Test",
                Lowest_Measure_Unit_Price = 0.0035,
                Measure_Unit = MeasureUnit.Kilogram,
                Purchase_Measure_Quantity = 1,
                Purchase_Price = 3.5
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
                Recipe_Measure_Unit = MeasureUnit.Kilogram,
                Recipe_Measure_Quantity = 1
            };
            var realPrice = CalculatePrice.calculatingPrice(recipeIngredients);
            Assert.AreEqual(3.5, realPrice);
        }

        [Test]
        public void CalculateIngredientCostCaseThree()
        {
            var ingredient = new Ingredient
            {
                Id = 1,
                Name = "Test",
                Lowest_Measure_Unit_Price = 0.0025,
                Measure_Unit = MeasureUnit.Kilogram,
                Purchase_Measure_Quantity = 1,
                Purchase_Price = 2.5
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
                Recipe_Measure_Unit = MeasureUnit.Kilogram,
                Recipe_Measure_Quantity = 3
            };
            var realPrice = CalculatePrice.calculatingPrice(recipeIngredients);
            Assert.AreEqual(7.5, realPrice);
        }




        //recipe cost
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
                            Real_Ingredient_Price = ingredientPrice1
                        },
                     new GetRecipeIngredientsDto
                        {
                            Real_Ingredient_Price = ingredientPrice2
                        }
                }
            };

            var recipePrice = recipe.Recipes_Ingredients.Sum(x => x.Real_Ingredient_Price);
            return recipePrice;
        }
    }



}
