using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestStringResourceWinUI.Extensions;
using TestStringResourceWinUI.Services;

namespace TestStringResourceWinUIApp
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly LocalizationService _localizationService;

        [ObservableProperty]
        private string _text = "empty text";

        [ObservableProperty]
        private string _textWinUI = "empty text";

        [ObservableProperty]
        private string _textWinUIApp = "empty text";

        [RelayCommand]
        private void BtnEnglishClicked()
        {
            Text = TestStringResource.TestClass.GetHelloWorldString();
        }

        [RelayCommand]
        private void BtnFrenchClicked()
        {
            Text = TestStringResource.TestClass.GetHelloWorldString(new System.Globalization.CultureInfo("fr-FR"));
        }

        [RelayCommand]
        private void BtnEnglishWinUIClicked()
        {
            _localizationService.SetLanguage("en-US");
            TextWinUI = "TestStringResourceWinUI/Resources/HelloWorldWinUI".GetLocalized();

        }

        [RelayCommand]
        private void BtnFrenchWinUIClicked()
        {
            _localizationService.SetLanguage("fr-FR");
            TextWinUI = "TestStringResourceWinUI/Resources/HelloWorldWinUI".GetLocalized();
        }

        [RelayCommand]
        private void BtnEnglishWinUIAppClicked()
        {
            _localizationService.SetLanguage("en-US");
            TextWinUIApp = "Resources/HelloWorldWinUIApp".GetLocalized();

            // TextWinUIApp = "Resources/HelloWorldWinUIApp".GetLocalized();
            // Runs if (_resourceManager.MainResourceMap.TryGetValue(resourceKey) is ResourceCandidate rc) return rc.ValueAsString;
            // Use new language

            // TextWinUIApp = "HelloWorldWinUIApp".GetLocalized();
            // Runs _resourceLoader.GetString(resourceKey);
            // Use old language, need more works
        }

        [RelayCommand]
        private void BtnFrenchWinUIAppClicked()
        {
            _localizationService.SetLanguage("fr-FR");
            TextWinUIApp = "Resources/HelloWorldWinUIApp".GetLocalized();
        }


        public MainViewModel()
        {
            _localizationService = new LocalizationService();
        }
    }
}
