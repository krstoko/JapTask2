using backend.Core.Common;
using backend.Entity;
using System.Collections;
using System.Collections.Generic;

namespace backend.Models
{
    public class Ingredient : EntityBase
    {
        public string Name { get; set; }
        public MeasureUnit Measure_Unit { get; set; }
        public int Purchase_Measure_Quantity { get; set; }

        public double Purchase_Price { get; set; }

        public double Lowest_Measure_Unit_Price { get; set; }
        public List<RecipesIngredients> Recipes_Ingredients { get; set; }
    }
}
