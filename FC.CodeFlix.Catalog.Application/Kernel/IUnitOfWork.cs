namespace FC.CodeFlix.Catalog.Application;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}