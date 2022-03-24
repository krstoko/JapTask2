using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Common.Requests
{
    public class MoreThen10Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Total_Cost { get; set; }
        public int Ingredients_Number { get; set; }
    }
}
