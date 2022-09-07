namespace FC.CodeFlix.Catalog.Application.Exception;

using System;

public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message)
    {
    }
}