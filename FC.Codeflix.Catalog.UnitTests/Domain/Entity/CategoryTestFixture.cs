using FC.Codeflix.Catalog.Domain.Entity;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Entity;

public class CategoryTestFixture
{
    public Category NewCategory() => new ("Category Name", "Category Description");

    public Category NewActiveCategory() => new ("Category Name", "Category Description", true);
    
    public Category NewDeactivatedCategory() 
        => new ("Category Name", "Category Description", false);
}

[CollectionDefinition(nameof(CategoryTestFixture))]
public class CategoryTestFixtureCollection : ICollectionFixture<CategoryTestFixture> { }