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
            //this.Title = "Pass it on!";
            // read data from file?
            //var passDataFile = Path.Combine(Directory.GetCurrentDirectory(), "DataFile.json");
            //Console.WriteLine(passDataFile);
            //if (File.Exists(passDataFile))
            //{
            //    var readDataFileContent = File.ReadAllText(passDataFile);
            //    if (String.IsNullOrEmpty(readDataFileContent))
            //    {
            //        Console.WriteLine("Data file exists, but is empty. Creating file now.");
            //        File.WriteAllText(passDataFile, String.Empty);
            //        return;
            //    }
            //    else
            //    {
            //        //populate Combobox?

            //        return;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Data file does not exist. Creating file now.");
            //    File.WriteAllText(passDataFile, String.Empty);
            //}
        }

        private void CreateNewSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            // test if content is valid; format if necessary (whitespace)
            // make input possible
            // set focus to first input
            return;
        }
        private void EditSubject(object sender, RoutedEventArgs e)
        {
            // read string from ComboBox
            // test if content is valid; format if necessary (whitespace)
            // read data from file
            // make input possible
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
            // set IsEnabled=false
            return;
        }
        private void CancelEdit(object sender, RoutedEventArgs e)
        {
            // read strings from Input
            // reset input
            // set IsEnabled=false
            return;
        }
    }
}
