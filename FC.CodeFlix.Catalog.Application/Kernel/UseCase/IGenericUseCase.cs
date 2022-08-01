namespace FC.CodeFlix.Catalog.Application.Kernel.UseCase;

public interface IGenericUseCase<I, O>
{
    Task<O> Execute(I input, CancellationToken cancellationToken);
}