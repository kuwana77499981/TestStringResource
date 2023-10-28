using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace TestStringResourceStandard
{
    internal sealed class SR
    {
        internal const string BaseName = "TestStringResourceStandard.Strings.Resource";
        private static SR? _loader = null;

        private readonly ResourceManager _rm = new(BaseName, Assembly.GetExecutingAssembly());

        private static SR GetLoader()
        {
            _loader ??= new SR();
            return _loader;
        }

        internal static string? GetString(string name, CultureInfo? culture)
        {
            var loader = GetLoader();
            if (loader == null) return null;

            var res = loader._rm.GetString(name, culture);
            Debug.Assert(res != null);
            return res;
        }

        internal const string HelloWorld = "HelloWorld";
    }
}