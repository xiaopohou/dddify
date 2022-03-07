using Dddify.DependencyInjection;
using Dddify.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dddify.AspNetCore.Localization
{
    public class SharedStringLocalizer : ISharedStringLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public SharedStringLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assembly = Assembly.GetEntryAssembly();

            _localizer = factory.Create(type.Name, assembly.FullName);
        }

        public LocalizedString this[string name] => _localizer[name];

        public LocalizedString this[string name, params object[] arguments] => _localizer[name, arguments];

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) => _localizer.GetAllStrings(includeParentCultures);
    }
}
