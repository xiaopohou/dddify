using Dddify.Timing;
using Dddify.Guids;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dddify.DependencyInjection;

/// <summary>
/// An interface for allowing fine grained configuration of <c>Dddify</c> services.
/// </summary>
public interface IDddifyBuilder
{
    /// <summary>
    /// Gets the <see cref="IServiceCollection"/> where Dddify services are configured.
    /// </summary>
    IServiceCollection Services { get; }

    /// <summary>
    /// Sets the default <see cref="Guids.SequentialGuidType"/> for the <see cref="IGuidGenerator"/>.
    /// </summary>
    SequentialGuidType SequentialGuidType { set; }

    /// <summary>
    /// Sets the default <see cref="System.DateTimeKind"/> for the <see cref="IClock"/>.
    /// </summary>
    DateTimeKind DateTimeKind { set; }
}
