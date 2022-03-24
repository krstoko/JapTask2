using backend.Core.Common;
using backend.Infrastructure.DataContext;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Normative_Calculator.Common.Requests;
using Normative_Calculator.Common.Response;
using Normative_Calculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Service.Services
{
    public class StoreProcedureService : IStoredProcedureService
    {

        private readonly DbConnection _dbConnection;
        public StoreProcedureService(DataContext dataContext)
        {
            _dbConnection = dataContext.Database.GetDbConnection();
        }
        public async Task<IEnumerable<MoreThen10Ingredients>> GetRecipesWith10orMoreIngredients()
        {
            return await _dbConnection.QueryAsync<MoreThen10Ingredients>("select * from get_recipes_at_least_10_ingredients()");
        }

        public async Task<IEnumerable<RecipeByCategoryName>> GetRecipesByCategoryName()
        {
            return await _dbConnection.QueryAsync<RecipeByCategoryName>("select * from get_recipes_by_category_name()");
        }

        public async Task<IEnumerable<Top10UsedIngredients>> GetTop10UsedIngredients(MeasureUnit m_unit, int min_quantity, int max_quantity)
        {
            return await _dbConnection.QueryAsync<Top10UsedIngredients>("select * from top_10_used_ingredients(" + ((int)m_unit) + ", " + min_quantity + "," + max_quantity + ")");
        }
    }
}
