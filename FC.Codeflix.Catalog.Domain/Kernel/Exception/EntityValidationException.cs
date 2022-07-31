namespace FC.Codeflix.Catalog.Domain.Kernel.Exception;

using System;

public class EntityValidationException : Exception
{
    public EntityValidationException(string? message) : base(message)
    {
    }
}