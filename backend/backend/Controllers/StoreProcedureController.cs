using backend.Core.Common;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("procedure/1")]
        public async Task<IActionResult> GetRecipesWith10orMoreIngredients()
        {
            return Ok(await _storedProcedureService.GetRecipesWith10orMoreIngredients());
        }

        [HttpGet("procedure/2")]
        public async Task<IActionResult> GetRecipesByCategoryName()
        {
            return Ok(await _storedProcedureService.GetRecipesByCategoryName());
        }

        [HttpGet("procedure/3")]
        public async Task<IActionResult> GetTop10UsedIngredients(MeasureUnit measure_unit, int min_quantity, int max_quantity)
        {
            return Ok(await _storedProcedureService.GetTop10UsedIngredients(measure_unit, min_quantity, max_quantity));
        }
    }

}
