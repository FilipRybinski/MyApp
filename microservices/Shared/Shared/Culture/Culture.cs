using System.Globalization;

namespace Shared.Culture;

public static class Culture
{
    public static void ConfigureCulture(string language)
    {
        var culture = new CultureInfo(language);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }   
}