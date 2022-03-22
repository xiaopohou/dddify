using System;

namespace Dddify.AspNetCore.Localization;

public class AppLocalizationOptions
{
    public string ResourcesPath { get; set; } = "Resources";

    public string[] SupportedCultures { get; set; } = Array.Empty<string>();

    public string DefaultCulture { get; set; } = string.Empty;
}
