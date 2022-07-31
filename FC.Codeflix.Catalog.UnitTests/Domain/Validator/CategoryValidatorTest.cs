using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Kernel.Exception;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Validator;

public class CategoryValidatorTest
{
    [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsEmpty))]
    [Trait("Domain", "Category - Validator")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("  ")]
    public void InstantiateErrorWhenNameIsEmpty(string? name)
    {
        Action action = () => new Category(name!, "category description");
        Assert.Throws<EntityValidationException>(action);
    }
    
    [Fact(DisplayName = nameof(InstantiateErrorWhenDescriptionIsNull))]
    [Trait("Domain", "Category - Validator")]
    public void InstantiateErrorWhenDescriptionIsNull()
    {
        Action action = () => new Category("some name", null!);
        Assert.Throws<EntityValidationException>(action);
    }
    
    [Theory(DisplayName = nameof(UpdateValuesErrorWhenNameIsEmpty))]
    [Trait("Domain", "Category - Validator")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void UpdateValuesErrorWhenNameIsEmpty(string? aName)
    {
        var category = new Category("some name", "some description");
        
        Action action = () => category.UpdateValues(aName!, "some description");
        
        Assert.Throws<EntityValidationException>(action);
    }
}