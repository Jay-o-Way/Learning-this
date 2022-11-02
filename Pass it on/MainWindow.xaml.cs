using Microsoft.UI;
using Microsoft.UI.Windowing;
//using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
//using Microsoft.UI.Xaml.Controls.Primitives;
//using Microsoft.UI.Xaml.Data;
//using Microsoft.UI.Xaml.Input;
//using Microsoft.UI.Xaml.Media;
//using Microsoft.UI.Xaml.Navigation;
using System;
using System.Diagnostics;
//using System.Collections.ObjectModel;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Graphics;
//using System.Text.Json.Serialization;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PassItOn
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            //ExtendsContentIntoTitleBar = true; // works, but is super ugly

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
                // source: https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.windowing.appwindowtitlebar.iconshowoptions?view=windows-app-sdk-1.1#microsoft-ui-windowing-appwindowtitlebar-iconshowoptions
            }
            // source: https://learn.microsoft.com/windows/apps/windows-app-sdk/windowing/windowing-overview
        }

        private void LoadSubjectData(ComboBox sender, ComboBoxTextSubmittedEventArgs e)
        {
            string cbText = e.Text; // SelectSubject.Text
            if (IsValid(cbText))
            {
                Console.WriteLine($"Loading data for subject {cbText}");
                SubjectLocation.Text = "World!";
                SubjectLogin.Text = "Name";
                SubjectPassword.Text = "Password";
            }
            else
            {
                // If the item is invalid, reject it but do not revert the text.
                // Mark the event as handled so the framework doesn't update the selected item.
                SubjectLocation.Text = string.Empty;
                SubjectLogin.Text = string.Empty;
                SubjectPassword.Text = string.Empty;
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
                SubjectPassword.IsReadOnly = false;
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
                SubjectPassword.IsReadOnly = false;
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
                SubjectPassword.Text = string.Empty;
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
            // reset input?
            // make input impossible
            SelectSubject.IsEditable = false;
            SubjectLocation.IsReadOnly = true;
            SubjectLogin.IsEditable = false;
            SubjectPassword.IsReadOnly = true;

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
    }
}
