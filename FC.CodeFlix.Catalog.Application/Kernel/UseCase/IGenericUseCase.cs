namespace FC.CodeFlix.Catalog.Application.UseCase;

public interface IGenericUseCase<I, O>
{
    Task<O> Execute(I input, CancellationToken cancellationToken);
}