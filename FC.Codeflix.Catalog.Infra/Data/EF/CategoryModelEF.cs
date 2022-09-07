using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Kernel.ValueObject;

namespace FC.Codeflix.Catalog.Infra.Data.EF;

public record CategoryModelEF(
    Guid Id,
    string Name,
    string Description,
    bool IsActive,
    DateTime CreatedAt,
    DateTime UpdatedAt
)
{
    public Category? ToEntity() => new(
            new UniqueEntityId(Id),
            CreatedAt, 
            UpdatedAt, 
            Name, 
            Description,
            IsActive
        );

    public static CategoryModelEF From(Category entity) => new(
        entity.Id.Value,
        entity.Name, 
        entity.Description,
        entity.IsActive,
        entity.CreatedAt,
        entity.UpdatedAt
    );
}