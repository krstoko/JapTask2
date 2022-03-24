using backend.Core.Common;

namespace backend.Dtos.Ingredient
{
    public class GetIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MeasureUnit Measure_Unit { get; set; }
        public int Purchase_Measure_Quantity { get; set; }
        public double Purchase_Price { get; set; }
        public double Lowest_Measure_Unit_Price { get; set; }
    }
}
