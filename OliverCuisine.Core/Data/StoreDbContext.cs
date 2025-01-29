using Microsoft.EntityFrameworkCore;
using OliverCuisine.Core.Entities;
using OliverCuisine.Core.Config;

namespace OliverCuisine.Core.Data;

public class StoreDbContext : DbContext, IStoreEntities
{
    #region  Constructor
    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }
    #endregion

    #region Recipe
    internal DbSet<Recipe> Recipes { get; set; }
    public IQueryable<Recipe> RecipeEntities => Set<Recipe>();
    public void Add(Recipe recipe) => Recipes.Add(recipe);
    public void Delete(Recipe recipe) => Recipes.Remove(recipe);
    public async Task<Recipe?> GetByIdAsync(long id) => await Recipes.FindAsync(id);
    public async Task<IReadOnlyList<Recipe>> ListAllAsync() => await Recipes.ToListAsync();
    public bool Exists(long id) => Recipes.Any(r => r.Id == id);
    public async Task<bool> SaveAllAsync() => await SaveChangesAsync() > 0;
    public void Update(Recipe recipe) 
    {
        Recipes.Attach(recipe);
        Recipes.Entry(recipe).State = EntityState.Modified;
    }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeEntityConfiguration).Assembly);
    }
}

public interface IStoreEntities
{
    IQueryable<Recipe> RecipeEntities {get;}
    void Add(Recipe recipe);
    void Update(Recipe recipe);
    void Delete(Recipe recipe);
    Task<Recipe?> GetByIdAsync(long id);
    Task<IReadOnlyList<Recipe>> ListAllAsync();
    bool Exists(long id);
    Task<bool> SaveAllAsync();
}
