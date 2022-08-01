namespace FC.Codeflix.Catalog.Domain.Kernel.ValueObject;

public abstract class BaseValueObject<T>
{
    public T Value;

    public BaseValueObject(T value)
    {
        Value = value;
    }

    protected bool Equals(BaseValueObject<T> other)
    {
        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BaseValueObject<T>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Value);
    }
}