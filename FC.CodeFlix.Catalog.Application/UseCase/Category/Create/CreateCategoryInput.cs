namespace FC.CodeFlix.Catalog.Application.UseCase.Category;

public record CreateCategoryInput(string Name, string Description, bool IsActive = true);