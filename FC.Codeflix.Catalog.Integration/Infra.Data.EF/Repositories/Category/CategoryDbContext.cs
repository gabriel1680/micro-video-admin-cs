using Microsoft.EntityFrameworkCore;

namespace FC.Codeflix.Catalog.Infrastructure.Infra.Data.EF.Repositories.Category;

using FC.Codeflix.Catalog.Domain.Entity;

public class CategoryDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    
    public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryRepositoryConfiguration());
    }
}