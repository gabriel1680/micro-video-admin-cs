using FC.Codeflix.Catalog.Domain.Kernel.Exception;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Kernel.Exception;

public class EntityValidationExceptionTest
{
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Kernel - Exception")]
    public void Instantiate()
    {
        const string message = "some error message";

        var exception = new EntityValidationException(message);
        
        Assert.Equal(exception.Message, message);
    }
}