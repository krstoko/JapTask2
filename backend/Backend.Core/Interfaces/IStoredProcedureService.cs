using backend.Core.Common;
using Normative_Calculator.Common.Requests;
using Normative_Calculator.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Core.Interfaces
{
    public interface IStoredProcedureService
    {
        public Task<IEnumerable<MoreThen10Ingredients>> GetRecipesWith10orMoreIngredients();
        public Task<IEnumerable<RecipeByCategoryName>> GetRecipesByCategoryName();
        public Task<IEnumerable<Top10UsedIngredients>> GetTop10UsedIngredients(MeasureUnit measure_unit, int min_quantity, int max_quantity);
    }
}
