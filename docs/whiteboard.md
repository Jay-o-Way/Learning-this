# Whiteboard

So much to learn, so much to do...

## START A PROJECT

How to get started in the first place.

<https://learn.microsoft.com/windows/apps/get-started/?tabs=net-maui%2Ccpp-win32>

<https://learn.microsoft.com/windows/apps/windows-app-sdk/set-up-your-development-environment?tabs=vs-2022-17-1-a%2Cvs-2022-17-1-b>

<https://learn.microsoft.com/windows/apps/winui/winui3/create-your-first-winui3-app>

<dl>
<dt>What kind of Packaging? [msix, sparse, none]</dt>
<dd>❓</dd>
</dl>

> Packaging is an important consideration of any Windows App SDK project. You can skip over this section if you wish, and create a unpackaged project. But please come back later to read more about it.

<dl>
<dt>Do I need Tests?</dt>
<dd>Yes!</dd>
</dl>

YouTube playlists:

- [C# for beginners](https://www.youtube.com/watch?v=BM4CHBmAPh4&list=PLdo4fOcmZ0oVxKLQCHpiUWun7vlJJvUiN)
  - [C# 201](https://www.youtube.com/watch?v=p5myHVOtmiU&list=PLdo4fOcmZ0oXzJ3FC-ApBes-0klFN9kr9)
- [.NET for beginners](https://www.youtube.com/watch?v=eIHKZfgddLM&list=PLdo4fOcmZ0oWoazjhXQzBKMrFuArxpW80)
- [NuGet for Beginners](https://www.youtube.com/watch?v=WW3bO1lNDmo&list=PLdo4fOcmZ0oVLvfkFk8O9h6v2Dcdh2bh_)

## GUI

Should be similar to Windows 11. Origin for style = <https://learn.microsoft.com/windows/apps/design/signature-experiences/design-principles>

<dl>
<dt>Strings: resx or resw?</dt>
<dd>RESW</dd>
</dl>

<https://learn.microsoft.com/windows/apps/design/globalizing/prepare-your-app-for-localization>

Settings (UI)

<https://learn.microsoft.com/windows/apps/design/app-settings/guidelines-for-app-settings>

Theme?

### Styles

☑ Custom styles should be in a centralized file.

<https://learn.microsoft.com/windows/apps/design/style/xaml-theme-resources>

```cs
    var _presenter = appWindow.Presenter as OverlappedPresenter;
    _presenter.IsResizable = false;
    _presenter.IsMaximizable = false;
```

<https://learn.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.windowing.appwindowtitlebar.iconshowoptions?view=windows-app-sdk-1.1#microsoft-ui-windowing-appwindowtitlebar-iconshowoptions>

```cs
    // You now have an AppWindow object, and you can call its methods to manipulate the window.
    // As an example, let's change the title text of the window.
    appWindow.Title = "Pass it on!";
    
    var clientSize = new SizeInt32(300, 400);
    appWindow.ResizeClient(clientSize);
```

<https://learn.microsoft.com/windows/apps/windows-app-sdk/windowing/windowing-overview>

### CODE-BEHIND

> Ideally, all of the methods in a class have a related purpose in the system. The class in the preceding code is named Program.

<https://learn.microsoft.com/training/modules/dotnet-introduction/4-build-your-first-app#code-try-0:~:text=Ideally%2C%20all%20of%20the%20methods%20in%20a%20class%20have%20a%20related%20purpose%20in%20the%20system.%20The%20class%20in%20the%20preceding%20code%20is%20named%20Program>.

❔ Classes & methods: mostly via C# or try via XAML?

## DATA STORAGE

File format: Probably JSON, but needs serialize/de-serialize?

ℹ Location:

- C:\Users\jmpaa\AppData\Local\Packages\0e0ad59e-38ad-45d7-9862-6ef2ff95110e_mwbatjgbzh7yr\
  - Settings\
    - settings.dat
  - LocalState\
    - sample.txt
    - passwords.json

Set/Get setting(s).
<https://learn.microsoft.com/windows/apps/design/app-settings/store-and-retrieve-app-data#create-and-retrieve-a-simple-local-setting>

Write to file (UWP).
<https://learn.microsoft.com/windows/uwp/files/quickstart-reading-and-writing-files>

Write to file (APP).
<https://learn.microsoft.com/windows/apps/design/app-settings/store-and-retrieve-app-data#create-and-read-a-local-file>

❔ Import/Export data (passwords).

## RELEASE

To be learned...
