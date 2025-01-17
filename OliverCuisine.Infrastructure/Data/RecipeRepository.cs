using System;
using Microsoft.EntityFrameworkCore;
using OliverCuisine.Core.Entities;
using OliverCuisine.Core.Interfaces;

namespace OliverCuisine.Infrastructure.Data;

public class RecipeRepository : IRecipeRepository
{
    #region Constructor
    readonly StoreDbContext context;
    public RecipeRepository(StoreDbContext context)
    {
        this.context = context;
    }
    #endregion

    public void AddRecipe(Recipe recipe)
    {
        context.Add(recipe);
    }

    public void DeleteRecipe(Recipe recipe)
    {
        context.Remove(recipe);
    }

    public async Task<Recipe?> GetRecipeByIdAsync(long id)
    {
        return await context.Recipes.FindAsync(id);
    }

    public async Task<IReadOnlyList<Recipe>> GetRecipesAsync()
    {
        return await context.Recipes.ToListAsync();
    }

    public bool RecipeExists(long id)
    {
        return context.Recipes.Any(r => r.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateRecipe(Recipe recipe)
    {
        context.Update(recipe);
    }
}
