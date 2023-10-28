using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestStringResourceUWPApp
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _text = "empty text";

        [RelayCommand]
        private void BtnEnglishClicked()
        {
            Text = TestStringResourceStandard.TestClass.GetHelloWorldString();
        }

        [RelayCommand]
        private void BtnFrenchClicked()
        {
            Text = TestStringResourceStandard.TestClass.GetHelloWorldString(new System.Globalization.CultureInfo("fr-FR"));
        }

        public MainViewModel()
        {

        }
    }
}
