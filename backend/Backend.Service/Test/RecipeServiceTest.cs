using AutoMapper;
using backend.Core.Common;
using backend.Data;
using backend.Dtos.Category;
using backend.Dtos.Ingredient;
using backend.Dtos.Recipe;
using backend.Dtos.RecipeIngredients;
using backend.Dtos.Requests;
using backend.Infrastructure.DataContext;
using backend.Models;
using backend.Services.IngredientService;
using backend.Services.RecipeService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using Normative_Calculator.Database.SeedData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Service.Test
{


    [TestFixture]
    public class RecipeServiceTest
    {
        private RecipeService _recipeService;
        private DbContextOptions<DataContext> _options;
        private DataContext _context;

        [OneTimeSetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                   .UseInMemoryDatabase(databaseName: "JapTask2").Options;

            _context = new DataContext(_options);
            _context.Database.EnsureDeleted();
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AddRecipeDto, Recipe>();
                x.CreateMap<Recipe, GetRecipeDto>();
                x.CreateMap<RecipesIngredients, GetRecipeIngredientsDto>();
                x.CreateMap<Ingredient, GetIngredientDto>();
                x.CreateMap<Category, GetCategoryDto>();
            });
            _recipeService = new RecipeService(mapperConfiguration.CreateMapper(), _context);
            SetUpDatabase();
        }

        [Test]
        public void AddRecipe_WithNoIngredients_ThrowException()
        {

            var recipe = new AddRecipeDto
            {
                Name = "Test",
                Category_Id = 5,
                Description = "Test",
                Img_Url = "Test",
                Recipe_Ingredients = new List<AddRecipeIngredientsDto>()
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await _recipeService.AddRecipe(recipe));
        }

        [Test]
        public async Task AddRecipe_WithOneIngredient()
        {
            var addingRecipe = new AddRecipeDto
            {
                Name = "Test",
                Category_Id = 2,
                Description = "Test",
                Img_Url = "Test",
                Recipe_Ingredients = new List<AddRecipeIngredientsDto>()
                {
                   new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   }
                }
            };

            await _recipeService.AddRecipe(addingRecipe);

            var recipeInDb = _context.Recipes.FirstOrDefault(r => r.Name == addingRecipe.Name);

            Assert.AreEqual(addingRecipe.Name, recipeInDb.Name);
            Assert.AreEqual(addingRecipe.Description, recipeInDb.Description);
            Assert.AreEqual(addingRecipe.Img_Url, recipeInDb.Img_Url);
            Assert.True(addingRecipe.Recipe_Ingredients.Any());
        }

        [Test]
        public void CreateRecipe_AddingTwoSameIngredients_ThrowException()
        {
            var newRecipe = new AddRecipeDto
            {
                Name = "Test",
                Description = "Test",
                Category_Id = 2,
                Recipe_Ingredients = new List<AddRecipeIngredientsDto>
                {
                    new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   },
                     new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await _recipeService.AddRecipe(newRecipe));
        }

        [Test]
        public void CreateRecipe_AddingThreeSameIngredients_ThrowException()
        {
            var newRecipe = new AddRecipeDto
            {
                Name = "Test",
                Description = "Test",
                Category_Id = 2,
                Recipe_Ingredients = new List<AddRecipeIngredientsDto>
                {
                    new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   },
                     new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   },
                     new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await _recipeService.AddRecipe(newRecipe));
        }

        [Test]
        public void CreateRecipe_AddingMultipleSameIngredients_ThrowException()
        {
            var newRecipe = new AddRecipeDto
            {
                Name = "Test",
                Description = "Test",
                Category_Id = 2,
                Recipe_Ingredients = new List<AddRecipeIngredientsDto>
                {
                    new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   },
                     new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 1,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   },
                     new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 2,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   },
                     new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 2,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   },
                     new AddRecipeIngredientsDto
                   {
                       Ingredient_Id = 3,
                       Recipe_Measure_Quantity = 1,
                       Recipe_Measure_Unit = MeasureUnit.Kilogram,
                   }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await _recipeService.AddRecipe(newRecipe));
        }

        [TestCase(2)]
        [TestCase(1)]
        public async Task GetRecipes_LoadMore(int p_size)
        {

            var loadMoreRequest = new RecipeSearch { CategoryId = 2, PageSize = p_size, Skip = 0 };

            var result = await _recipeService.Get(loadMoreRequest);
            Assert.That(result.Data.Count, Is.EqualTo(p_size));
        }

        public void SetUpDatabase()
        {
            _context.Categories.AddRange(CategoryData.GetCategories());
            _context.Ingredients.AddRange(IngredientData.GetIngredients());
            _context.Recipes.AddRange(RecipeData.GetRecipes());
            _context.RecipeIngredients.AddRange(RecipeIngredientsData.GetRecipesIngredients());
            _context.SaveChanges();
        }

    }
}
