using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OliverCuisine.Core.Entities;
using OliverCuisine.Core.Interfaces;
using OliverCuisine.Infrastructure.Data;

namespace OliverCuisine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    #region  Controller
    private IGenericRepository<Recipe> repository { get; }
    public RecipesController(IGenericRepository<Recipe> repository)
    {
        this.repository = repository;
    }
    #endregion

    [HttpGet]   
    public async Task<ActionResult<IReadOnlyList<Recipe>>> GetRecipes()
    {
        return Ok(await repository.ListAllAsync());
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Recipe>> GetRecipe(long id)
    {
        var recipe = await repository.GetByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return recipe;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody]Recipe recipe)
    {
        repository.Add(recipe);
        if(await repository.SaveAllAsync())
        {
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }
        return BadRequest("Problem adding recipe");
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult> UpdateRecipe(long id, Recipe recipe)
    {
        if (recipe.Id != id || !RecipeExists(id))
        {
            return BadRequest("Cannot update this recipe");
        }
        repository.Update(recipe);
        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }
        return BadRequest("Problem updating recipe");
    }

    bool RecipeExists(long id)
    {
        return repository.Exists(id);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult> DeleteRecipe(long id)
    {
        var recipe = await repository.GetByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        repository.Delete(recipe);
        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }
        return BadRequest("Problem deleting recipe");
    }

}
