using FC.Codeflix.Catalog.Domain.Entity;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Entity;

[Collection(nameof(CategoryTestFixture))]
public class CategoryTest
{
    private readonly CategoryTestFixture _categoryTestFixture;

    public CategoryTest(CategoryTestFixture categoryTestFixture) 
        => _categoryTestFixture = categoryTestFixture;

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
        var category = _categoryTestFixture.NewDeactivatedCategory();
        var updatedAtBeforeActivate = category.UpdatedAt;
        
        category.Activate();
        
        Assert.True(category.IsActive);
        Assert.True(category.UpdatedAt > updatedAtBeforeActivate);
    }
    
    [Fact(DisplayName = nameof(Deactivate))]
    [Trait("Domain", "Category - Aggregate")]
    public void Deactivate()
    {
        var category = _categoryTestFixture.NewActiveCategory();
        var updatedAtBeforeActivate = category.UpdatedAt;
        
        category.Deactivate();
        
        Assert.False(category.IsActive);
        Assert.True(category.UpdatedAt > updatedAtBeforeActivate);
    }
    
    [Fact(DisplayName = nameof(UpdateValues))]
    [Trait("Domain", "Category - Aggregate")]
    public void UpdateValues()
    {
        var category = _categoryTestFixture.NewCategory();
        var updatedData = new
        {
            Name = "name updated",
            Description = "description updated",
        };
        var updatedAtBeforeActivate = category.UpdatedAt;
        
        category.UpdateValues(updatedData.Name, updatedData.Description);
        
        Assert.Equal(category.Name, updatedData.Name);
        Assert.Equal(category.Description, updatedData.Description);
        Assert.True(category.UpdatedAt > updatedAtBeforeActivate);
    }
    
    [Fact(DisplayName = nameof(UpdateNameOnly))]
    [Trait("Domain", "Category - Aggregate")]
    public void UpdateNameOnly()
    {
        var category = _categoryTestFixture.NewCategory();
        var currentDescription = category.Description;
        var newName = "updated name";
        var updatedAtBeforeActivate = category.UpdatedAt;
        
        category.UpdateValues(newName);
        
        Assert.Equal(category.Name, newName);
        Assert.Equal(category.Description, currentDescription);
        Assert.True(category.UpdatedAt > updatedAtBeforeActivate);
    }
}