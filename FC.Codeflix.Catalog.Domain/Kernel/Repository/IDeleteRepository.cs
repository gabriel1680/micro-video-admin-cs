namespace FC.Codeflix.Catalog.Domain.Kernel.Repository;

public interface IDeleteRepository
{
    Task Delete(Guid id);
    Task Delete(Guid id, CancellationToken cancellationToken);
}