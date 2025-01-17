using System;
using OliverCuisine.Core.Entities;

namespace OliverCuisine.Core.Interfaces;

public interface IRecipeRepository
{
    Task<IReadOnlyList<Recipe>> GetRecipesAsync();
    Task<Recipe?> GetRecipeByIdAsync(long id);
    void AddRecipe(Recipe recipe);
    void UpdateRecipe(Recipe recipe);
    void DeleteRecipe(Recipe recipe);
    bool RecipeExists(long id);
    Task<bool> SaveChangesAsync();
}
