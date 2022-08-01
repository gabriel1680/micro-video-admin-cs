namespace FC.Codeflix.Catalog.Domain.Kernel.Repository;

public interface ICreateRepository<E> where E : IEntity
{
    Task Create(E entity);
    Task Create(E entity, CancellationToken cancellationToken);
}