using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Dddify.Localization;

/// <summary>
/// Represents a service that provides shared localization strings, based on the specified resource file <see cref="SharedResource"/> in the <see cref="Assembly.GetEntryAssembly()"/>.
/// </summary>
public interface ISharedStringLocalizer : IStringLocalizer
{

}
