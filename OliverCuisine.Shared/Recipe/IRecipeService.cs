using System;
using OliverCuisine.Shared.Entities;

namespace OliverCuisine.Shared;

public interface IRecipeService
{
    Task<bool> AddRecipeAsync(RecipeDetail Recipe);
    Task<bool> UpdateRecipeAsync(RecipeDetail Recipe);
    Task<bool> DeleteRecipeAsync(long RecipeId);
    Task<RecipeDetail> GetRecipeByIdAsync(long RecipeId);
    Task<IEnumerable<RecipeDetail>> GetRecipes();
}
