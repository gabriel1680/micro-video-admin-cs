namespace FC.Codeflix.Catalog.Domain.Kernel.Repository;

public interface IUpdateRepository<E> where E : IEntity
{
    Task Update(E entity);
    Task Update(E entity, CancellationToken cancellationToken);
}