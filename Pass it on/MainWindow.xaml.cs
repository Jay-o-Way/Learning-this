using Windows.Storage;
using Windows.Graphics;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Windowing;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PassItOn
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public class PasswordRawData
        {
/*            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string? Summary { get; set; }
*/        }

        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true; // works, but is super ugly

            // Retrieve the window handle (HWND) of the current (XAML) WinUI 3 window.
            var hWnd =
                WinRT.Interop.WindowNative.GetWindowHandle(this);

            // Retrieve the WindowId that corresponds to hWnd.
            Microsoft.UI.WindowId windowId =
                Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);

            // Lastly, retrieve the AppWindow for the current (XAML) WinUI 3 window.
            Microsoft.UI.Windowing.AppWindow appWindow =
                Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

            if (appWindow != null)
            {
                // You now have an AppWindow object, and you can call its methods to manipulate the window.
                // As an example, let's change the title text of the window.
                appWindow.Title = "Pass it on!";

                var clientSize = new SizeInt32(300, 400);
                appWindow.ResizeClient(clientSize);

                var _presenter = appWindow.Presenter as OverlappedPresenter;
                _presenter.IsResizable = false;
                _presenter.IsMaximizable = false;
                // source: https://learn.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.windowing.appwindowtitlebar.iconshowoptions?view=windows-app-sdk-1.1#microsoft-ui-windowing-appwindowtitlebar-iconshowoptions
            }
            // source: https://learn.microsoft.com/windows/apps/windows-app-sdk/windowing/windowing-overview

            LoadAppSettings();
            LoadPasswordFile();
        }

        private void LoadAppSettings()
        {
            Windows.Storage.ApplicationDataContainer localSettings =
                Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;

/*            // Simple setting (write)
            localSettings.Values["exampleSetting"] = "Hello Windows";

            // Simple setting (read)
            Object value = localSettings.Values["exampleSetting"];

            //source: https://learn.microsoft.com/windows/apps/design/app-settings/store-and-retrieve-app-data#create-and-retrieve-a-simple-local-setting
*/
            Object language = localSettings.Values["language"];

            if (language == null) {
                Console.WriteLine("Language not found in settings, using en-us.");
                language = "en-us";
                localSettings.Values["language"] = language; // write
            }
            // can be used (later) to set UI language (at runtime)

            Console.WriteLine($"Lang={language}");
        }

        private static async void LoadPasswordFile()
        {
            #region via STORAGEFOLDER
            //source: https://learn.microsoft.com/windows/uwp/files/quickstart-reading-and-writing-files

            // Create sample file; ~replace~ open if exists.
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;

/*            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt",
                                Windows.Storage.CreationCollisionOption.OpenIfExists);
            Console.WriteLine($"Loaded SampleFile={sampleFile.ToString}");

            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");

            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            Console.WriteLine($"Text in SampleFile={text}");
*/
            const string passwordFileName = "passwords.json";
            Windows.Storage.StorageFile passwordFile = await storageFolder.CreateFileAsync(passwordFileName,
                                Windows.Storage.CreationCollisionOption.OpenIfExists);
            Console.WriteLine($"Loaded PasswordFile={passwordFile.ToString}");
            #endregion StorageFolder

            string passwordFileData = await Windows.Storage.FileIO.ReadTextAsync(passwordFile);

            if (passwordFileData != null)
            {
                // de-serialize
                //using FileStream openStream = File.OpenRead(passwordFileName);
                //PasswordRawData? userPasswordData =
                //    await JsonSerializer.DeserializeAsync<PasswordRawData>(openStream);
                //source: https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-6-0#how-to-read-json-as-net-objects-deserialize

                // pass data to controls?
            }
            else
            {
                // no data
                return;
            }

        }

        private void LoadSubjectData(ComboBox sender, ComboBoxTextSubmittedEventArgs e)
        {
            string cbText = e.Text; // SelectSubject.Text
            if (IsValid(cbText))
            {
                Console.WriteLine($"Loading data for subject {cbText}");
                SubjectLocation.Text = "World!";
                SubjectLogin.Text = "Name";
                SubjectPassword.Password = "Password";
            }
            else
            {
                // If the item is invalid, reject it but do not revert the text.
                SubjectLocation.Text = string.Empty;
                SubjectLogin.Text = string.Empty;
                SubjectPassword.Password = string.Empty;

                // Mark the event as handled so the framework doesn't update the selected item.
                e.Handled = true;
            }
            // source: https://learn.microsoft.com/windows/apps/design/controls/combo-box#sample---validate-input-and-add-to-list
        }

        bool IsValid(string Text)
        {
            Console.WriteLine($"Validating string {Text}");
            // Validate that the string is valid
            return (Text != null);
        }

        private void CreateNewSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            // https://learn.microsoft.com/windows/apps/design/controls/combo-box
            string cbText = SelectSubject.Text;
            // test if content is valid; format if necessary (whitespace)
            if (IsValid(cbText))
            {
                Console.WriteLine($"Creating new subject");

                // make input possible
                SelectSubject.IsEditable = true;
                SubjectLocation.IsReadOnly = false;
                SubjectLogin.IsEditable = true;
                //SubjectPassword.IsReadOnly = false;
                //SubjectPassword.PasswordRevealMode = PasswordRevealMode.Visible;

                // show proper buttons
                Buttons_Display.Visibility = Visibility.Collapsed;
                Buttons_Edit.Visibility = Visibility.Visible;
            }
            return;
        }
        private void EditSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            string cbText = SelectSubject.Text;
            // test if content is valid; format if necessary (whitespace)
            // read data from file
            if (IsValid(cbText))
            {
                Console.WriteLine($"Loading data for subject {cbText}");
                // make input possible
                SelectSubject.IsEditable = true;
                SubjectLocation.IsReadOnly = false;
                SubjectLogin.IsEditable = true;
                //SubjectPassword.PasswordRevealMode = PasswordRevealMode.Visible;

                // show proper buttons
                Buttons_Display.Visibility = Visibility.Collapsed;
                Buttons_Edit.Visibility = Visibility.Visible;
            }
            else
            {
                Console.WriteLine("ERROR > method EditSubject was triggered with invalid data");
                return;
            }
        }
        private void DeleteSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            string cbText = SelectSubject.Text;
            // test if content is valid; format if necessary (whitespace)
            if (IsValid(cbText))
            {
                // read data from file
                // prompt msgbox to confirm
                // delete subject from file
                Console.WriteLine($"Deleting subject {cbText} from file");
                // set ComboBox + others
                SubjectLocation.Text = string.Empty;
                SubjectLogin.Text = string.Empty;
                SubjectPassword.Password = string.Empty;
            }
            else
            {
                Console.WriteLine("ERROR > method DeleteSubject was triggered with invalid data");
                return;
            }
        }
        private void SaveEdit(object sender, RoutedEventArgs e)
        {
            // read strings from Input_*
            // test if content is valid; format if necessary (whitespace)
            // read data from file
            // if data exists for new name: prompt to overwrite!
            // save data to file
            //Console.WriteLine($"Subject {subject} is saved to file");
            Buttons_Edit.Visibility = Visibility.Collapsed;
            Buttons_Display.Visibility = Visibility.Visible;
            return;
        }
        private void CancelEdit(object sender, RoutedEventArgs e)
        {
            // reset input
            // make input impossible
            SelectSubject.IsEditable = false;
            SubjectLocation.IsReadOnly = true;
            SubjectLogin.IsEditable = false;
            SubjectPassword.PasswordRevealMode = PasswordRevealMode.Hidden;

            // show proper buttons
            Buttons_Edit.Visibility = Visibility.Collapsed;
            Buttons_Display.Visibility = Visibility.Visible;
            return;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Exiting application...");
            this.Close();
        }

        private void OpenInfo(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/Jay-o-Way/Learning-this/blob/main/PassItOn.md";
            myProcess.Start();
            // source: https://stackoverflow.com/questions/70854882/how-to-open-new-browser-window-in-c-winui-3
        }

        private void OpenLocation(object sender, RoutedEventArgs e)
        {
            var uri = "http://go.go";
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = uri;
            myProcess.Start();
        }

        private void SetLanguage(object sender, RoutedEventArgs e)
        {
            //get the (string)lang from controlID
            //update gui strings
            //save lang to settings
            //remember to set: IsChecked="True"
        }
    }
}

/*
namespace DeserializeExtra // source: https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/required-properties
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public string? SummaryField;
        public IList<DateTimeOffset>? DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
        public string[]? SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
                ""Cold"": {
                    ""High"": 20,
      ""Low"": -10
                },
    ""Hot"": {
                    ""High"": 60,
      ""Low"": 20
    }
            },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}
";

            WeatherForecast? weatherForecast =
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);

            Console.WriteLine($"Date: {weatherForecast?.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast?.Summary}");
        }
    }
}
// output:
//Date: 8/1/2019 12:00:00 AM -07:00
//TemperatureCelsius: 25
//Summary: Hot
*/
