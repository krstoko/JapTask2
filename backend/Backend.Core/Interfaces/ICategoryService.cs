using backend.Core.Common;
using backend.Dtos.Category;
using backend.Dtos.Requests;
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetPage(BaseSearch search);
        Task<ServiceResponse<List<GetCategoryDto>>> Get();
    }
}
