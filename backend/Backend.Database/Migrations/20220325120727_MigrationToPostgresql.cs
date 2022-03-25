using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Normative_Calculator.Database.Migrations
{
    public partial class MigrationToPostgresql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(127)", maxLength: 127, nullable: false),
                    img_url = table.Column<string>(type: "character varying(1020)", maxLength: 1020, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(127)", maxLength: 127, nullable: false),
                    measure_unit = table.Column<int>(type: "integer", nullable: false),
                    purchase_measure_quantity = table.Column<int>(type: "integer", nullable: false),
                    purchase_price = table.Column<double>(type: "double precision", maxLength: 30, nullable: false),
                    lowest_measure_unit_price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ingredients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: true),
                    password_has = table.Column<byte[]>(type: "bytea", nullable: true),
                    password_salt = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(127)", maxLength: 127, nullable: false),
                    description = table.Column<string>(type: "character varying(1020)", maxLength: 1020, nullable: false),
                    img_url = table.Column<string>(type: "character varying(1020)", maxLength: 1020, nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipes", x => x.id);
                    table.ForeignKey(
                        name: "fk_recipes_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe_ingredients",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_measure_quantity = table.Column<int>(type: "integer", nullable: false),
                    recipe_measure_unit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe_ingredients", x => new { x.ingredient_id, x.recipe_id });
                    table.ForeignKey(
                        name: "fk_recipe_ingredients_ingredients_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_recipe_ingredients_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_date", "img_url", "name" },
                values: new object[,]
                {
                    { 2, new DateTime(2010, 1, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://media.istockphoto.com/photos/heap-of-bread-picture-id995038782?k=20&m=995038782&s=612x612&w=0&h=40HBdtHiBgOESo870LBOgc6xUt1E3bqhOhqPCXZTNbc=", "Bread" },
                    { 18, new DateTime(2000, 3, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://img.taste.com.au/sv9d9AM6/w720-h480-cfill-q80/taste/2016/11/pork-and-bean-burrito-bowl-109208-1.jpeg", "Lunch" },
                    { 17, new DateTime(2014, 5, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://static.toiimg.com/thumb/83740315.cms?width=1200&height=900", "Sandwich" },
                    { 16, new DateTime(2015, 3, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://media.istockphoto.com/photos/seafood-platter-grilled-lobster-shrimps-scallops-langoustines-octopus-picture-id1305699663?k=20&m=1305699663&s=612x612&w=0&h=x1FHZSXT9H8ttwoD6oDtBKB19QQdDml9ZmY_sZqHuNc=", "Seafood" },
                    { 14, new DateTime(2005, 1, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://post.healthline.com/wp-content/uploads/2020/09/vegetarian-diet-plan-732x549-thumbnail.jpg", "Vegetarian" },
                    { 13, new DateTime(2003, 12, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://www.thespruceeats.com/thmb/TTsydZkvlx25nvMQPZq0wB5o87c=/1500x1500/smart/filters:no_upscale()/GettyImages-1042998066-518ca1d7f2804eb09039e9e42e91667c.jpg", "Thai" },
                    { 12, new DateTime(2002, 11, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://www.thoughtco.com/thmb/F5IEThuihsz_k-ptOUx1SP4KJoI=/2119x1192/smart/filters:no_upscale()/chopped-pork-meat-cooked-with-red-chili-paste--gochujang-sauce--over-rice-690784532-5c8bd3dc46e0fb000146acf1.jpg", "Rice" },
                    { 11, new DateTime(2001, 10, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://www.healthyeating.org/images/default-source/home-0.0/nutrition-topics-2.0/general-nutrition-wellness/2-2-2-3foodgroups_fruits_detailfeature.jpg?sfvrsn=64942d53_4", "Fruit" },
                    { 15, new DateTime(2016, 6, 2, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://food-images.files.bbci.co.uk/food/recipes/chickensoup_1918_16x9.jpg", "Soup" },
                    { 9, new DateTime(2012, 8, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://www.thespruceeats.com/thmb/MbHAC6HNO7rjkZXA_GwHvbQ46EA=/2000x1500/smart/filters:no_upscale()/basic-cherry-pie-recipe-995136-14-dfe79487adf64a848a49dd07983b6614.jpg", "Pie" },
                    { 8, new DateTime(2010, 7, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://saladswithanastasia.com/wp-content/uploads/2021/12/radish-green-salad-land1.jpg", "Salad" },
                    { 7, new DateTime(2021, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://static.onecms.io/wp-content/uploads/sites/23/2020/06/23/italian-food-2000.jpg", "Italian" },
                    { 6, new DateTime(2020, 5, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://assets.bonappetit.com/photos/5f809c81ba63e7584fca0576/8:5/w_1800,h_1125,c_limit/Double-Garlic-Roast-Chicken-With-Onion-Gravy.jpg", "Chicken" },
                    { 5, new DateTime(2018, 4, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://images.theconversation.com/files/439369/original/file-20220104-19-12kg47e.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=1200&h=900.0&fit=crop", "Candy" },
                    { 4, new DateTime(2015, 3, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://funcakes.com/content/uploads/2021/02/Red-Velvet-Cake-with-Fruit-960x720-c-default.jpg", "Cake" },
                    { 3, new DateTime(2005, 2, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://simply-delicious-food.com/wp-content/uploads/2018/10/breakfast-board.jpg", "Breakfast" },
                    { 10, new DateTime(2000, 9, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://insidr.co/wp-content/uploads/2018/04/Boeuf-Bourguignon-1170x780-2.jpg", "French" }
                });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "id", "lowest_measure_unit_price", "measure_unit", "name", "purchase_measure_quantity", "purchase_price" },
                values: new object[,]
                {
                    { 34, 0.0031099999999999999, 0, "Ingredient 34", 1, 3.1099999999999999 },
                    { 33, 0.00052000000000000006, 0, "Ingredient 33", 1, 0.52000000000000002 },
                    { 32, 0.00332, 0, "Ingredient 32", 1, 3.3199999999999998 },
                    { 31, 0.0040099999999999997, 0, "Ingredient 31", 1, 4.0099999999999998 },
                    { 27, 0.0023599999999999997, 0, "Ingredient 27", 1, 2.3599999999999999 },
                    { 29, 0.0032599999999999999, 0, "Ingredient 29", 1, 3.2599999999999998 },
                    { 28, 0.0039100000000000003, 0, "Ingredient 28", 1, 3.9100000000000001 },
                    { 35, 0.0025999999999999999, 0, "Ingredient 35", 1, 2.6000000000000001 },
                    { 30, 0.0011000000000000001, 0, "Ingredient 30", 1, 1.1000000000000001 },
                    { 36, 0.0042000000000000006, 0, "Ingredient 36", 1, 4.2000000000000002 },
                    { 45, 0.0033300000000000001, 0, "Ingredient 45", 1, 3.3300000000000001 },
                    { 38, 0.0027899999999999999, 0, "Ingredient 38", 1, 2.79 },
                    { 39, 0.00088000000000000003, 0, "Ingredient 39", 1, 0.88 },
                    { 40, 0.0047999999999999996, 0, "Ingredient 40", 1, 4.7999999999999998 },
                    { 41, 0.00199, 0, "Ingredient 41", 1, 1.99 },
                    { 42, 0.0044400000000000004, 0, "Ingredient 42", 1, 4.4400000000000004 },
                    { 43, 0.0026099999999999999, 0, "Ingredient 43", 1, 2.6099999999999999 },
                    { 44, 0.0024300000000000003, 0, "Ingredient 44", 1, 2.4300000000000002 },
                    { 26, 0.0042000000000000006, 0, "Ingredient 26", 1, 4.2000000000000002 },
                    { 46, 0.0047400000000000003, 0, "Ingredient 46", 1, 4.7400000000000002 },
                    { 47, 0.0048600000000000006, 0, "Ingredient 47", 1, 4.8600000000000003 },
                    { 37, 0.0016799999999999999, 0, "Ingredient 37", 1, 1.6799999999999999 },
                    { 25, 0.00296, 0, "Ingredient 25", 1, 2.96 },
                    { 16, 0.00382, 0, "Ingredient 16", 1, 3.8199999999999998 },
                    { 23, 0.0048200000000000005, 0, "Ingredient 23", 1, 4.8200000000000003 },
                    { 1, 0.0049800000000000001, 0, "Ingredient 1", 1, 4.9800000000000004 },
                    { 2, 0.0037000000000000002, 0, "Ingredient 2", 1, 3.7000000000000002 },
                    { 3, 0.0037000000000000002, 0, "Ingredient 3", 1, 3.7000000000000002 },
                    { 4, 0.0035699999999999998, 0, "Ingredient 4", 1, 3.5699999999999998 },
                    { 5, 0.0030099999999999997, 0, "Ingredient 5", 1, 3.0099999999999998 },
                    { 6, 0.00095, 0, "Ingredient 6", 1, 0.94999999999999996 },
                    { 7, 0.00117, 0, "Ingredient 7", 1, 1.1699999999999999 },
                    { 8, 0.0036099999999999999, 0, "Ingredient 8", 1, 3.6099999999999999 },
                    { 9, 0.0021900000000000001, 0, "Ingredient 9", 1, 2.1899999999999999 },
                    { 10, 0.0045500000000000002, 0, "Ingredient 10", 1, 4.5499999999999998 },
                    { 24, 0.00088000000000000003, 0, "Ingredient 24", 1, 0.88 },
                    { 11, 0.0037000000000000002, 0, "Ingredient 11", 1, 3.7000000000000002 },
                    { 13, 0.00069999999999999999, 0, "Ingredient 13", 1, 0.69999999999999996 },
                    { 14, 0.00089999999999999998, 0, "Ingredient 14", 1, 0.90000000000000002 },
                    { 15, 0.0018, 0, "Ingredient 15", 1, 1.8 },
                    { 48, 0.0029500000000000004, 0, "Ingredient 48", 1, 2.9500000000000002 },
                    { 17, 0.0031800000000000001, 0, "Ingredient 17", 1, 3.1800000000000002 },
                    { 18, 0.00058999999999999992, 0, "Ingredient 18", 1, 0.58999999999999997 },
                    { 19, 0.0045899999999999995, 0, "Ingredient 19", 1, 4.5899999999999999 },
                    { 20, 0.0035899999999999999, 0, "Ingredient 20", 1, 3.5899999999999999 },
                    { 21, 0.00381, 0, "Ingredient 21", 1, 3.8100000000000001 },
                    { 22, 0.0017099999999999999, 0, "Ingredient 22", 1, 1.71 },
                    { 12, 0.0023999999999999998, 0, "Ingredient 12", 1, 2.3999999999999999 },
                    { 49, 0.00073999999999999999, 0, "Ingredient 49", 1, 0.73999999999999999 }
                });

            migrationBuilder.InsertData(
                table: "recipes",
                columns: new[] { "id", "category_id", "description", "img_url", "name" },
                values: new object[,]
                {
                    { 39, 2, "Seeded description", "Seeded image", "Recipe 39" },
                    { 36, 9, "Seeded description", "Seeded image", "Recipe 36" },
                    { 28, 10, "Seeded description", "Seeded image", "Recipe 28" },
                    { 27, 11, "Seeded description", "Seeded image", "Recipe 27" },
                    { 32, 11, "Seeded description", "Seeded image", "Recipe 32" },
                    { 33, 11, "Seeded description", "Seeded image", "Recipe 33" },
                    { 37, 11, "Seeded description", "Seeded image", "Recipe 37" },
                    { 38, 11, "Seeded description", "Seeded image", "Recipe 38" },
                    { 24, 12, "Seeded description", "Seeded image", "Recipe 24" },
                    { 25, 12, "Seeded description", "Seeded image", "Recipe 25" },
                    { 43, 12, "Seeded description", "Seeded image", "Recipe 43" },
                    { 5, 13, "Seeded description", "Seeded image", "Recipe 5" },
                    { 41, 13, "Seeded description", "Seeded image", "Recipe 41" },
                    { 4, 14, "Seeded description", "Seeded image", "Recipe 4" },
                    { 14, 14, "Seeded description", "Seeded image", "Recipe 14" },
                    { 17, 14, "Seeded description", "Seeded image", "Recipe 17" },
                    { 48, 14, "Seeded description", "Seeded image", "Recipe 48" },
                    { 1, 15, "Seeded description", "Seeded image", "Recipe 1" },
                    { 10, 15, "Seeded description", "Seeded image", "Recipe 10" },
                    { 16, 15, "Seeded description", "Seeded image", "Recipe 16" },
                    { 23, 15, "Seeded description", "Seeded image", "Recipe 23" },
                    { 3, 16, "Seeded description", "Seeded image", "Recipe 3" },
                    { 35, 9, "Seeded description", "Seeded image", "Recipe 35" },
                    { 15, 17, "Seeded description", "Seeded image", "Recipe 15" },
                    { 11, 9, "Seeded description", "Seeded image", "Recipe 11" },
                    { 7, 9, "Seeded description", "Seeded image", "Recipe 7" },
                    { 13, 3, "Seeded description", "Seeded image", "Recipe 13" },
                    { 26, 3, "Seeded description", "Seeded image", "Recipe 26" },
                    { 40, 3, "Seeded description", "Seeded image", "Recipe 40" },
                    { 42, 3, "Seeded description", "Seeded image", "Recipe 42" },
                    { 18, 4, "Seeded description", "Seeded image", "Recipe 18" },
                    { 30, 4, "Seeded description", "Seeded image", "Recipe 30" },
                    { 6, 5, "Seeded description", "Seeded image", "Recipe 6" },
                    { 19, 5, "Seeded description", "Seeded image", "Recipe 19" },
                    { 21, 5, "Seeded description", "Seeded image", "Recipe 21" },
                    { 22, 5, "Seeded description", "Seeded image", "Recipe 22" },
                    { 49, 5, "Seeded description", "Seeded image", "Recipe 49" },
                    { 29, 6, "Seeded description", "Seeded image", "Recipe 29" },
                    { 46, 6, "Seeded description", "Seeded image", "Recipe 46" },
                    { 9, 7, "Seeded description", "Seeded image", "Recipe 9" },
                    { 20, 7, "Seeded description", "Seeded image", "Recipe 20" },
                    { 31, 7, "Seeded description", "Seeded image", "Recipe 31" },
                    { 44, 7, "Seeded description", "Seeded image", "Recipe 44" },
                    { 45, 7, "Seeded description", "Seeded image", "Recipe 45" },
                    { 2, 8, "Seeded description", "Seeded image", "Recipe 2" },
                    { 12, 8, "Seeded description", "Seeded image", "Recipe 12" },
                    { 34, 8, "Seeded description", "Seeded image", "Recipe 34" },
                    { 8, 9, "Seeded description", "Seeded image", "Recipe 8" },
                    { 47, 17, "Seeded description", "Seeded image", "Recipe 47" }
                });

            migrationBuilder.InsertData(
                table: "recipe_ingredients",
                columns: new[] { "ingredient_id", "recipe_id", "recipe_measure_quantity", "recipe_measure_unit" },
                values: new object[,]
                {
                    { 15, 39, 63, 2 },
                    { 48, 37, 364, 1 },
                    { 46, 37, 361, 1 },
                    { 29, 37, 181, 1 },
                    { 15, 37, 4, 0 },
                    { 5, 37, 4, 0 },
                    { 41, 37, 3, 0 },
                    { 35, 38, 1, 0 },
                    { 38, 38, 1, 0 },
                    { 17, 24, 680, 1 },
                    { 34, 24, 2, 0 },
                    { 28, 24, 4, 0 },
                    { 33, 24, 1, 0 },
                    { 23, 25, 24, 2 },
                    { 5, 25, 21, 2 },
                    { 1, 25, 589, 1 },
                    { 42, 25, 625, 1 },
                    { 17, 25, 2, 0 },
                    { 3, 41, 94, 2 },
                    { 16, 41, 86, 2 },
                    { 13, 5, 1, 0 },
                    { 30, 5, 399, 1 },
                    { 27, 5, 717, 1 },
                    { 16, 5, 644, 1 },
                    { 34, 37, 102, 1 },
                    { 43, 43, 2, 0 },
                    { 24, 43, 295, 1 },
                    { 28, 43, 376, 1 },
                    { 13, 43, 66, 2 },
                    { 8, 43, 51, 2 },
                    { 36, 43, 86, 2 },
                    { 21, 43, 78, 2 },
                    { 14, 43, 4, 0 },
                    { 44, 41, 504, 1 },
                    { 12, 37, 98, 2 },
                    { 41, 33, 1, 0 },
                    { 29, 35, 4, 0 },
                    { 26, 35, 3, 0 },
                    { 47, 36, 15, 2 },
                    { 1, 36, 666, 1 },
                    { 19, 36, 623, 1 },
                    { 22, 36, 264, 1 },
                    { 49, 36, 1, 0 },
                    { 29, 36, 3, 0 },
                    { 48, 36, 3, 0 },
                    { 17, 28, 61, 2 },
                    { 28, 28, 74, 2 },
                    { 10, 28, 30, 2 },
                    { 11, 28, 395, 1 },
                    { 7, 28, 773, 1 },
                    { 36, 28, 118, 1 },
                    { 17, 27, 63, 2 },
                    { 14, 27, 17, 2 },
                    { 48, 33, 461, 1 },
                    { 40, 33, 641, 1 },
                    { 31, 33, 131, 1 },
                    { 27, 33, 769, 1 },
                    { 24, 33, 284, 1 },
                    { 28, 33, 321, 1 },
                    { 36, 37, 25, 2 },
                    { 30, 32, 235, 1 },
                    { 34, 32, 72, 2 },
                    { 6, 32, 46, 2 },
                    { 4, 27, 2, 0 },
                    { 23, 27, 1, 0 },
                    { 48, 27, 40, 2 },
                    { 10, 27, 31, 2 },
                    { 12, 32, 203, 1 },
                    { 36, 35, 29, 2 },
                    { 7, 41, 2, 0 },
                    { 33, 4, 50, 2 },
                    { 40, 16, 2, 0 },
                    { 20, 16, 3, 0 },
                    { 45, 16, 1, 0 },
                    { 38, 23, 66, 2 },
                    { 34, 23, 21, 2 },
                    { 32, 23, 84, 2 },
                    { 37, 23, 15, 2 },
                    { 19, 23, 96, 2 },
                    { 23, 23, 20, 2 },
                    { 13, 23, 17, 2 },
                    { 4, 23, 87, 2 },
                    { 45, 23, 336, 1 },
                    { 17, 23, 479, 1 },
                    { 33, 23, 456, 1 },
                    { 9, 23, 3, 0 },
                    { 43, 23, 3, 0 },
                    { 29, 23, 2, 0 },
                    { 10, 47, 246, 1 },
                    { 49, 47, 32, 2 },
                    { 23, 47, 79, 2 },
                    { 44, 15, 1, 0 },
                    { 28, 15, 4, 0 },
                    { 9, 15, 754, 1 },
                    { 41, 16, 256, 1 },
                    { 10, 15, 235, 1 },
                    { 37, 15, 80, 2 },
                    { 24, 15, 56, 2 },
                    { 30, 15, 20, 2 },
                    { 4, 15, 37, 2 },
                    { 48, 3, 62, 2 },
                    { 16, 3, 99, 2 },
                    { 42, 15, 167, 1 },
                    { 45, 41, 4, 0 },
                    { 21, 16, 355, 1 },
                    { 24, 16, 68, 2 },
                    { 37, 4, 576, 1 },
                    { 41, 4, 748, 1 },
                    { 47, 4, 190, 1 },
                    { 49, 4, 4, 0 },
                    { 48, 4, 3, 0 },
                    { 21, 14, 264, 1 },
                    { 23, 14, 157, 1 },
                    { 28, 14, 1, 0 },
                    { 19, 17, 63, 2 },
                    { 30, 17, 56, 2 },
                    { 34, 17, 322, 1 },
                    { 44, 17, 3, 0 },
                    { 36, 17, 3, 0 },
                    { 41, 17, 3, 0 },
                    { 26, 17, 2, 0 },
                    { 30, 48, 59, 2 },
                    { 28, 48, 32, 2 },
                    { 23, 16, 30, 2 },
                    { 15, 10, 4, 0 },
                    { 48, 10, 4, 0 },
                    { 17, 10, 1, 0 },
                    { 13, 10, 388, 1 },
                    { 20, 10, 691, 1 },
                    { 16, 16, 90, 2 },
                    { 40, 1, 3, 0 },
                    { 31, 1, 3, 0 },
                    { 19, 1, 2, 0 },
                    { 11, 1, 242, 1 },
                    { 1, 1, 113, 1 },
                    { 25, 1, 82, 2 },
                    { 32, 1, 64, 2 },
                    { 10, 1, 4, 0 },
                    { 44, 47, 2, 0 },
                    { 12, 11, 3, 0 },
                    { 1, 11, 4, 0 },
                    { 6, 42, 29, 2 },
                    { 35, 42, 74, 2 },
                    { 2, 42, 58, 2 },
                    { 20, 42, 581, 1 },
                    { 24, 42, 382, 1 },
                    { 16, 42, 1, 0 },
                    { 34, 18, 29, 2 },
                    { 37, 18, 50, 2 },
                    { 25, 18, 96, 2 },
                    { 46, 18, 686, 1 },
                    { 5, 18, 301, 1 },
                    { 23, 18, 785, 1 },
                    { 8, 18, 1, 0 },
                    { 22, 18, 3, 0 },
                    { 11, 30, 79, 2 },
                    { 49, 30, 372, 1 },
                    { 45, 6, 75, 2 },
                    { 17, 21, 46, 2 },
                    { 48, 21, 32, 2 },
                    { 23, 21, 31, 2 },
                    { 24, 19, 2, 0 },
                    { 31, 19, 4, 0 },
                    { 9, 19, 1, 0 },
                    { 13, 42, 55, 2 },
                    { 41, 19, 323, 1 },
                    { 47, 19, 81, 2 },
                    { 23, 6, 1, 0 },
                    { 28, 6, 696, 1 },
                    { 8, 6, 767, 1 },
                    { 36, 6, 581, 1 },
                    { 13, 6, 377, 1 },
                    { 26, 19, 79, 2 },
                    { 9, 21, 199, 1 },
                    { 47, 42, 19, 2 },
                    { 27, 40, 1, 0 },
                    { 48, 39, 18, 2 },
                    { 40, 39, 442, 1 },
                    { 9, 39, 732, 1 },
                    { 34, 39, 605, 1 },
                    { 27, 39, 405, 1 },
                    { 31, 39, 1, 0 },
                    { 33, 39, 3, 0 },
                    { 10, 39, 3, 0 },
                    { 23, 39, 4, 0 },
                    { 32, 39, 3, 0 },
                    { 11, 39, 1, 0 },
                    { 4, 39, 3, 0 },
                    { 32, 13, 60, 2 },
                    { 46, 13, 18, 2 },
                    { 20, 13, 77, 2 },
                    { 30, 13, 45, 2 },
                    { 6, 13, 56, 2 },
                    { 29, 40, 2, 0 },
                    { 19, 40, 187, 1 },
                    { 14, 40, 55, 2 },
                    { 4, 40, 13, 2 },
                    { 11, 40, 36, 2 },
                    { 3, 40, 28, 2 },
                    { 15, 40, 2, 0 },
                    { 16, 40, 71, 2 },
                    { 11, 26, 421, 1 },
                    { 12, 26, 758, 1 },
                    { 43, 26, 80, 2 },
                    { 18, 26, 42, 2 },
                    { 37, 13, 1, 0 },
                    { 27, 13, 387, 1 },
                    { 27, 26, 2, 0 },
                    { 25, 11, 4, 0 },
                    { 20, 21, 3, 0 },
                    { 31, 22, 515, 1 },
                    { 21, 2, 28, 2 },
                    { 3, 2, 39, 2 },
                    { 32, 2, 3, 0 },
                    { 43, 2, 4, 0 },
                    { 24, 2, 1, 0 },
                    { 44, 2, 1, 0 },
                    { 21, 12, 556, 1 },
                    { 27, 12, 727, 1 },
                    { 39, 12, 1, 0 },
                    { 9, 34, 62, 2 },
                    { 10, 34, 108, 1 },
                    { 33, 34, 357, 1 },
                    { 28, 34, 107, 1 },
                    { 16, 34, 132, 1 },
                    { 20, 34, 483, 1 },
                    { 17, 34, 1, 0 },
                    { 23, 34, 1, 0 },
                    { 28, 11, 3, 0 },
                    { 31, 11, 236, 1 },
                    { 9, 11, 223, 1 },
                    { 14, 11, 284, 1 },
                    { 35, 11, 78, 2 },
                    { 38, 11, 22, 2 },
                    { 29, 2, 86, 2 },
                    { 15, 11, 79, 2 },
                    { 44, 8, 364, 1 },
                    { 25, 7, 1, 0 },
                    { 29, 7, 4, 0 },
                    { 42, 7, 3, 0 },
                    { 43, 7, 2, 0 },
                    { 21, 7, 51, 2 },
                    { 35, 8, 336, 1 },
                    { 8, 21, 4, 0 },
                    { 30, 45, 3, 0 },
                    { 43, 45, 371, 1 },
                    { 24, 22, 212, 1 },
                    { 7, 22, 1, 0 },
                    { 32, 49, 49, 2 },
                    { 45, 49, 52, 2 },
                    { 46, 49, 372, 1 },
                    { 20, 49, 641, 1 },
                    { 45, 29, 86, 2 },
                    { 35, 29, 36, 2 },
                    { 15, 29, 481, 1 },
                    { 8, 29, 476, 1 },
                    { 41, 29, 182, 1 },
                    { 2, 46, 69, 2 },
                    { 24, 46, 94, 2 },
                    { 5, 46, 207, 1 },
                    { 41, 46, 396, 1 },
                    { 30, 46, 248, 1 },
                    { 42, 9, 57, 2 },
                    { 47, 44, 2, 0 },
                    { 27, 44, 333, 1 },
                    { 17, 44, 48, 2 },
                    { 16, 31, 3, 0 },
                    { 4, 31, 168, 1 },
                    { 41, 20, 3, 0 },
                    { 48, 45, 100, 1 },
                    { 7, 20, 318, 1 },
                    { 38, 20, 43, 2 },
                    { 46, 20, 45, 2 },
                    { 28, 20, 69, 2 },
                    { 46, 9, 1, 0 },
                    { 44, 9, 265, 1 },
                    { 5, 9, 661, 1 },
                    { 24, 20, 25, 2 },
                    { 17, 47, 4, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_recipe_ingredients_recipe_id",
                table: "recipe_ingredients",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipes_category_id",
                table: "recipes",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe_ingredients");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
