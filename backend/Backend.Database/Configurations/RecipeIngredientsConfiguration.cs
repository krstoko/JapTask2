using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data.Configurations
{
    public class RecipeIngredientsConfiguration : IEntityTypeConfiguration<RecipesIngredients>
    {
        public void Configure(EntityTypeBuilder<RecipesIngredients> builder)
        {
            builder.Property(x => x.Recipe_Id).IsRequired();
            builder.Property(x => x.Ingredient_Id).IsRequired();
            builder.Property(x => x.Recipe_Measure_Quantity).IsRequired();
            builder.Property(x => x.Recipe_Measure_Unit).IsRequired();
            builder.HasKey(ri => new { ri.Ingredient_Id, ri.Recipe_Id });
            builder.HasOne(r => r.Recipe).WithMany(ri => ri.Recipes_Ingredients).HasForeignKey(r => r.Recipe_Id);
            builder.HasOne(i => i.Ingredient).WithMany(ri => ri.Recipes_Ingredients).HasForeignKey(i => i.Ingredient_Id);
        }
    }
}
