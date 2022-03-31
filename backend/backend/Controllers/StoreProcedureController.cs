using backend.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Normative_Calculator.Core.Dtos.Requests;
using Normative_Calculator.Core.Interfaces;
using System.Threading.Tasks;

namespace Normative_Calculator.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StoreProcedureController : ControllerBase
    {
        private readonly IStoredProcedureService _storedProcedureService;
        public StoreProcedureController(IStoredProcedureService storedProcedureService)
        {
            _storedProcedureService = storedProcedureService;
        }

        [HttpGet("RecipesWithMoreThen10Ingredients")]
        public async Task<IActionResult> GetRecipesWith10orMoreIngredients()
        {
            return Ok(await _storedProcedureService.GetRecipesWith10orMoreIngredients());
        }

        [HttpGet("RecipesByCategoryName")]
        public async Task<IActionResult> GetRecipesByCategoryName()
        {
            return Ok(await _storedProcedureService.GetRecipesByCategoryName());
        }

        [HttpGet("MostUsedIngredients")]
        public async Task<IActionResult> GetTop10UsedIngredients([FromQuery] TopTenIngredients parameters)
        {
            return Ok(await _storedProcedureService.GetTop10UsedIngredients(parameters));
        }
    }

}
