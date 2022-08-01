using FC.Codeflix.Catalog.Domain.Kernel.ValueObject;

namespace FC.Codeflix.Catalog.Domain.Kernel;

public abstract class BaseEntity : IEntity
{
    public UniqueEntityId Id { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    protected BaseEntity()
    {
        Id = new UniqueEntityId();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    protected BaseEntity(UniqueEntityId id, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    protected void Update()
    {
        UpdatedAt = DateTime.Now;
    }

    protected bool Equals(BaseEntity other)
    {
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BaseEntity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}