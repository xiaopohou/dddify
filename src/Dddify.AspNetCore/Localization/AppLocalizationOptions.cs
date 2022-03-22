using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddify.AspNetCore.Localization
{
    public class AppLocalizationOptions
    {
        public string ResourcesPath { get; set; } = "Resources";

        public string[] SupportedCultures { get; set; } = Array.Empty<string>();

        public string DefaultCulture { get; set; } = string.Empty;
    }
}
