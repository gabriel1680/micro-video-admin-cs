using FC.Codeflix.Catalog.Domain.Kernel;
using FC.Codeflix.Catalog.Domain.Kernel.ValueObject;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Kernel;

public class BaseEntityTest
{
    private class StubEntity : BaseEntity
    {
        public StubEntity() {}
        public StubEntity(UniqueEntityId id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt) {}
    }
    
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Kernel")]
    public void Instantiate()
    {
        var entity = new StubEntity();
        
        Assert.NotNull(entity);
        Assert.IsType<UniqueEntityId>(entity.Id);
        Assert.IsType<DateTime>(entity.CreatedAt);
        Assert.IsType<DateTime>(entity.UpdatedAt);
    }
    
    [Fact(DisplayName = nameof(InstantiateWithParams))]
    [Trait("Domain", "Kernel")]
    public void InstantiateWithParams()
    {
        var data = new
        {
            Id = new UniqueEntityId(), CreatedAt = new DateTime(), UpdatedAt = new DateTime()
        };
        
        var entity = new StubEntity(data.Id, data.CreatedAt, data.UpdatedAt);
        
        Assert.NotNull(entity);
        Assert.IsType<UniqueEntityId>(entity.Id);
        Assert.IsType<DateTime>(entity.CreatedAt);
        Assert.IsType<DateTime>(entity.UpdatedAt);
    }
}