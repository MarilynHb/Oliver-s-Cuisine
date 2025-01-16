using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OliverCuisine.Core.Entities;

namespace OliverCuisine.Infrastructure.Config;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        //we can use the fluent API to configure the properties of the Recipe entity
        //this is an example where we are setting the column type for the NumberOfServings property
        // builder.Property(x => x.NumberOfServings).HasColumnType("int");
    }
}
