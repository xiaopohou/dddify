namespace Dddify.Auditing;

/// <summary>
/// This interface can be implemented to add standard concurrency stamp to a class.
/// </summary>
public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}
