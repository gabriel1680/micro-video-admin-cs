using FC.CodeFlix.Catalog.Application.Exception;
using FC.Codeflix.Catalog.Infra.Data.EF;

namespace FC.Codeflix.Catalog.Infrastructure.Infra.Data.EF.Repositories.Category;

using Domain.Entity;

[Collection(nameof(CategoryRepositoryTestFixture))]
public class CategoryRepositoryTest
{
    private readonly CategoryRepositoryTestFixture _fixture = new(); 
    
    [Fact(DisplayName = nameof(Create))]
    [Trait("Infra", "Category - Repository")]
    public async Task Create()
    {
        var dbCtx = _fixture.CreateDbContext();
        var category = _fixture.GetExampleCategory();
        var sut = new CategoryRepositoryEF(dbCtx);

        await sut.Create(category, CancellationToken.None);
        await dbCtx.SaveChangesAsync(CancellationToken.None);

        var dbCategory = await dbCtx.Categories.FindAsync(category.Id.Value);
        Assert.NotNull(dbCategory);
        Assert.IsType<CategoryModelEF>(dbCategory);
        Assert.Equal(dbCategory?.Id, category.Id.Value);
        Assert.Equal(dbCategory?.Name, category.Name);
        Assert.Equal(dbCategory?.Description, category.Description);
        Assert.Equal(dbCategory?.IsActive, category.IsActive);
        Assert.Equal(dbCategory?.CreatedAt, category.CreatedAt);
        Assert.Equal(dbCategory?.UpdatedAt, category.UpdatedAt);
    }
    
    [Fact(DisplayName = nameof(FindById))]
    [Trait("Infra", "Category - Repository")]
    public async Task FindById()
    {
        var dbCtx = _fixture.CreateDbContext();
        var exampleCategory = _fixture.GetExampleCategory();
        var sut = new CategoryRepositoryEF(dbCtx);
        await sut.Create(exampleCategory, CancellationToken.None);
        await dbCtx.SaveChangesAsync(CancellationToken.None);

        var category = await sut.FindById(exampleCategory.Id.Value, CancellationToken.None);
        
        Assert.NotNull(category);
        Assert.IsType<Category>(category);
        Assert.Equal(category?.Name, exampleCategory.Name);
        Assert.Equal(category?.Description, exampleCategory.Description);
        Assert.Equal(category?.IsActive, exampleCategory.IsActive);
        Assert.Equal(category?.CreatedAt, exampleCategory.CreatedAt);
        Assert.Equal(category?.UpdatedAt, exampleCategory.UpdatedAt);
    }
    
    [Fact(DisplayName = nameof(FindByIdThrowsNotFoundException))]
    [Trait("Infra", "Category - Repository")]
    public async Task FindByIdThrowsNotFoundException()
    {
        var dbCtx = _fixture.CreateDbContext();
        var nonExistentId = Guid.NewGuid();
        var sut = new CategoryRepositoryEF(dbCtx);

        async Task ShouldFuncThrow() => await sut.FindById(nonExistentId, CancellationToken.None);

        var exception = await Assert.ThrowsAsync<NotFoundException>(ShouldFuncThrow);
        Assert.Equal(exception.Message, $"A categoria com o Id {nonExistentId} não foi encontrado");
    }
}