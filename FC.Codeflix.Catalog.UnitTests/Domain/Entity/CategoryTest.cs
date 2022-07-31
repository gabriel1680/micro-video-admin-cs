using FC.Codeflix.Catalog.Domain.Entity;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Entity;

public class CategoryTest
{
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Category - Aggregate")]
    public void Instantiate()
    {
        var validData = new
        {
            Name = "some category name",
            Description = "some description"
        };

        var category = new Category(validData.Name, validData.Description);
        
        Assert.NotNull(category);
        Assert.Equal(category.Name, validData.Name);
        Assert.Equal(category.Description, validData.Description);
        Assert.True(category.IsActive);
    }
    
    [Theory(DisplayName = nameof(Instantiate_With_IsActive))]
    [Trait("Domain", "Category - Aggregate")]
    [InlineData(true)]
    [InlineData(false)]
    public void Instantiate_With_IsActive(bool isActive)
    {
        var validData = new
        {
            Name = "some category name",
            Description = "some description",
            IsActive = isActive
        };

        var category = new Category(validData.Name, validData.Description, validData.IsActive);
        
        Assert.NotNull(category);
        Assert.Equal(category.Name, validData.Name);
        Assert.Equal(category.Description, validData.Description);
        Assert.Equal(category.IsActive, isActive);
    }
    
    [Fact(DisplayName = nameof(Inheritance_from_BaseEntity))]
    [Trait("Domain", "Category - Aggregate")]
    public void Inheritance_from_BaseEntity()
    {
        var validData = new
        {
            Name = "some category name",
            Description = "some description",
        };

        var category = new Category(validData.Name, validData.Description);
        
        Assert.IsType<Guid>(category.Id);
        Assert.IsType<DateTime>(category.CreatedAt);
        Assert.IsType<DateTime>(category.UpdatedAt);
    }
    
    [Fact(DisplayName = nameof(Activate))]
    [Trait("Domain", "Category - Aggregate")]
    public void Activate()
    {
        var validData = new
        {
            Name = "some category name",
            Description = "some description",
            IsActive = false
        };
        var category = new Category(validData.Name, validData.Description);
        var updatedAtBeforeActivate = category.UpdatedAt;
        
        category.Activate();
        
        Assert.True(category.IsActive);
        Assert.True(category.UpdatedAt > updatedAtBeforeActivate);
    }
}