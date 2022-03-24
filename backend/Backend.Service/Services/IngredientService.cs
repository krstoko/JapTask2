using AutoMapper;
using backend.Core.Common;
using backend.Data;
using backend.Dtos.Ingredient;
using backend.Infrastructure.DataContext;
using backend.Models;
using backend.Services.IngredientService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.IngredientService
{
    public class IngredientService : IIngredientsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public IngredientService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<List<GetIngredientDto>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();
            var dbIngredients = await _dataContext.Ingredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToListAsync();
            serviceResponse.Data = dbIngredients;
            return serviceResponse;
        }
    }
}
