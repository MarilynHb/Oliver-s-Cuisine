using Microsoft.AspNetCore.Mvc;
using OliverCuisine.Core.Entities;
using OliverCuisine.Shared;
using OliverCuisine.Shared.Entities;

namespace OliverCuisine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    #region  Controller
    private IRecipeService service { get; }
    public RecipesController(IRecipeService recipe)
    {
        this.service = recipe;
    }
    #endregion

    #region  Get
    [HttpGet]   
    public async Task<ActionResult<IReadOnlyList<Recipe>>> GetRecipes()
    {
        return Ok(await service.GetRecipes());
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<RecipeDetail>> GetRecipe(long id)
    {
        var recipe = await service.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return recipe;
    }
    #endregion
    
    #region Post
    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody]RecipeDetail recipe)
    {
        if(await service.AddRecipeAsync(recipe))
        {
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }
        return BadRequest("Problem adding recipe");
    }
    #endregion

    #region Put
    [HttpPut("{id:long}")]
    public async Task<ActionResult> UpdateRecipe(long id, RecipeDetail recipe)
    {
        if (recipe.Id != id)
        {
            return BadRequest("Cannot update this recipe");
        }
        if (await service.UpdateRecipeAsync(recipe))
        {
            return NoContent();
        }
        return BadRequest("Problem updating recipe");
    }
    #endregion

    #region  Delete
    [HttpDelete("{id:long}")]
    public async Task<ActionResult> DeleteRecipe(long id)
    {
        var recipe = await service.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        if (await service.DeleteRecipeAsync(recipe.Id))
        {
            return NoContent();
        }
        return BadRequest("Problem deleting recipe");
    }
    #endregion
}
