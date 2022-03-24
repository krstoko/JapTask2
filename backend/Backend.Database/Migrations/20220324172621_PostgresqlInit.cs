using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Normative_Calculator.Database.Migrations
{
    public partial class PostgresqlInit : Migration
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
                    { 15, new DateTime(2016, 6, 2, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://food-images.files.bbci.co.uk/food/recipes/chickensoup_1918_16x9.jpg", "Soup" },
                    { 14, new DateTime(2005, 1, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://post.healthline.com/wp-content/uploads/2020/09/vegetarian-diet-plan-732x549-thumbnail.jpg", "Vegetarian" },
                    { 12, new DateTime(2002, 11, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://www.thoughtco.com/thmb/F5IEThuihsz_k-ptOUx1SP4KJoI=/2119x1192/smart/filters:no_upscale()/chopped-pork-meat-cooked-with-red-chili-paste--gochujang-sauce--over-rice-690784532-5c8bd3dc46e0fb000146acf1.jpg", "Rice" },
                    { 11, new DateTime(2001, 10, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://www.healthyeating.org/images/default-source/home-0.0/nutrition-topics-2.0/general-nutrition-wellness/2-2-2-3foodgroups_fruits_detailfeature.jpg?sfvrsn=64942d53_4", "Fruit" },
                    { 13, new DateTime(2003, 12, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "https://www.thespruceeats.com/thmb/TTsydZkvlx25nvMQPZq0wB5o87c=/1500x1500/smart/filters:no_upscale()/GettyImages-1042998066-518ca1d7f2804eb09039e9e42e91667c.jpg", "Thai" },
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
                    { 5, 0.0030000000000000001, 0, "Mljeveno meso", 1, 3.0 },
                    { 1, 0.0015, 3, "Ulje", 1, 1.5 },
                    { 2, 0.00080000000000000004, 3, "Mlijeko", 1, 0.80000000000000004 },
                    { 3, 0.001, 3, "Voda", 1, 1.0 },
                    { 4, 0.002, 0, "Brasno", 1, 2.0 },
                    { 6, 0.0023, 0, "Tjestenina", 1, 2.2999999999999998 }
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
