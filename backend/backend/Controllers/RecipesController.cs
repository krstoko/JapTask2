using backend.Dtos.Recipe;
using backend.Dtos.Requests;
using backend.Models;
using backend.Services.RecipeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipeService _recipeService;
        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByCategory([FromQuery] RecipeSearch recipeSearch)
        {
            var result = await _recipeService
                .GetByCategory(recipeSearch);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetBySearch([FromQuery] RecipeSearch recipeSearch)
        {
            var result = await _recipeService
                .GetBySearch(recipeSearch);

            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _recipeService.GetRecipe(id);

            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(AddRecipeDto newRecipe)
        {
            return Ok(await _recipeService.AddRecipe(newRecipe));
        }
    }
}
