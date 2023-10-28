using System.Globalization;

namespace TestStringResourceStandard
{
    public static class TestClass
    {
        public static string? GetHelloWorldString(CultureInfo? culture = null)
        {
            return SR.GetString(SR.HelloWorld, culture);
        }
    }
}
