using backend.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Core.Dtos.Requests
{
    public class TopTenIngredients
    {
        public MeasureUnit M_Unit { get; set; }
        public int Min_Quantity { get; set; }
        public int Max_Quantity { get; set; }
    }
}


