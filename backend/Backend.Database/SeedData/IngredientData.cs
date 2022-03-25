using backend.Core.Common;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normative_Calculator.Database.SeedData
{
    public class IngredientData
    {
        public static List<Ingredient> GetIngredients()
        {
            var ingredients = new List<Ingredient>();

            for (int i = 1; i < 50; i++)
            {
                Random random = new Random();
                var purchasePrice = Math.Round(random.NextDouble() * (5 - 0.5) + 0.5, 2);
                ingredients.Add(new Ingredient { Id = i, Name = "Ingredient " + i, Measure_Unit = MeasureUnit.Kilogram, Purchase_Price = purchasePrice, Purchase_Measure_Quantity = 1, Lowest_Measure_Unit_Price = purchasePrice / 1000 });
            }
            return ingredients;
        }
    }
}
