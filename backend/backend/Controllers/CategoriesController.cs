
using backend.Dtos.Category;
using backend.Dtos.Requests;
using backend.Models;
using backend.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getPage")]
        public async Task<IActionResult> GetPage([FromQuery] BaseSearch search)
        {
            return Ok(await _categoryService.GetPage(search));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.Get());
        }

    }
}
