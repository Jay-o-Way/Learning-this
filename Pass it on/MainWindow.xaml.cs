using Microsoft.UI;
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
                var clientSize = new SizeInt32(300, 360);
                appWindow.ResizeClient(clientSize);
            }
            //source: https://learn.microsoft.com/windows/apps/windows-app-sdk/windowing/windowing-overview
        }

        private void LoadSubjectData(ComboBox sender, ComboBoxTextSubmittedEventArgs e)
        {
            string cbText = e.Text; // SelectSubject.Text
            if (IsValid(cbText))
            {
                Console.WriteLine($"Loading data for subject {cbText}");
                SubjectLocation.Content = "World!";
                var uri = new Uri("http://go.go");
                SubjectLocation.NavigateUri = uri;
                SubjectLogin.Text = "Name";
                SubjectPassword.Text = "Password";
            }
            else
            {
                // If the item is invalid, reject it but do not revert the text.
                // Mark the event as handled so the framework doesn't update the selected item.
                SubjectLocation.Content = string.Empty;
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
                RegionDisplay.Visibility = Visibility.Collapsed;
                RegionEdit.Visibility = Visibility.Visible;
                Input_Title.Text = cbText;
                //Input_Location = String.Empty;
                //Input_LogIn = String.Empty
                //Input_Password = String.Empty;
                // set focus to first input
                Input_Title.Focus(FocusState.Keyboard);
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
                RegionDisplay.Visibility = Visibility.Collapsed;
                RegionEdit.Visibility = Visibility.Visible;
                Input_Title.Text = cbText;
                //Input_Location = ?
                //Input_LogIn = ?
                //Input_Password = ?
                // set focus to first input
                Input_Title.Focus(FocusState.Keyboard);
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
                SubjectLocation.Content = string.Empty;
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
            RegionEdit.Visibility = Visibility.Collapsed;
            RegionDisplay.Visibility = Visibility.Visible;
            return;
        }
        private void CancelEdit(object sender, RoutedEventArgs e)
        {
            // read strings from Input???
            // reset input
            Input_Title.Text = string.Empty;
            Input_Location.Text = string.Empty;
            Input_LogIn.Text = string.Empty;
            Input_Password.Password = string.Empty;

            RegionEdit.Visibility = Visibility.Collapsed;
            RegionDisplay.Visibility = Visibility.Visible;
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
            //source: https://stackoverflow.com/questions/70854882/how-to-open-new-browser-window-in-c-winui-3
        }
    }
}
