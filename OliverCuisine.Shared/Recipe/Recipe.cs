using OliverCuisine.Core.Entities;

namespace OliverCuisine.Shared.Entities;

public record RecipeDetail
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int NumberOfServings {get; set;}
    public required string Instructions { get; set; }
    public required string ImageUrl { get; set; }

    public void Validate()
    {
        if(string.IsNullOrEmpty(Name)){
            throw new Exception("Name is required");
        }
        if(string.IsNullOrEmpty(Description)){
            throw new Exception("Description is required");
        }
        if(NumberOfServings <= 0){
            throw new Exception("Number of servings must be greater than 0");
        }
        if(string.IsNullOrEmpty(Instructions)){
            throw new Exception("Instructions are required");
        }
        if(string.IsNullOrEmpty(ImageUrl)){
            throw new Exception("Image URL is required");
        }
    }
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
