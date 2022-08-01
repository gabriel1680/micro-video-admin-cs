namespace FC.CodeFlix.Catalog.Application.UseCase.Category.Create.DTO;

public record CreateCategoryInput(string Name, string Description, bool IsActive = true);