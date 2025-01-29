using Microsoft.EntityFrameworkCore;
using OliverCuisine.Core.Data;
using OliverCuisine.Shared;
using OliverCuisine.Shared.Entities;

namespace OliverCuisine.Server;

public class RecipeService : IRecipeService
{
    readonly StoreDbContext context;
    public RecipeService(StoreDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddRecipeAsync(RecipeDetail Recipe)
    {
        try
        {
            Recipe.Validate();
            var entity = Recipe.ToEntity();
            context.Add(entity);
            return await context.SaveAllAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteRecipeAsync(long RecipeId)
    {
        try{
            var entity = await context.GetByIdAsync(RecipeId);
            if(entity == null){
                return false;
            }
            context.Delete(entity);
            return await context.SaveAllAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<RecipeDetail> GetRecipeByIdAsync(long RecipeId)
    {
        var entity = await context.GetByIdAsync(RecipeId) ?? throw new Exception("Recipe not found");
        return entity.ToDto();
    }

    public async Task<IEnumerable<RecipeDetail>> GetRecipes()
    {
        return await context.RecipeEntities.Select(r => r.ToDto()).ToListAsync();
    }

    public async Task<bool> UpdateRecipeAsync(RecipeDetail Recipe)
    {
        try
        {
            Recipe.Validate();
            var entity = Recipe.ToEntity();
            context.Update(entity);
            return await context.SaveAllAsync();
        }
        catch
        {
            return false;
        }
    }
}
