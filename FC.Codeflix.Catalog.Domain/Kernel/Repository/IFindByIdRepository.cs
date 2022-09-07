using FC.Codeflix.Catalog.Domain.Kernel.Entity;

namespace FC.Codeflix.Catalog.Domain.Kernel.Repository;

public interface IFindByIdRepository<E> where E : IEntity
{
    Task<E> FindById(Guid id);
    Task<E> FindById(Guid id, CancellationToken cancellationToken);
}