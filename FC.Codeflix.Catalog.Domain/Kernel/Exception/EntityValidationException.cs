namespace FC.Codeflix.Catalog.Domain.Kernel.Exception;

public class EntityValidationException : System.Exception
{
    public EntityValidationException(string? message) : base(message)
    {
    }
}