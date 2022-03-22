namespace Dddify.Auditing;

/// <summary>
/// This interface can be implemented to add standard logical deletion property to a class.
/// </summary>
public interface ISoftDeletable
{
    public bool IsDeleted { get; set; }
}
