namespace FC.Codeflix.Catalog.Domain.Kernel.ValueObject;

public class UniqueEntityId : BaseValueObject<Guid>
{
    public UniqueEntityId(Guid? value = null) : base(value ?? Guid.NewGuid())
    {
    }
}