using FC.Codeflix.Catalog.Domain.Kernel.Entity;
using FC.Codeflix.Catalog.Domain.Kernel.Exception;
using FC.Codeflix.Catalog.Domain.Kernel.ValueObject;

namespace FC.Codeflix.Catalog.Domain.Entity;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }

    public Category(string name, string description, bool isActive = true)
    {
        Name = name;
        Description = description;
        IsActive = isActive;
        
        Validate();
    }

    public Category(
        UniqueEntityId id, 
        DateTime createdAt, 
        DateTime updatedAt, 
        string name,
        string description, 
        bool isActive = true
        ) : base(id, createdAt, updatedAt)
    {
        Name = name;
        Description = description;
        IsActive = isActive;
        
        Validate();
    }

    public void Activate()
    {
        IsActive = true;
        Update();
    }
    
    public void Deactivate()
    {
        IsActive = false;
        Update();
    }

    public void UpdateValues(string name, string? description = null)
    {
        Name = name;
        Description = description ?? Description;
        Validate();
        Update();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name)) 
            throw new EntityValidationException($"O campo {nameof(Name)} não pode ser vazio");
        
        if (string.IsNullOrEmpty(Description)) 
            throw new EntityValidationException($"O campo {nameof(Description)} não pode ser vazio");
    }
}