using Microsoft.Extensions.DependencyInjection;

namespace Dddify.DependencyInjection;

/// <summary>
/// All classes implement this interface are automatically registered to the specified <see cref="IServiceCollection"/> as <see cref="ServiceLifetime.Singleton"/> service.
/// </summary>
public interface ISingletonDependency
{
}
