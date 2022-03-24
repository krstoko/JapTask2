using backend.Dtos.Ingredient;
using backend.Models;
using backend.Services.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsService _ingredientService;
        public IngredientsController(IIngredientsService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ingredientService.Get());
        }
    }
}
