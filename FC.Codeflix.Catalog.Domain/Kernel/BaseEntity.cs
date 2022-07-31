namespace FC.Codeflix.Catalog.Domain.Kernel;

public abstract class BaseEntity
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    protected BaseEntity(Guid id, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    protected void Update()
    {
        UpdatedAt = DateTime.Now;
    }
}