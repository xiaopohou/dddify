using System;

namespace Dddify.Guids;

/// <summary>
/// Used to generate Ids.
/// </summary>
public interface IGuidGenerator
{
    /// <summary>
    /// Creates a new <see cref="Guid"/> using GUID type <see cref="SequentialGuidType.SequentialAsString"/>.
    /// </summary>
    Guid Create();

    /// <summary>
    /// Creates a new <see cref="Guid"/>.
    /// </summary>
    /// <param name="guidType"></param>
    /// <returns></returns>
    Guid Create(SequentialGuidType guidType);
}
