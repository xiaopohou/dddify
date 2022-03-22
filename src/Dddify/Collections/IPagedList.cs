namespace System.Collections.Generic;

/// <summary>
/// This interface is defined to standardize to return a page of items to clients.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Items"/>.</typeparam>
public interface IPagedList<T>
{
    /// <summary>
    /// The total count of <see cref="Items"/>.
    /// </summary>
    int Total { get; }

    /// <summary>
    /// The list of items.
    /// </summary>
    IEnumerable<T> Items { get; }
}
