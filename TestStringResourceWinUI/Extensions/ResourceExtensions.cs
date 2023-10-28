using Microsoft.Windows.ApplicationModel.Resources;

namespace TestStringResourceWinUI.Extensions
{
    public static class ResourceExtensions
    {
        private static readonly ResourceLoader _resourceLoader = new();
        private static readonly ResourceManager _resourceManager = new();

        public static string GetLocalized(this string resourceKey)
        {
            if (_resourceManager.MainResourceMap.TryGetValue(resourceKey) is ResourceCandidate rc)
            {
                return rc.ValueAsString;
            }

            return _resourceLoader.GetString(resourceKey);
        }
    }
}
