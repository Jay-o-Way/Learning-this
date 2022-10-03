using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Newtonsoft.Json;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pass_it_on
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
    }

    public class ReadWriteData
    {
        private void CreateNewSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            // test if content is valid; format if necessary (whitespace)
            // make input possible
            // set focus to first input
            RegionDisplay.Visibility = Visibility.Collapsed;
            RegionEdit.Visibility = Visibility.Visible;
            return;
        }
        private void EditSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            // test if content is valid; format if necessary (whitespace)
            // read data from file
            // make input possible
            RegionDisplay.Visibility = Visibility.Collapsed;
            RegionEdit.Visibility = Visibility.Visible;
            //new subject[4] = {"", "", "", ""};
            string subject = SelectSubject.SelectedValue.ToString();
            //if (subject.isValidData())
            if (subject != null)
            {
                Input_Title.Text = subject;
            }
            // set focus to first input
            return;
        }
        private void DeleteSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            // test if content is valid; format if necessary (whitespace)
            // read data from file
            // prompt msgbox to confirm
            // delete subject from file
            // set ComboBox + others
            return;
        }
        private void SaveEdit(object sender, RoutedEventArgs e)
        {
            // read strings from Input
            // test if content is valid; format if necessary (whitespace)
            // read data from file
            // if data exists: prompt to overwrite?
            // save data to file
            RegionEdit.Visibility = Visibility.Collapsed;
            RegionDisplay.Visibility = Visibility.Visible;
            return;
        }
        private void CancelEdit(object sender, RoutedEventArgs e)
        {
            // read strings from Input
            // reset input
            RegionEdit.Visibility = Visibility.Collapsed;
            RegionDisplay.Visibility = Visibility.Visible;
            return;
        }
    }
}
