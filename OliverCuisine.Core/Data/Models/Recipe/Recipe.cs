using System.ComponentModel.DataAnnotations;

namespace OliverCuisine.Core.Entities;

public class Recipe : BaseEntity
{
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(500)]
    public required string Description { get; set; }
    public required int NumberOfServings {get; set;}
    [MaxLength(500)]
    public required string Instructions { get; set; }
    [MaxLength(500)]
    public required string ImageUrl { get; set; }
}
