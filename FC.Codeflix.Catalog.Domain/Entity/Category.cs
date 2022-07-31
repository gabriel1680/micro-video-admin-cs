using FC.Codeflix.Catalog.Domain.Kernel;

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
        Guid id, 
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

    private void Validate()
    {
        if (string.IsNullOrEmpty(Name)) throw new ArgumentNullException(nameof(Name));
        
        if (string.IsNullOrEmpty(Description)) throw new ArgumentNullException(nameof(Description));
    }
}