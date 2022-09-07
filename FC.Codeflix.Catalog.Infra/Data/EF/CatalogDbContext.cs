using Microsoft.EntityFrameworkCore;

namespace FC.Codeflix.Catalog.Infra.Data.EF;

public class CatalogDbContext : DbContext
{
    public DbSet<CategoryModelEF> Categories => Set<CategoryModelEF>();
    
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryRepositoryConfiguration());
    }
}