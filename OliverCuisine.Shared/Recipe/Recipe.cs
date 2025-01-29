using System.ComponentModel.DataAnnotations;
using OliverCuisine.Core.Entities;

namespace OliverCuisine.Shared.Entities;

public record RecipeDetail
{
    public long Id { get; set; } = default;

    [Required]
    public required string Name { get; set; }
    
    [Required]
    public required string Description { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Number of servings must be greater than 0")]
    public required int NumberOfServings {get; set;}
    
    [Required]
    public required string Instructions { get; set; }
    
    [Required]
    public required string ImageUrl { get; set; }
}

public static partial class EntitiesToDtoExtensions
{
    public static RecipeDetail ToDto(this Recipe entity)
    {
        return new RecipeDetail
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            NumberOfServings = entity.NumberOfServings,
            Instructions = entity.Instructions,
            ImageUrl = entity.ImageUrl
        };
    }
    public static Recipe ToEntity(this RecipeDetail dto)
    {
        return new Recipe
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            NumberOfServings = dto.NumberOfServings,
            Instructions = dto.Instructions,
            ImageUrl = dto.ImageUrl
        };
    }
}
