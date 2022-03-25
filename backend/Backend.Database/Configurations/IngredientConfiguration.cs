using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Normative_Calculator.Database.SeedData;

namespace backend.Data.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(127);
            builder.Property(x => x.Purchase_Price).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Measure_Unit).IsRequired();
            builder.Property(x => x.Purchase_Measure_Quantity).IsRequired();
            builder.HasData(IngredientData.GetIngredients());
        }
    }
}
