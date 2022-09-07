using FC.Codeflix.Catalog.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace FC.Codeflix.Catalog.Infrastructure.Infra.Data.EF.Repositories.Category;

using Domain.Entity;

public class CategoryRepositoryTestFixture
{
    private readonly CatalogDbContext _context;
    
    public Category GetExampleCategory() 
        => new("some name", "some description", true);

    public CatalogDbContext CreateDbContext()
        => new(
            new DbContextOptionsBuilder<CatalogDbContext>()
                .UseInMemoryDatabase("integration-tests-db")
                .Options
            );
}