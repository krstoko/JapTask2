using AutoMapper;
using backend.Core.Common;
using backend.Data;
using backend.Dtos.Ingredient;
using backend.Dtos.Recipe;
using backend.Dtos.RecipeIngredients;
using backend.Dtos.Requests;
using backend.Infrastructure.DataContext;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using NormativeCalculator.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace backend.Services.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public RecipeService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto newRecipe)
        {
            var response = new ServiceResponse<GetRecipeDto>();
            var recipe = _mapper.Map<Recipe>(newRecipe);
            var recipeCategory = await _dataContext.Categories
                .FirstOrDefaultAsync(c => c.Id == newRecipe.Category_Id);

            if (recipeCategory == null)
            {
                throw new ArgumentException("Category not found");
            }
            if (newRecipe.Recipe_Ingredients.Count == 0)
            {
                throw new ArgumentException("Recipe need at least one ingredient");
            }
            if (newRecipe.Recipe_Ingredients.GroupBy(x => x.Ingredient_Id).Any(x => x.Count() > 1))
            {
                throw new ArgumentException("Can not add same ingredient");
            }

            _dataContext.Recipes.Add(recipe);
            await _dataContext.SaveChangesAsync();

            var recipeIngredients = new List<RecipesIngredients>();
            foreach (var recipeIngredient in newRecipe.Recipe_Ingredients)
            {
                recipeIngredients.Add(new RecipesIngredients()
                {
                    Ingredient_Id = recipeIngredient.Ingredient_Id,
                    Recipe_Id = recipe.Id,
                    Recipe_Measure_Unit = recipeIngredient.Recipe_Measure_Unit,
                    Recipe_Measure_Quantity = recipeIngredient.Recipe_Measure_Quantity
                });
            }

            _dataContext.RecipeIngredients.AddRange(recipeIngredients);
            await _dataContext.SaveChangesAsync();
            response.Data = _mapper.Map<GetRecipeDto>(recipe);
            return response;
        }

        public PagedList<GetRecipeDto> Get(RecipeSearch recipeSearch)
        {
            var response = new ServiceResponse<List<GetRecipeDto>>();

            var query = _dataContext.Recipes
                 .Include(r => r.Recipes_Ingredients)
                    .ThenInclude(r => r.Ingredient)
                 .AsQueryable();

            if (recipeSearch.CategoryId > 0)
            {
                query = query
                    .Where(r => r.Category_Id == recipeSearch.CategoryId);
            }

            if (!string.IsNullOrEmpty(recipeSearch.SearchValue))
            {
                query = query
                    .Where(r => r.Name.Contains(recipeSearch.SearchValue)
                    ||
                    r.Recipes_Ingredients.Any(ri => ri.Ingredient.Name.Contains(recipeSearch.SearchValue)));
            }

            var recipes = query
                .Select(r => _mapper.Map<GetRecipeDto>(r))
                .OrderBy(r => r.Price)
                .ToList();

            return PagedList<GetRecipeDto>.Create(recipes, (int)recipeSearch.PageSize, (int)recipeSearch.Skip);

        }

        public async Task<ServiceResponse<GetRecipeDto>> GetRecipe(int id)
        {
            var response = new ServiceResponse<GetRecipeDto>();
            var recipe = await _dataContext.Recipes
                .Include(r => r.Category)
                .Include(r => r.Recipes_Ingredients)
                .ThenInclude(r => r.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                response.Success = false;
                response.Message = "No recipe with that Id";
                return response;
            }

            response.Data = _mapper.Map<GetRecipeDto>(recipe);
            return response;
        }
    }
}
