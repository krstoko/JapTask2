using Microsoft.EntityFrameworkCore.Migrations;

namespace Normative_Calculator.Database.Migrations
{
    public partial class AddingStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            create function calculating_price(ri recipe_ingredients, i ingredients)
            returns decimal as $$
            declare total_price double precision;
            begin
                total_price = CASE
                    WHEN ri.recipe_measure_unit = 3 or ri.recipe_measure_unit = 0
		                THEN i.lowest_measure_unit_price * ri.recipe_measure_quantity * 1000
	                WHEN ri.recipe_measure_unit = 1 or ri.recipe_measure_unit = 5
		                THEN i.lowest_measure_unit_price * ri.recipe_measure_quantity
                    ELSE i.lowest_measure_unit_price * ri.recipe_measure_quantity * 10
                end;
            return total_price;
            end;
            $$
            language plpgsql
            ");

            migrationBuilder.Sql(@"
            create function get_recipes_at_least_10_ingredients()
            returns table (
		        recipe_id integer,
		        recipe_name varchar,
	            ingredients_number bigint,
	            total_price numeric
	        ) as $$
            begin
            return query
                SELECT recipes.id,recipes.name,Count(ingredients.id) AS broj_Recepata, SUM(calculating_price(recipe_ingredients,ingredients)) AS TotalPrice
                FROM recipe_ingredients
                INNER JOIN recipes
                    ON recipes.id = recipe_ingredients.recipe_id
                INNER JOIN ingredients
                    ON ingredients.id = recipe_ingredients.ingredient_id
                GROUP BY recipes.id
                HAVING COUNT(ingredients.id) > 9
                ORDER BY SUM(calculating_price(recipe_ingredients,ingredients)) DESC;
            end;$$
            language plpgsql");

            migrationBuilder.Sql(@"
            create function get_recipes_by_category_name()
            returns table (
		        category_name varchar,
		        recipe_name varchar ,
	            total_price numeric
	        ) as $$
            begin
            return query
                SELECT categories.name,recipes.name,SUM(calculating_price(recipe_ingredients,ingredients)) as TotalPrice
                FROM recipe_ingredients
                INNER JOIN recipes
                    ON recipes.id = recipe_ingredients.recipe_Id
                INNER JOIN ingredients
                    ON ingredients.id = recipe_ingredients.ingredient_id
                INNER JOIN categories
                    ON categories.id = recipes.category_id
                GROUP BY categories.name,recipes.name
                ORDER BY SUM(calculating_price(recipe_ingredients,ingredients)) DESC;
            end;$$
            language plpgsql");


            migrationBuilder.Sql(@"
            create function top_10_used_ingredients(m_unit bigint,min_quantity bigint,max_quantity bigint)
            returns TABLE(name character varying, used_count bigint) as $$
            begin
            return query
                SELECT ingredients.name, COUNT(recipe_ingredients.ingredient_id) As ukupno
                FROM ingredients
                INNER JOIN recipe_ingredients
                    ON ingredients.id=recipe_ingredients.ingredient_id
                WHERE ingredients.measure_unit=m_unit AND recipe_ingredients.recipe_measure_quantity
                BETWEEN min_quantity AND max_quantity
                GROUP BY ingredients.name
                ORDER BY COUNT(recipe_ingredients.ingredient_id) DESC
                LIMIT 10;
            end;$$
            language plpgsql");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION calculatingPrice()");
            migrationBuilder.Sql("DROP FUNCTION get_recipes_at_least_10_ingredients()");
            migrationBuilder.Sql("DROP FUNCTION get_recipes_by_category_name()");
            migrationBuilder.Sql("DROP FUNCTION top_10_used_ingredients()");
        }
    }
}
