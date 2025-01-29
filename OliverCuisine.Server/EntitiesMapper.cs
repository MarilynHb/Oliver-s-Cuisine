using OliverCuisine.Core.Entities;
using OliverCuisine.Shared.Entities;

namespace OliverCuisine.Server;

public static class EntitiesMapper
{
    internal static RecipeDetail MapToDetail(this Recipe Recipe)
    {
        return new RecipeDetail
        {
            Id = Recipe.Id,
            Name = Recipe.Name,
            Description = Recipe.Description,
            NumberOfServings = Recipe.NumberOfServings,
            Instructions = Recipe.Instructions,
            ImageUrl = Recipe.ImageUrl
        };
    }
    internal static Recipe MapToEntity(this RecipeDetail Recipe)
    {
        return new Recipe
        {
            Id = Recipe.Id,
            Name = Recipe.Name,
            Description = Recipe.Description,
            NumberOfServings = Recipe.NumberOfServings,
            Instructions = Recipe.Instructions,
            ImageUrl = Recipe.ImageUrl
        };
    }
}
