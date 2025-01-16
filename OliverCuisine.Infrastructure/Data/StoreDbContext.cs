using System;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OliverCuisine.Core.Entities;
using OliverCuisine.Infrastructure.Config;

namespace OliverCuisine.Infrastructure.Data;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeConfiguration).Assembly);
    }
}
