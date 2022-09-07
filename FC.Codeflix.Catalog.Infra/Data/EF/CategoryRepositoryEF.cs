using FC.CodeFlix.Catalog.Application.Exception;
using Microsoft.EntityFrameworkCore;

namespace FC.Codeflix.Catalog.Infra.Data.EF;

using Domain.Entity;
using Domain.Repository;

public class CategoryRepositoryEF : ICategoryRepository
{
    private readonly CatalogDbContext _context;

    public CategoryRepositoryEF(CatalogDbContext context) => _context = context;

    private DbSet<CategoryModelEF> _categories => _context.Set<CategoryModelEF>();

    public async Task Create(Category entity) 
        => await _categories.AddAsync(CategoryModelEF.From(entity), CancellationToken.None);

    public async Task Create(Category entity, CancellationToken cancellationToken)
        => await _categories.AddAsync(CategoryModelEF.From(entity), cancellationToken);

    public Task Update(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Category entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> FindById(Guid id)
    {
        var dbCategory = await _categories.FindAsync(id);
        return dbCategory?.ToEntity() ?? 
               throw new NotFoundException($"A categoria com o Id {id} não foi encontrado");
    }

    public async Task<Category> FindById(Guid id, CancellationToken cancellationToken)
    {
        var dbCategory = await _categories.FindAsync(id, cancellationToken);
        return dbCategory?.ToEntity() ?? 
               throw new NotFoundException($"A categoria com o Id {id} não foi encontrado");
    }
        

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}