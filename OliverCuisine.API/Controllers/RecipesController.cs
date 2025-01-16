using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OliverCuisine.Core.Entities;
using OliverCuisine.Infrastructure.Data;

namespace OliverCuisine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    #region  Controller
    private StoreDbContext context { get; }
    public RecipesController(StoreDbContext context)
    {
        this.context = context;
    }
    #endregion

    [HttpGet]   
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
    {
        return await context.Recipes.ToListAsync();
    }

    [HttpGet("{id:long}")] //api/recipes/1
    public async Task<ActionResult<Recipe>> GetRecipe(long id)
    {
        var recipe = await context.Recipes.FindAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return recipe;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody]Recipe recipe)
    {
        context.Recipes.Add(recipe);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult> UpdateRecipe(long id, Recipe recipe)
    {
        if (recipe.Id != id || !RecipeExists(id))
        {
            return BadRequest("Cannot update this recipe");
        }
        context.Entry(recipe).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    bool RecipeExists(long id)
    {
        return context.Recipes.Any(e => e.Id == id);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult> DeleteRecipe(long id)
    {
        var recipe = await context.Recipes.FindAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        context.Recipes.Remove(recipe);
        await context.SaveChangesAsync();
        return NoContent();
    }

}
