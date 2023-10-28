using Microsoft.Windows.ApplicationModel.Resources;

namespace TestStringResourceWinUI.Services
{
    public class LocalizationService
    {
        private readonly ResourceManager _resourceManager;
        private readonly ResourceContext _resourceContext;

        public LocalizationService()
        {
            _resourceManager = new();
            _resourceContext = _resourceManager.CreateResourceContext();
        }

        public void SetLanguage(string lang)
        {
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = lang;
            _resourceContext.QualifierValues["Language"] = lang;
        }
    }
}
