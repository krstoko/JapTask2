using backend.Models;

namespace Backend.Mapper
{
    public class CalculatePrice
    {

        public static double calculatingPrice(RecipesIngredients recipesIngridients)
        {

            int unitDifference = 0;
            if (recipesIngridients.Recipe_Measure_Unit.ToString() == "Kilogram" || recipesIngridients.Recipe_Measure_Unit.ToString() == "Liter")
            {
                unitDifference = 1000;
            }

            else if (recipesIngridients.Recipe_Measure_Unit.ToString() == "Gram" || recipesIngridients.Recipe_Measure_Unit.ToString() == "Mililiter")
            {
                unitDifference = 1;
            }
            else
            {
                unitDifference = 10;
            }
            return recipesIngridients.Ingredient.Lowest_Measure_Unit_Price * unitDifference * recipesIngridients.Recipe_Measure_Quantity;
        }
    }
}
