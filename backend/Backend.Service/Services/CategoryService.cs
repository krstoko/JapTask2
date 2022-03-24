
using AutoMapper;
using backend.Core.Common;
using backend.Data;
using backend.Dtos.Category;
using backend.Dtos.Requests;
using backend.Infrastructure.DataContext;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public CategoryService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

            var dbCategories = await _dataContext.Categories
                .Select(c => _mapper.Map<GetCategoryDto>(c))
                .ToListAsync();

            serviceResponse.Data = dbCategories;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> GetPage(BaseSearch search)
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

            var dbCategories = _dataContext.Categories
                .OrderByDescending(c => c.Created_Date)
                .Select(c => _mapper.Map<GetCategoryDto>(c))
                .AsQueryable();

            if (dbCategories.Count() <= search.Skip + search.PageSize)
            {
                serviceResponse.LoadMore = false;
                serviceResponse.Message = "Cant load more";
            }

            serviceResponse.Data = await dbCategories
                .Skip((int)search.Skip)
                .Take((int)search.PageSize)
                .ToListAsync();

            return serviceResponse;
        }
    }
}
