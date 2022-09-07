using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Kernel.ValueObject;

namespace FC.Codeflix.Catalog.Infra.Data.EF;

public class CategoryMapperEF
{
    public static Category ToDomain(CategoryModelEF dbModel) 
        => new Category(
            new UniqueEntityId(dbModel.Id),
            DateTime.Now, 
            DateTime.Now, 
            dbModel.Name, 
            dbModel.Description
        );
    
    public static CategoryModelEF ToPersistence(Category entity) 
        => new(
            entity.Id.Value,
            entity.Name, 
            entity.Description,
            entity.IsActive,
            entity.CreatedAt,
            entity.UpdatedAt
        );
}