# TestStringResource

A playground for demonstrating how to use resx & resw in dotnet 7, WinUI, .Net Standard 2.0 and UWP.

# How to use resx like resw

Copy the resw xml text as resx file
Use ```System.Resources.ResourceManager``` to ```GetString```

**Original Resw Created by Visual Studio**

Build Action: PRIResource

**Original Resx Created by Visual Studio**

Build Action: Embedded resource  
Custom Tool: ResXFileCodeGenerator

```xml
    <EmbeddedResource Update="Strings\Resource1.resx">
      <Generator>ResXFileCodeGenerator</Generator>
      <LastGenOutput>Resource1.Designer.cs</LastGenOutput>
    </EmbeddedResource>
```

**Create a String Resource Class**

TestStringResource/SR.cs

```C#
private readonly ResourceManager _rm = new(BaseName, Assembly.GetExecutingAssembly());

var res = loader._rm.GetString(name, culture);
```

# Solution Structure

| Project | Type | Descriptions |
| --- | --- | --- |
| TestStringResource | dotnet 7 Class Library | resx, ```System.Resources.ResoureManager```, ```Thread.CurrentThread.CurrentUICulture``` |
| TestStringResourceApp | dotnet 7 Console App | ... |
| TestStringResourceStandard | .Net Standard 2.0 Class Library |  resx, ```System.Resources.ResoureManager```, ```Thread.CurrentThread.CurrentUICulture``` |
| TestStringResourceStandardApp | .Net Standard 2.0 Console App | ... | 
| TestStringResourceUWPApp | .Net Universal Windows Platform | ... |
| TestStringResourceWinUI | dotnet 7 WinUI Class Library | resw, ```Microsoft.Windows.ApplicationModel.Resources.ResourceLoader```, ```Microsoft.Windows.ApplicationModel.Resources.ResourceManager```, ```Microsoft.Windows.ApplicationModel.Resources.ResourceContext```.QualifierValues["Language"], ```Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverrid```|
| TestStringResourceWinUIApp | dotnet 7 WinUI App | ... |

## Dotnet 7

**Project Structure**

```md
TestStringResource
├── Strings
│   ├── Resource.en-US.resx
│   └── Resource.fr-FR.resx
├── SR.cs
└── TestClass.cs

TestStringResourceApp
└── Program.cs

TestStringResourceWinUI
├── Extensions
│   └── ResourceExtensions.cs
├── Services
│   └── LocalizationService.cs
└── Strings
    ├── en-US
    │   ├── Resource.resw
    └── fr-FR
        └── Resource.resw
 
TestStringResourceWinUIApp
├── Assets
│   └── ...
├── Strings
│   ├── en-US
│   │   ├── Resource.resw
│   └── fr-FR
│       └── Resource.resw
├── App.xaml
│   └── App.xaml.cs
├── MainPage.xaml
│   └── MainPage.xaml.cs
├── MainViewModel.cs
└── Package.appxmanifest

```

## .Net Standard 2.0

**Project Structure**

```md
TestStringResourceStandard
├── Strings
│   ├── Resource.en-US.resx
│   └── Resource.fr-FR.resx
├── SR.cs
└── TestClass.cs

TestStringResourceStandardApp
└── Program.cs

TestStringResourceUWPApp
├── Assets
│   └── ...
├── App.xaml
│   └── App.xaml.cs
├── MainPage.xaml
│   └── MainPage.xaml.cs
├── MainViewModel.cs
└── Package.appxmanifest
```

# Useful Resources

[How to create user-defined exceptions with localized exception messages](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-localized-exception-messages)

- ResourceManager
- Localization
- resx
- Exception

```C#
var resourceManager = new ResourceManager("FULLY_QUALIFIED_NAME_OF_RESOURCE_FILE", Assembly.GetExecutingAssembly());
throw new StudentNotFoundException(resourceManager.GetString("StudentNotFound"), "John");
```

---

[ResourceManager Class](https://learn.microsoft.com/en-us/dotnet/api/system.resources.resourcemanager?view=net-7.0)

- dotnet 7
- Localization
- txt, restext, resw

```C#
ResourceManager rm = new ResourceManager("Strings", typeof(Example).Assembly);
string timeString = rm.GetString("TimeHeader");
```

```C#
CultureInfo newCulture = new CultureInfo(cultures[cultureNdx]);
Thread.CurrentThread.CurrentCulture = newCulture;
Thread.CurrentThread.CurrentUICulture = newCulture;
string greeting = String.Format("The current culture is {0}.\n{1}",
                                Thread.CurrentThread.CurrentUICulture.Name,
                                rm.GetString("HelloString"));
```

---

[microsoft/referencesource/System.Workflow.Activities/SR.cs](https://github.com/microsoft/referencesource/blob/master/System.Workflow.Activities/SR.cs)

- ResourceManager
- String Resource

```C#
public SRDescriptionAttribute(string description, string resourceSet)
{
    ResourceManager rm = new ResourceManager(resourceSet, Assembly.GetExecutingAssembly());
    DescriptionValue = rm.GetString(description);
    System.Diagnostics.Debug.Assert(DescriptionValue != null, string.Format(CultureInfo.CurrentCulture, "String resource {0} not found.", description));
}

...


internal sealed class SR
{
    static SR loader = null;
    ResourceManager resources;

    internal SR()
    {
        resources = new System.Resources.ResourceManager("System.Workflow.Activities.StringResources", Assembly.GetExecutingAssembly());
    }

    private static SR GetLoader()
    {
        if (loader == null)
            loader = new SR();
        return loader;
    }

    ...

    internal static string GetString(CultureInfo culture, string name, params object[] args)
    {
        SR sys = GetLoader();
        if (sys == null)
            return null;
        string res = sys.resources.GetString(name, culture);
        System.Diagnostics.Debug.Assert(res != null, string.Format(CultureInfo.CurrentCulture, "String resource {0} not found.", name));
        if (args != null && args.Length > 0)
        {
            return String.Format(CultureInfo.CurrentCulture, res, args);
        }
        else
        {
            return res;
        }
    }

    internal const string Activity = "Activity";

    ...

    private const string Error_InvalidStateActivityParent = "Error_InvalidStateActivityParent";
    internal static string GetError_InvalidStateActivityParent()
    {
        return GetString(Error_InvalidStateActivityParent,
            typeof(StateActivity).Name);
    }
```

[microsoft/referencesource/Microsoft.Activities.Build/SR.resx](https://github.com/microsoft/referencesource/blob/master/Microsoft.Activities.Build/SR.resx)

```xml
  <data name="InspectingClass" xml:space="preserve">
    <value>XAML build extension '{0}' is inspecting class '{1}'.</value>
  </data>
```

[Include a localized string message in every exception](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions#include-a-localized-string-message-in-every-exception)

[Use exception builder methods](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions#use-exception-builder-methods)

```C#
FileReaderException NewFileIOException()
{
    string description = "My NewFileIOException Description";

    return new FileReaderException(description);
}

...

    throw NewFileIOException();
```

---

[microsoft/WindowsAppSDK-Samples/Samples/ResourceManagement/cs-winui/ClassLibrary/Class.cs](https://github.com/microsoft/WindowsAppSDK-Samples/blob/main/Samples/ResourceManagement/cs-winui/ClassLibrary/Class.cs)

- WinUI

```C#
using Microsoft.Windows.ApplicationModel.Resources;

...

public string GetClassLibrarySampleString()
{
    var resourceManager = new ResourceManager();
    return resourceManager.MainResourceMap.GetValue("ClassLibrary/ClassLibraryResources/ClassLibrarySampleString").ValueAsString;
}
```

[ResourceLoader Class](https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.applicationmodel.resources.resourceloader?view=windows-app-sdk-0.8)

[ResourceManager Class](https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.applicationmodel.resources.resourcemanager?view=windows-app-sdk-0.8)

[ResourceLoader Class](https://learn.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.resourceloader?view=winrt-22621)

- A ResourceLoader object encapsulates a particular ResourceMap and a ResourceContext, combined in a simple API.

```C#
var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
var text = resourceLoader.GetString("Farewell");
```

[Application resources and localization sample](https://learn.microsoft.com/en-us/samples/microsoft/windows-universal-samples/applicationresources/)
[Windows-universal-samples/Samples/ApplicationResources/cs/scenario10.xaml.cs](https://github.com/microsoft/Windows-universal-samples/blob/main/Samples/ApplicationResources/cs/scenario10.xaml.cs)

```C#
var context = ResourceContext.GetForCurrentView().Clone();

var dimensionMap = ResourceManager.Current.MainResourceMap.GetSubtree("dimensions");

void Scenario10_ShowCandidates(string resourceId, IReadOnlyList<ResourceCandidate> resourceCandidates) {

    foreach (var candidate in resourceCandidates)
    {
        var value = candidate.ValueAsString;
        foreach (var qualifier in candidate.Qualifiers)
                {
                    var qualifierName = qualifier.QualifierName;
                    var qualifierValue = qualifier.QualifierValue;
```

---
