using FC.Codeflix.Catalog.Domain.Entity;

namespace FC.Codeflix.Catalog.Domain.Validator;

public class CategoryValidator
{
    public List<string> Errors;
    public void Validate(Category entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Name))
            Errors.Add($"O campo {nameof(entity.Name)} não pode ser vazio");
        
        if (string.IsNullOrWhiteSpace(entity.Description))
            Errors.Add($"O campo {nameof(entity.Description)} não pode ser vazio");
    }
}